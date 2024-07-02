using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Train_Management_System
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Login with admin pass
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Admin WHERE a_id = @admin_id AND a_pass = @admin_pass";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@admin_id", textbox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@admin_pass", textbox2.Text.Trim());

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // Admin credentials are correct
                        Response.Redirect("adminhome.aspx"); // Redirect to admin dashboard page
                    }
                    else
                    {
                        // Admin credentials are incorrect
                        Response.Write("<script>alert('Invalid admin ID or password');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('An error occurred: " + ex.Message.Replace("'", "\\'") + "');", true);
            }
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

