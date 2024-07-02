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
    public partial class adminstaff : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!checkIfStaffExists())
            {
                Response.Write("<script>alert('Staff with this ID does not Exist.');</script>");
            }
            else
            {
                DisplayStaffInfo();
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfStaffExistsAndNotAssigned())
            {
                AssignStaff();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfStaffExists())
            {
                DeleteStaff();
            }
        }

        private void AssignStaff()
        {
            int staffId = int.Parse(TextBox1.Text.Trim());
            int trainId = int.Parse(TextBox5.Text.Trim()); // Assuming TextBox5 contains the train ID
            string role = TextBox4.Text.Trim(); // Assuming TextBox4 contains the role

            using (SqlConnection connection = new SqlConnection(strcon))
            {
                string query = "UPDATE Staff SET train_id = @trainId, role = @role WHERE s_id = @staffId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@trainId", trainId);
                    command.Parameters.AddWithValue("@role", role);
                    command.Parameters.AddWithValue("@staffId", staffId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            GridView1.DataBind();
        }

        private void DeleteStaff()
        {
            int staffId = int.Parse(TextBox1.Text.Trim());

            using (SqlConnection connection = new SqlConnection(strcon))
            {
                string query = "DELETE FROM Staff WHERE s_id = @staffId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@staffId", staffId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            GridView1.DataBind();
        }

        private bool checkIfStaffExists()
        {
            using (SqlConnection connection = new SqlConnection(strcon))
            {
                string query = "SELECT COUNT(*) FROM Staff WHERE s_id = @staffId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@staffId", TextBox1.Text.Trim());
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool checkIfStaffExistsAndNotAssigned()
        {
            int staffId = int.Parse(TextBox1.Text.Trim());

            using (SqlConnection connection = new SqlConnection(strcon))
            {
                // Check if the staff exists
                string staffQuery = "SELECT COUNT(*) FROM Staff WHERE s_id = @staffId";
                using (SqlCommand staffCommand = new SqlCommand(staffQuery, connection))
                {
                    staffCommand.Parameters.AddWithValue("@staffId", staffId);
                    connection.Open();
                    int staffCount = (int)staffCommand.ExecuteScalar();

                    if (staffCount == 0)
                    {
                        // Staff does not exist
                        Response.Write("<script>alert('Staff with this ID does not exist.');</script>");
                        return false;
                    }
                }

                // Check if the staff is already assigned
                string assignedQuery = "SELECT train_id FROM Staff WHERE s_id = @staffId AND train_id IS NOT NULL";
                using (SqlCommand assignedCommand = new SqlCommand(assignedQuery, connection))
                {
                    assignedCommand.Parameters.AddWithValue("@staffId", staffId);
                    object result = assignedCommand.ExecuteScalar();
                    if (result != null)
                    {
                        // Staff is already assigned
                        Response.Write("<script>alert('Staff is already assigned to a train.');</script>");
                        return false;
                    }
                }


                return true;
            }
        }
        private void DisplayStaffInfo()
        {
            try
            {
                // Assuming TextBox1 is used to input the staff ID
                int staffId = Convert.ToInt32(TextBox1.Text.Trim());

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT s_name, role, train_id FROM Staff WHERE s_id = @staffId", con);
                    cmd.Parameters.AddWithValue("@staffId", staffId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Display staff information in the textboxes
                        TextBox2.Text = reader["s_name"].ToString();
                        TextBox4.Text = reader["role"].ToString();
                        TextBox5.Text = reader["train_id"].ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('Staff with this ID was not found.');</script>");
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error displaying staff information: " + ex.Message + "');</script>");
            }
        }

    }
}