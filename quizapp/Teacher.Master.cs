using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace quizapp
{
    public partial class Teacher : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] != null)
            {

                if (Session["role"] != null)
                {

                    LinkButton5.Text = "Hello " + Session["role"].ToString();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }


        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["UserName"] = "";
            Session["role"] = "";



            Response.Redirect("Login.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            

            Response.Redirect("TExams.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
          

            Response.Redirect("TMoniterExam.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {


            Response.Redirect("TsingleExam.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {

        }
    }
}