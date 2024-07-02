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
    public partial class usersignup : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            try
            {
                string p_name = txtName.Text.Trim();
                int age = Convert.ToInt32(txtAge.Text.Trim());
                string gender = rbtnFemale.Checked ?"F" : "M";
                string phone = txtPhone.Text.Trim();
                string p_pass = txtPassword.Text.Trim();
                string repeatPassword = txtRepeatPassword.Text.Trim();

                // Validate input fields
                if (string.IsNullOrEmpty(p_name) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(p_pass) || string.IsNullOrEmpty(repeatPassword))
                {
                    Response.Write("<script>alert('All fields are required. Please fill in all the fields.');</script>");
                    return;
                }

                // Check if passwords match
                if (p_pass != repeatPassword)
                {
                    Response.Write("<script>alert('Passwords do not match. Please re-enter your passwords.');</script>");
                    return;
                }

                // Hash the password (not implemented in this example)

                // Insert into Passenger table
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string query = "INSERT INTO Passenger (p_name, age, gender, phone, p_pass) VALUES (@p_name, @age, @gender, @phone, @p_pass); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@p_name", p_name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@p_pass", p_pass);

                    int p_id = Convert.ToInt32(cmd.ExecuteScalar());

                    if (p_id > 0)
                    {
                        ShowConfirmMessageBox(p_id);
                       
                    }
                    else
                    {
                        Response.Write("<script>alert('Failed to register. Please try again later.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('An error occurred: {ex.Message.Replace("'", "\\'")}');</script>");
            }
        }
        private void ShowConfirmMessageBox(int p_id)
        {
            string message = $"Registration successful! Your Passenger ID is {p_id}. Do you want to proceed to login?";
            string script = $@"<script type='text/javascript'>
                        var confirmResult = confirm('{message}');
                        if (confirmResult) {{
                            window.location.href = 'userlogin.aspx';
                        }}
                        </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "ConfirmMessageBox", script);
        }


    }
}