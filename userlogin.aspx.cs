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
    public partial class userlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string userID = textbox1.Text.Trim();
                string password = textbox2.Text.Trim();

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Passenger WHERE p_id = @user_id AND p_pass = @user_pass";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@user_id", userID);
                    cmd.Parameters.AddWithValue("@user_pass", password);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        Session["userid"] = userID;
                        // Admin credentials are correct
                        Response.Redirect("userhome.aspx"); // Redirect to admin dashboard page
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