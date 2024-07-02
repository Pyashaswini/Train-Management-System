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
    public partial class adminmaintainance : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!checkIfMaintenanceExists())
            {
                Response.Write("<script>alert('maintenance with this ID does not exist Exist.');</script>");
            }
            else
            {
                Display();
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                int maintenanceId = int.Parse(TextBox1.Text.Trim());
                bool newStatus = Status.Checked;

                // Update the status in the database
                UpdateMaintenanceStatus(maintenanceId, newStatus);

                // Rebind the data to the GridView
                GridView1.DataBind();

                // Display a success message
                Response.Write("<script>alert('Maintenance status updated successfully.');</script>");
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                Response.Write("<script>alert('Error updating maintenance status: " + ex.Message + "');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the maintenance ID from the TextBox or any other source
                int maintenanceId = int.Parse(TextBox1.Text.Trim());

                // Call the method to delete the maintenance record
                DeleteMaintenance(maintenanceId);

            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                Response.Write("<script>alert('Error deleting maintenance record: " + ex.Message + "');</script>");
            }
        }


        private bool CheckIfMaintenanceExists(int maintenanceId)
        {
            try
            {
                // Create a SqlConnection using the connection string
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    // Open the connection
                    con.Open();

                    // Create a SqlCommand to check if the maintenance record exists
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Maintenance WHERE m_id = @maintenanceId", con);
                    cmd.Parameters.AddWithValue("@maintenanceId", maintenanceId);

                    // Execute the command and get the result
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // If count > 0, a maintenance record with the provided ID exists
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., display an error message)
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false; // Return false in case of an error
            }
        }

        private void DeleteMaintenance(int maintenanceId)
        {
            try
            {
                // Check if the maintenance record exists
                if (!CheckIfMaintenanceExists(maintenanceId))
                {
                    Response.Write("<script>alert('Maintenance record with this ID does not exist.');</script>");
                    return;
                }

                // Construct the SQL query to delete the maintenance record
                string deleteQuery = "DELETE FROM Maintenance WHERE m_id = @maintenanceId";

                // Create a SqlConnection using the connection string
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    // Open the connection
                    con.Open();

                    // Create a SqlCommand to execute the delete query
                    SqlCommand cmd = new SqlCommand(deleteQuery, con);
                    cmd.Parameters.AddWithValue("@maintenanceId", maintenanceId);

                    // Execute the delete query
                    cmd.ExecuteNonQuery();
                }

                // Rebind the data source for the GridView to reflect the changes
                GridView1.DataBind();

                // Display a success message
                Response.Write("<script>alert('Maintenance record deleted successfully.');</script>");
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                Response.Write("<script>alert('Error deleting maintenance record: " + ex.Message + "');</script>");
            }
        }


        private void Display()
        {
            try
            {
                // Create a SqlConnection using the connection string
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    // Open the connection
                    con.Open();

                    // Create a SqlCommand to select the status of the maintenance record
                    SqlCommand cmd = new SqlCommand("SELECT status FROM Maintenance WHERE m_id = @maintenanceId", con);
                    cmd.Parameters.AddWithValue("@maintenanceId", TextBox1.Text.Trim()); // Assuming TextBox1 contains the maintenance ID entered by the user

                    // Execute the command and get the status
                    bool status = Convert.ToBoolean(cmd.ExecuteScalar());

                    // Close the connection
                    con.Close();

                    // Set the Checked property of the Status checkbox based on the status retrieved from the database
                    Status.Checked = status;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., display an error message)
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        private bool checkIfMaintenanceExists()
        {
            try
            {
                // Create a SqlConnection using the connection string
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    // Open the connection
                    con.Open();

                    // Create a SqlCommand to check if the maintenance record exists
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Maintenance WHERE m_id = @maintenanceId", con);
                    cmd.Parameters.AddWithValue("@maintenanceId", TextBox1.Text.Trim()); // Assuming TextBox1 contains the maintenance ID entered by the user

                    // Execute the command and get the result
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // Close the connection
                    con.Close();

                    // If count > 0, a maintenance record with the provided ID exists
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., display an error message)
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return true; // Return true to prevent further processing in case of an error
            }
        }



        private void UpdateMaintenanceStatus(int maintenanceId, bool newStatus)
        {
            string updateQuery = "UPDATE Maintenance SET status = @newStatus WHERE m_id = @maintenanceId";
           

            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@newStatus", newStatus);
                cmd.Parameters.AddWithValue("@maintenanceId", maintenanceId);
                cmd.ExecuteNonQuery();
            }
        }


    }

}