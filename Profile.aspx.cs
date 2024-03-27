using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_Cinemate_FinalMP
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate user profile information
                PopulateUserProfile();

                // Populate booking history
                PopulateBookingHistory();
            }
        }

        private void PopulateUserProfile()
        {
            // Establish connection string
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MovieTicketDB.mdf;Integrated Security=True";

            // Get logged-in username (you need to implement this part)
            string loggedInUsername = GetLoggedInUsername();

            if (!string.IsNullOrEmpty(loggedInUsername))
            {
                try
                {
                    // Create SqlConnection using the connection string
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Open the connection
                        connection.Open();

                        // Query to get user information based on username
                        string getUserInfoQuery = "SELECT * FROM [dbo].[ACCOUNT] WHERE username = @username";
                        SqlCommand getUserInfoCmd = new SqlCommand(getUserInfoQuery, connection);
                        getUserInfoCmd.Parameters.AddWithValue("@username", loggedInUsername);
                        SqlDataReader reader = getUserInfoCmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // Populate TextBoxes with user information
                            txtUsername.Text = reader["username"].ToString();
                            txtEmail.Text = reader["email"].ToString();
                            showTxtPassword.Text = reader["password"].ToString();
                        }

                        // Close the reader and connection
                        reader.Close();
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                }
            }
        }

        private void PopulateBookingHistory()
        {
            // Establish connection string
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MovieTicketDB.mdf;Integrated Security=True";

            // Get logged-in username
            string loggedInUsername = GetLoggedInUsername();

            if (!string.IsNullOrEmpty(loggedInUsername))
            {
                try
                {
                    // Query to get booking history
                    string getBookingHistoryQuery = "SELECT B.booking_id AS BookingID, M.title AS MovieTitle, CONCAT(M.show_date, ' ', M.show_time) AS ShowDate, S.seat_number AS SeatNumber, B.booking_date AS BookingDate, M.ticket_price AS TicketPrice FROM [dbo].[BOOKING] B INNER JOIN [dbo].[MOVIE] M ON B.movie_id = M.movie_id INNER JOIN [dbo].[SEAT] S ON B.seat_id = S.seat_id WHERE B.username = @username";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(getBookingHistoryQuery, connection);
                        cmd.Parameters.AddWithValue("@username", loggedInUsername);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Format date and time without milliseconds
                        foreach (DataRow row in dt.Rows)
                        {
                            DateTime showDateTime = DateTime.Parse(row["ShowDate"].ToString());
                            row["ShowDate"] = showDateTime.ToString("dd/MM/yyyy hh:mm:ss tt"); // Using "tt" for AM/PM
                        }


                        gvBookingHistory.DataSource = dt;
                        gvBookingHistory.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                }
            }
        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            // Establish connection string
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MovieTicketDB.mdf;Integrated Security=True";

            try
            {
                // Create SqlConnection using the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Update user information in USER table
                    string updateUserInfoQuery = "UPDATE [dbo].[ACCOUNT] SET username = @newUsername, email = @newEmail, password = @newPassword WHERE username = @oldUsername";
                    SqlCommand updateUserInfoCmd = new SqlCommand(updateUserInfoQuery, connection);
                    updateUserInfoCmd.Parameters.AddWithValue("@newUsername", txtUsername.Text);
                    updateUserInfoCmd.Parameters.AddWithValue("@newEmail", txtEmail.Text);
                    updateUserInfoCmd.Parameters.AddWithValue("@newPassword", txtPassword.Text);
                    updateUserInfoCmd.Parameters.AddWithValue("@oldUsername", GetLoggedInUsername()); // Use the old username
                    int rowsAffected = updateUserInfoCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Update username in BOOKING table
                        string updateBookingUsernameQuery = "UPDATE [dbo].[BOOKING] SET username = @newUsername WHERE username = @oldUsername";
                        SqlCommand updateBookingUsernameCmd = new SqlCommand(updateBookingUsernameQuery, connection);
                        updateBookingUsernameCmd.Parameters.AddWithValue("@newUsername", txtUsername.Text);
                        updateBookingUsernameCmd.Parameters.AddWithValue("@oldUsername", GetLoggedInUsername()); // Use the old username
                        updateBookingUsernameCmd.ExecuteNonQuery();

                        // Update username in QUANTITY table
                        string updateQuantityUsernameQuery = "UPDATE [dbo].[QUANTITY] SET username = @newUsername WHERE username = @oldUsername";
                        SqlCommand updateQuantityUsernameCmd = new SqlCommand(updateQuantityUsernameQuery, connection);
                        updateQuantityUsernameCmd.Parameters.AddWithValue("@newUsername", txtUsername.Text);
                        updateQuantityUsernameCmd.Parameters.AddWithValue("@oldUsername", GetLoggedInUsername()); // Use the old username
                        updateQuantityUsernameCmd.ExecuteNonQuery();

                        // Update session with the new username
                        Session["Username"] = txtUsername.Text;

                        // Display success message and reload page;
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Updated successfully.'); window.location.href = window.location.href;", true);
                    }
                    else
                    {
                        // Display error message
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Update Failed. Please try again.');", true);
                    }

                    // Close the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Username is already taken
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Update Failed. Username is already taken. Please try again.');", true);
            }
        }

        // This method should be implemented to get the logged-in username
        private string GetLoggedInUsername()
        {
            // Check if the session is not null and contains the username
            if (Session["Username"] != null)
            {
                return Session["Username"].ToString();
            }
            else
            {
                // Redirect to the login page or handle the scenario where the session is not available
                Response.Redirect("~/Default.aspx");
                return null;
            }
        }
    }
}