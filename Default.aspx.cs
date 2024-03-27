using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_Cinemate_FinalMP
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            // Get user input
            string newUsernameValue = newUsername.Text;
            string emailValue = email.Text;
            string newPasswordValue = newPassword.Text;

            try
            {
                // Insert sign-up details into the database
                InsertSignUp(newUsernameValue, emailValue, newPasswordValue);

                // Registration successful
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Registration successful. You can now login.'); window.location.href = window.location.href;", true);
            }
            catch (Exception)
            {
                // Handle registration failure (username is taken)
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Registration failed. Username is already taken. Please try again.');", true);
            }
        }
        private void InsertSignUp(string newUsernameValue, string emailValue, string newPasswordValue)
        {
            // Insert into ACCOUNT table
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MovieTicketDB.mdf;Integrated Security=True";
            string insertQuery = "INSERT INTO ACCOUNT (username, email, password) VALUES (@username, @email, @password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@username", newUsernameValue);
                command.Parameters.AddWithValue("@email", emailValue);
                command.Parameters.AddWithValue("@password", newPasswordValue);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            // Get user input
            string usernameValue = username.Text;
            string passwordValue = password.Text;

            // Check if username and password match
            if (IsLoginValid(usernameValue, passwordValue))
            {
                // Set the username session
                Session["Username"] = usernameValue;

                // Redirect to Home.aspx
                Response.Redirect("Home.aspx");
            }
            else
            {
                // Display alert for unsuccessful login
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid username or password.');", true);
            }
        }

        private bool IsLoginValid(string username, string password)
        {
            // Check if username and password match in the database
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MovieTicketDB.mdf;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM ACCOUNT WHERE username = @username AND password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                return count > 0; // If count is greater than 0, login is valid
            }
        }

        protected void SignButton_Click(object sender, EventArgs e)
        {
            form2.Visible = true;
            form1.Visible = false;            
        }
    }
}