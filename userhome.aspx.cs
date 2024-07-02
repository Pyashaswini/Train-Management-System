using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Train_Management_System
{
    public partial class userhome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
                {
                    // Get passenger ID from session
                    string passengerID = Session["userid"].ToString();
                lblPassengerID.Text= passengerID;

        // Fetch passenger information from the database
        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        string query = "SELECT p_name, age, gender, phone FROM Passenger WHERE p_id = @passengerID";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@passengerID", passengerID);

                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                                // Display passenger information
                                txtName.Text = reader["p_name"].ToString();
                                txtAge.Text = reader["age"].ToString();
                                 txtGender.Text = reader["gender"].ToString();
                                 txtPhoneNumber.Text = reader["phone"].ToString();
}
                            else
                                {
                                    // Passenger not found
                                    Response.Write("Passenger information not found.");
                                }
                        }
                        catch (Exception ex)
                        {
                            // Handle the exception
                            // Log the exception or display an error message
                            Response.Write("An error occurred while retrieving passenger information: " + ex.Message);
                        }
                    }
                }
                else
{
    // Redirect to login page if user is not logged in
    Response.Redirect("userlogin.aspx");
}
            }
    }
}