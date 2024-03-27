using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_Cinemate_FinalMP
{
    public partial class Movie3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateMovieDesc();
            }
        }

        private void PopulateMovieDesc()
        {
            // Query the MOVIE table to get movie details
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MovieTicketDB.mdf;Integrated Security=True";
            string query = "SELECT title, synopsis, duration, show_date, show_time, ticket_price FROM MOVIE WHERE movie_id = @movieId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@movieId", 3); // Set the movie_id value you want to retrieve

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Populate labels with retrieved data
                    lblMovieTitle.Text = reader["title"].ToString();
                    lblSynopsis.Text = reader["synopsis"].ToString();
                    lblShowDate.Text = "Show Date: " + ((DateTime)reader["show_date"]).ToString("dd/MM/yyyy");
                    lblShowTime.Text = "Show Time: " + ((TimeSpan)reader["show_time"]).ToString(@"hh\:mm");
                    lblTicketPrice.Text = $"Php {Convert.ToDecimal(reader["ticket_price"]).ToString("0.00")}";

                    // Convert duration from minutes to hours and minutes format
                    int durationInMinutes = Convert.ToInt32(reader["duration"]);
                    TimeSpan duration = TimeSpan.FromMinutes(durationInMinutes);
                    lblDuration.Text = $"{duration.Hours}h {duration.Minutes}m";
                }

                reader.Close();
            }
        }

        protected void SeatButton_Click(object sender, EventArgs e)
        {
            // Get the seat button that was clicked
            Button seatButton = (Button)sender;

            // Set the text of the clicked button to the seat number textbox
            showSeatNumber.Text = seatButton.Text;
        }

        protected void btnBookSeat_Click(object sender, EventArgs e)
        {
            try
            {
                // Establish connection string
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MovieTicketDB.mdf;Integrated Security=True";

                // Get the last booking_id from the BOOKING table
                int lastBookingId = GetLastBookingId(connectionString);

                // Calculate the new booking_id
                int newBookingId = lastBookingId + 1;

                // Get the logged-in username
                string username = GetLoggedInUsername();

                // Get the seat_id based on the value in showSeatNumber textbox
                int seatId = GetSeatId(showSeatNumber.Text);

                // Get the current date and time in the specified format
                string bookingDate = "Mar 27 2024";

                // Check seat availability
                string availability = CheckSeatAvailability(connectionString, seatId);


                if (availability == "Available")
                {
                    // Insert into BOOKING table
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Open the connection
                        connection.Open();

                        // Insert booking details into the database
                        string insertBookingQuery = "INSERT INTO BOOKING (booking_id, username, movie_id, seat_id, booking_date) " +
                                                    "VALUES (@booking_id, @username, @movie_id, @seat_id, @booking_date)";
                        SqlCommand insertBookingCmd = new SqlCommand(insertBookingQuery, connection);
                        insertBookingCmd.Parameters.AddWithValue("@booking_id", newBookingId);
                        insertBookingCmd.Parameters.AddWithValue("@username", username);
                        insertBookingCmd.Parameters.AddWithValue("@movie_id", 3); // Assuming movie_id is fixed for this example
                        insertBookingCmd.Parameters.AddWithValue("@seat_id", seatId);
                        insertBookingCmd.Parameters.AddWithValue("@booking_date", bookingDate);
                        int rowsAffected = insertBookingCmd.ExecuteNonQuery();

                        // Close the connection
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            // Update seat availability
                            UpdateSeatAvailability(connectionString, seatId);

                            // Clear the seat selection and refresh the page
                            showSeatNumber.Text = "";

                            // Booking successful
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Booking successful.'); window.location.href = window.location.href;", true);

                            //Response.Redirect(Request.Url.AbsoluteUri);
                        }
                        else
                        {
                            // Handle booking failure
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Booking failed. Please try again.');", true);
                        }
                    }
                }
                else if (availability == "Unavailable")
                {
                    // Seat already taken, show alert
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This seat is already taken. Please choose another seat.');", true);
                }
                else
                {
                    // Handle other availability statuses if needed
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seat availability check failed.');", true);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
        }

        private string CheckSeatAvailability(string connectionString, int seatId)
        {
            try
            {
                string query = "SELECT availability FROM SEAT WHERE seat_id = @seatId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@seatId", seatId);
                    connection.Open();
                    string availability = command.ExecuteScalar()?.ToString();
                    connection.Close();
                    return availability;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new Exception($"Error checking seat availability: {ex.Message}");
            }
        }

        private void UpdateSeatAvailability(string connectionString, int seatId)
        {
            try
            {
                string query = "UPDATE SEAT SET availability = 'Unavailable' WHERE seat_id = @seatId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@seatId", seatId);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new Exception($"Error updating seat availability: {ex.Message}");
            }
        }

        private int GetLastBookingId(string connectionString)
        {
            int lastBookingId = 0;
            string query = "SELECT MAX(booking_id) FROM BOOKING";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                object result = command.ExecuteScalar();
                connection.Close();

                if (result != null && result != DBNull.Value)
                {
                    lastBookingId = Convert.ToInt32(result);
                }
            }

            return lastBookingId;
        }

        private int GetSeatId(string seatName)
        {
            switch (seatName)
            {
                case "A1":
                    return 41;
                case "A2":
                    return 42;
                case "A3":
                    return 43;
                case "A4":
                    return 44;
                case "B1":
                    return 45;
                case "B2":
                    return 46;
                case "B3":
                    return 47;
                case "B4":
                    return 48;
                case "C1":
                    return 49;
                case "C2":
                    return 50;
                case "C3":
                    return 51;
                case "C4":
                    return 52;
                case "D1":
                    return 53;
                case "D2":
                    return 54;
                case "D3":
                    return 55;
                case "D4":
                    return 56;
                case "E1":
                    return 57;
                case "E2":
                    return 58;
                case "E3":
                    return 59;
                case "E4":
                    return 60;
                default:
                    return -1; // Invalid seat
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
            
            //return "TestAcc";
        }
    }
}