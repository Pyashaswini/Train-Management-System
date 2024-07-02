using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Train_Management_System
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                // Get passenger ID from session
                string passengerID = Session["userid"].ToString();
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            }
            else
            {
                // Redirect to login page if user is not logged in
                Response.Redirect("userlogin.aspx");
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string trainID = TextBox1.Text.Trim();
            string seat = TextBox2.Text.Trim();
            string ticketDate = Calendar1.SelectedDate.ToShortDateString();
            string passengerID = Session["userid"].ToString();


            if (Calendar1.SelectedDate <= DateTime.Today)
            {
                Response.Write("<script>alert('Booking date must be after today');</script>");
                return;
            }
            // Check if the seat is available
            if (IsSeatAvailable(trainID, seat))
            {
                // Book the ticket
                if (BookTicket(trainID, passengerID, seat, ticketDate))
                {
                    Response.Write("Ticket booked successfully.");
                }
                else
                {
                    Response.Write("Failed to book ticket. Please try again.");
                }
            }
            else
            {
                Response.Write("Selected seat is not available.");
            }

            // Refresh the GridView
            GridView1.DataBind();
        }

        // Check if the selected seat is available for the given train
        private bool IsSeatAvailable(string trainID, string seat)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string query = "SELECT COUNT(*) FROM Seat WHERE train_id = @trainID AND seat_no = @seat AND availability = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@trainID", trainID);
                command.Parameters.AddWithValue("@seat", seat);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    Response.Write("An error occurred while checking seat availability: " + ex.Message);
                    return false;
                }
            }
        }

        // Book the ticket
        private bool BookTicket(string trainID, string passengerID, string seat, string ticketDate)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string query = "INSERT INTO Passenger_Ticket (p_id, train_id, seat, ticket_date) VALUES (@passengerID, @trainID, @seat, @ticketDate)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@passengerID", passengerID);
                command.Parameters.AddWithValue("@trainID", trainID);
                command.Parameters.AddWithValue("@seat", seat);
                command.Parameters.AddWithValue("@ticketDate", ticketDate);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Response.Write("An error occurred while booking the ticket: " + ex.Message);
                    return false;
                }
            }
        }
    }
}