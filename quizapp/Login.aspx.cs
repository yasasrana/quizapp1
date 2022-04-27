using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace quizapp
{
    public partial class Login : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["quizappDBCon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from Users where username='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    string role = null;

                    while (dr.Read())
                    {


                        Response.Write("<script>alert('Successful login');</script>");
                        Session["username"] = dr.GetValue(1).ToString();
                        Session["Sid"] = dr.GetValue(0).ToString();
                        role = dr.GetValue(3).ToString();

                    }


                    if (role == "student")
                    {
                        Session["role"] = "Student";

                        Response.Redirect("SExams.aspx");
                    }

                     else if (role == "teacher")
                    {
                        Session["role"] = "Teacher";

                        Response.Redirect("TExams.aspx");
                    }

                    else
                    {
                        Response.Write("<script>alert('Check the role');</script>");
                    }



                }

                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");

                }
            }


            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");


            }



            


           
           
        }

        
    }
}