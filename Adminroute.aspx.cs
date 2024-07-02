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
    public partial class Adminroute : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfTimeConflict())
            {
                Response.Write("<script>alert('Train already on route.');</script>");
            }
            else
            {
                addNewRoute();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            DeleteRoute();
        }

        private bool checkIfTimeConflict()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Train_Route WHERE train_id=@train_id AND ((arrival >= @arrival AND arrival <= @departure) OR (departure >= @arrival AND departure <= @departure))", con);
                cmd.Parameters.AddWithValue("@train_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@arrival", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@departure", TextBox5.Text.Trim());

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                // If count > 0, there is a time conflict
                return count > 0;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return true; // Return true to prevent adding the station in case of an error
            }
        }

        private void addNewRoute()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text) || string.IsNullOrWhiteSpace(TextBox3.Text) || string.IsNullOrWhiteSpace(TextBox4.Text) || string.IsNullOrWhiteSpace(TextBox5.Text))
                {
                    Response.Write("<script>alert('Please fill in all fields');</script>");
                    return;
                }

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Train_Route (train_id, dep_station_id, arr_station_id, arrival, departure) VALUES (@train_id, @dep_station_id, @arr_station_id, @arrival, @departure)", con);
                cmd.Parameters.AddWithValue("@train_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dep_station_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@arr_station_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@arrival", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@departure", TextBox5.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Route added successfully');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void DeleteRoute()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                // Check if the required textboxes are empty
                if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text) || string.IsNullOrWhiteSpace(TextBox3.Text))
                {
                    Response.Write("<script>alert('Please fill in all required fields');</script>");
                    return;
                }

                // Check if a route with the given details exists
                SqlCommand cmdCheckRoute = new SqlCommand("SELECT COUNT(*) FROM Train_Route WHERE train_id=@train_id AND dep_station_id=@dep_station_id AND arr_station_id=@arr_station_id", con);
                cmdCheckRoute.Parameters.AddWithValue("@train_id", TextBox1.Text.Trim());
                cmdCheckRoute.Parameters.AddWithValue("@dep_station_id", TextBox2.Text.Trim());
                cmdCheckRoute.Parameters.AddWithValue("@arr_station_id", TextBox3.Text.Trim());

                int routeCount = Convert.ToInt32(cmdCheckRoute.ExecuteScalar());
                if (routeCount == 0)
                {
                    Response.Write("<script>alert('No route found with the provided details');</script>");
                    return;
                }

                // Delete the route
                SqlCommand cmdDeleteRoute = new SqlCommand("DELETE FROM Train_Route WHERE train_id=@train_id AND dep_station_id=@dep_station_id AND arr_station_id=@arr_station_id", con);
                cmdDeleteRoute.Parameters.AddWithValue("@train_id", TextBox1.Text.Trim());
                cmdDeleteRoute.Parameters.AddWithValue("@dep_station_id", TextBox2.Text.Trim());
                cmdDeleteRoute.Parameters.AddWithValue("@arr_station_id", TextBox3.Text.Trim());

                int rowsAffected = cmdDeleteRoute.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    Response.Write("<script>alert('Route deleted successfully');</script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Failed to delete route');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

    }
}