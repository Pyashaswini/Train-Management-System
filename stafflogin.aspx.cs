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
    public partial class WebForm2 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Staff WHERE s_id = @staff_id AND S_pass = @staff_pass";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@staff_id", textbox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@staff_pass", textbox2.Text.Trim());

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {

                        // Admin credentials are correct
                        Response.Redirect("StaffMaintenanace.aspx"); // Redirect to admin dashboard page
                    }
                    else
                    {
                        // Admin credentials are incorrect
                        Response.Write("<script>alert('Invalid staff ID or password');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('An error occurred: " + ex.Message.Replace("'", "\\'") + "');", true);
            }
        }


    }
}