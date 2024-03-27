using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_Cinemate_FinalMP
{
    public partial class Movie1 : System.Web.UI.Page
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
                command.Parameters.AddWithValue("@movieId", 1); // Set the movie_id value you want to retrieve

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Populate labels with retrieved data
                    lblMovieTitle.Text = reader["title"].ToString();
                    lblSynopsis.Text = reader["synopsis"].ToString();
                    lblShowDate.Text = ((DateTime)reader["show_date"]).ToString("dd/MM/yyyy");
                    lblShowTime.Text = ((TimeSpan)reader["show_time"]).ToString(@"hh\:mm");
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
            string seatNumber = showSeatNumber.Text;
            if (!string.IsNullOrEmpty(seatNumber))
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MovieTicketDB.mdf;Integrated Security=True";

                // Get the last booking_id from the BOOKING table
                int bookingId;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string getLastBookingIdQuery = "SELECT TOP 1 booking_id FROM BOOKING ORDER BY booking_id DESC";
                    SqlCommand command = new SqlCommand(getLastBookingIdQuery, connection);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int lastBookingId))
                    {
                        bookingId = lastBookingId + 1;
                    }
                    else
                    {
                        bookingId = 1;
                    }
                }

                // Insert into BOOKING table
                string insertBookingQuery = "INSERT INTO BOOKING (booking_id, username, movie_id, seat_id, booking_date) VALUES (@bookingId, @username, @movieId, @seatId, @bookingDate)";
                string updateSeatQuery = "UPDATE SEAT SET availability = 'Unavailable' WHERE seat_id = @seatId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand insertCommand = new SqlCommand(insertBookingQuery, connection);
                    insertCommand.Parameters.AddWithValue("@bookingId", bookingId);
                    insertCommand.Parameters.AddWithValue("@username", GetLoggedInUsername());
                    insertCommand.Parameters.AddWithValue("@movieId", 1); // First Movie
                    insertCommand.Parameters.AddWithValue("@seatId", GetSeatId(seatNumber));
                    insertCommand.Parameters.AddWithValue("@bookingDate", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));

                    SqlCommand updateCommand = new SqlCommand(updateSeatQuery, connection);
                    updateCommand.Parameters.AddWithValue("@seatId", GetSeatId(seatNumber));

                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        insertCommand.Transaction = transaction;
                        updateCommand.Transaction = transaction;

                        insertCommand.ExecuteNonQuery();
                        updateCommand.ExecuteNonQuery();

                        transaction.Commit();

                        // Disable the booked seat button and change its color
                        DisableBookedSeat(seatNumber);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        // Handle exception
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private int GetSeatId(string seatNumber)
        {
            switch (seatNumber)
            {
                case "A1":
                    return 1;
                case "A2":
                    return 2;
                case "A3":
                    return 3;
                // Handle other seat numbers similarly
                default:
                    return 0;
            }
        }

        private void DisableBookedSeat(string seatNumber)
        {
            Button btn = FindControl("btn" + seatNumber) as Button;
            if (btn != null)
            {
                btn.Enabled = false;
                btn.CssClass = "booked-seat-btn";
            }
        }

        // This method should be implemented to get the logged-in username
        private string GetLoggedInUsername()
        {
            /*
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
            */
            return "TestAcc";
        }
    }
}