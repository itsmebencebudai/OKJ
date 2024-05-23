using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace loginpage
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegConnectionString"].ConnectionString);
                    con.Open();

                    string checkuser = "SELECT COUNT(*) FROM User WHERE username = @username";

                    SqlCommand com = new SqlCommand(checkuser, con);
                    com.Parameters.AddWithValue("@username", user.Text);
                    int userCount = (int)com.ExecuteScalar();

                    if (userCount > 0)
                    {
                        Response.Write("User already exists");
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegConnectionString"].ConnectionString);
                con.Open();

                string insertQuery = "insert into User (username,email,password,country) values (@username,@email,@password,@country)";
                SqlCommand com = new SqlCommand(insertQuery, con);

                com.Parameters.AddWithValue("@username", user.Text);
                com.Parameters.AddWithValue("@email", email.Text);
                com.Parameters.AddWithValue("@password",password.Text);
                com.Parameters.AddWithValue("@country", country.SelectedItem.ToString());

                com.ExecuteNonQuery();
                Response.Write("Your registration was successful");
                Response.Redirect("admin.aspx");

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex);
            }
        }
    }
}