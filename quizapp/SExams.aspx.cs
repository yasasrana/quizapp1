using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace quizapp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void GridView_Button_Click(object sender, EventArgs e)
        {



            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            string status=(GridView1.DataKeys[rowIndex].Values[1]).ToString();

            if(status== "Exam Ended")
            {
                Response.Write("<script>alert('Exam Ended');</script>");
            }
            else if (status == "Draft")
            {
                Response.Write("<script>alert('Exam Not published');</script>"); 
            
            }
            else
            {
                Session["Eid"] = (GridView1.DataKeys[rowIndex].Values[0]).ToString();
                Session["Ename"] = (GridView1.DataKeys[rowIndex].Values[2]).ToString();
                Session["duration"] = (GridView1.DataKeys[rowIndex].Values[3]).ToString();
                Response.Redirect("SingleExam1.aspx");
            }
        }


        public bool HasPassedFrom()
        {

            DateTime fromDate = DateTime.Now;

            String expireDate = "2022 - 04 - 27 10:10:57.000";
            DateTime a = Convert.ToDateTime(expireDate);
            return a - fromDate > TimeSpan.FromSeconds(1);
        }
    }
}