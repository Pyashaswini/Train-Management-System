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
    public partial class StaffMaintenanace : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set the default scheduled date to today
                Calendar1.SelectedDate = DateTime.Today;
                TextBoxContent.Text = ""; // Clear TextBoxContent
                TextBox1.Text = ""; // Clear TextBox1
                TextBox2.Text = ""; // Clear TextBox2
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate <= DateTime.Today)
            {
                Response.Write("<script>alert('Scheduled date must be after today');</script>");
                return;
            }

            try
            {
                

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string query = "INSERT INTO Maintenance (train_id, date, content, status, schedule, s_id) VALUES (@trainId, @date, @content, @status, @schedule, @staffId)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@trainId", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@content", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@status", 0); // Default status
                    cmd.Parameters.AddWithValue("@schedule", Calendar1.SelectedDate);
                    cmd.Parameters.AddWithValue("@staffId", TextBoxContent.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('added maintenance record');</script>");
                        // Data inserted successfully, refresh GridView
                        GridView1.DataBind();
                        // Clear input fields
                        TextBoxContent.Text = "";
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                    }
                    else
                    {
                        // Data not inserted
                        Response.Write("<script>alert('Failed to add maintenance record');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Response.Write($"<script>alert('An error occurred: {ex.Message.Replace("'", "\\'")}');</script>");
            }
        }


    }
}