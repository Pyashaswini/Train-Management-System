using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Train_Management_System
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                string passengerID = Session["userid"].ToString();
                string feedbackContent = TextBox2.Text.Trim();
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                // Insert feedback into the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Feedback (content, p_id) VALUES (@content, @passengerID)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@content", feedbackContent);
                    command.Parameters.AddWithValue("@passengerID", passengerID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        // Check if feedback was successfully added
                        if (rowsAffected > 0)
                        {
                            
                            Response.Write("Successfully added feedback.");
                        }
                        else
                        {
                            // Handle feedback insertion failure
                            Response.Write("Failed to add feedback.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        Response.Write("An error occurred: " + ex.Message);
                    }
                }
                GridView1.DataBind();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                string passengerID = Session["userid"].ToString();
                string feedbackID = TextBox1.Text.Trim();

                // Check if the feedback belongs to the logged-in passenger before deleting it
                bool isAuthorizedToDelete = IsFeedbackBelongsToPassenger(feedbackID, passengerID);

                if (isAuthorizedToDelete)
                {
                    // Delete feedback from the database
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Feedback WHERE fee_id = @feedbackID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@feedbackID", feedbackID);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            // Check if feedback was successfully deleted
                            if (rowsAffected > 0)
                            {
                                Response.Write("Successfully deleted feedback.");
                            }
                            else
                            {
                                // Handle feedback deletion failure
                                Response.Write("Failed to delete feedback.");
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle exception
                            Response.Write("An error occurred: " + ex.Message);
                        }
                    }
                }
                else
                {
                    // Display message indicating that the user is not authorized to delete the feedback
                    Response.Write("You are not authorized to delete this feedback.");
                }
                GridView1.DataBind();
            }
        }

        // Method to check if the feedback belongs to the logged-in passenger
        private bool IsFeedbackBelongsToPassenger(string feedbackID, string passengerID)
        {
            // Query to check if the feedback belongs to the passenger
            string query = "SELECT COUNT(*) FROM Feedback WHERE fee_id = @feedbackID AND p_id = @passengerID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@feedbackID", feedbackID);
                command.Parameters.AddWithValue("@passengerID", passengerID);

                try
                {
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0; // If count > 0, feedback belongs to the passenger
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Response.Write("An error occurred while checking feedback ownership: " + ex.Message);
                    return false;
                }
            }
        }

    }
}