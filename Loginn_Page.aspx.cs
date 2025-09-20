using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;

namespace Login_Page_Creation
{
    public partial class Loginn_Page : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=shopping; Integrated Security=true";

            if (Session["isloggedin"] != null && (bool)Session["isloggedin"])
            {
                lblUser.Text = Session["Name"].ToString();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // open connection first
            if (con.State == ConnectionState.Closed)
                con.Open();

            // check session status
            if (Session["isloggedin"] == null || !(bool)Session["isloggedin"])
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Cid, Name, Password FROM Customers WHERE Name=@name";
                cmd.Parameters.AddWithValue("@name", txtName1.Text.Trim());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if (dr["password"].ToString() == txtPwd.Text.Trim())
                    {
                        Session["isloggedin"] = true;
                        Session["cid"] = dr["cid"];
                        Session["Name"] = dr["Name"];
                        lblUser.Text = dr["Name"].ToString();
                        lblMsg.Text = "Your Are Successfully logged in dear!!!";
                        lblMsg.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblUser.Text = "Invalid password";
                        lblUser.ForeColor = Color.Red;
                    }
                }
                else
                {
                    lblUser.Text = "User not found";
                    lblUser.ForeColor = Color.Red;
                }

                dr.Close();
            }
            else
            {
                lblUser.Text = "Already logged in as " + Session["cname"];
                lblUser.ForeColor = Color.Yellow;
            }

            con.Close();
        }
    }
}
