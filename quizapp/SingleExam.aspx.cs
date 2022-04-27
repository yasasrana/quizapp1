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
    public partial class WebForm2 : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

           









            if (Session["Ename"] != null)
            {
                lblexam.Text = Session["Ename"].ToString();
                
            }
            else
            {
                Response.Redirect("SExams.aspx");
            }


            if (!IsPostBack)
            {
                BindRepeator();
            }


            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            Response.Redirect("SExams.aspx");
        }

        private void BindRepeator()
        {
            int a = int.Parse(Session["Eid"].ToString());
            string CS = ConfigurationManager.ConnectionStrings["quizappDBCon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {   
                SqlCommand cmd = new SqlCommand("spexamtb", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@eid", SqlDbType.Int).Value = a;
                con.Open();
                Repeater1.DataSource = cmd.ExecuteReader();
                Repeater1.DataBind();
                con.Close();
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            int result = 0;
            int count = 0;

            foreach(RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb1 = (RadioButton)ri.FindControl("RadioButton1");
                Label lblcorrectans = (Label)ri.FindControl("LabCorrectAns");

                count += 1;

                if (rb1.Checked == true)
                { 
                      if (rb1.Text.Equals(lblcorrectans.Text))
                    {
                        Label Userselectedanswer = (Label)ri.FindControl("UserSelectedOption");
                        Userselectedanswer.Text = "The selected answer is Correct";
                        Userselectedanswer.ForeColor = System.Drawing.Color.Green;
                        result += 1;
                    }
                      else
                    {
                        Label Wronganswer = (Label)ri.FindControl("UserSelectedOption");
                        Wronganswer.Text = "The selected answer is Wrong";
                        Wronganswer.ForeColor = System.Drawing.Color.Red;
                    }

                }
            
            
            }


            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb2 = (RadioButton)ri.FindControl("RadioButton2");
                Label lblcorrectans = (Label)ri.FindControl("LabCorrectAns");
                
                if (rb2.Checked == true)
                {
                    if (rb2.Text.Equals(lblcorrectans.Text))
                    {
                        Label Userselectedanswer = (Label)ri.FindControl("UserSelectedOption");
                        Userselectedanswer.Text = "The selected answer is Correct";
                        Userselectedanswer.ForeColor = System.Drawing.Color.Green;
                        result += 1;
                    }
                    else
                    {
                        Label Wronganswer = (Label)ri.FindControl("UserSelectedOption");
                        Wronganswer.Text = "The selected answer is Wrong";
                        Wronganswer.ForeColor = System.Drawing.Color.Red;
                    }

                }


            }

            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb3 = (RadioButton)ri.FindControl("RadioButton3");
                Label lblcorrectans = (Label)ri.FindControl("LabCorrectAns");
               
                if (rb3.Checked == true)
                {
                    if (rb3.Text.Equals(lblcorrectans.Text))
                    {
                        Label Userselectedanswer = (Label)ri.FindControl("UserSelectedOption");
                        Userselectedanswer.Text = "The selected answer is Correct";
                        Userselectedanswer.ForeColor = System.Drawing.Color.Green;
                        result += 1;
                    }
                    else
                    {
                        Label Wronganswer = (Label)ri.FindControl("UserSelectedOption");
                        Wronganswer.Text = "The selected answer is Wrong";
                        Wronganswer.ForeColor = System.Drawing.Color.Red;
                    }

                }


            }

            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb4 = (RadioButton)ri.FindControl("RadioButton4");
                Label lblcorrectans = (Label)ri.FindControl("LabCorrectAns");
               
                if (rb4.Checked == true)
                {
                    if (rb4.Text.Equals(lblcorrectans.Text))
                    {
                        Label Userselectedanswer = (Label)ri.FindControl("UserSelectedOption");
                        Userselectedanswer.Text = "The selected answer is Correct";
                        Userselectedanswer.ForeColor = System.Drawing.Color.Green;
                        result += 1;
                    }
                    else
                    {
                        Label Wronganswer = (Label)ri.FindControl("UserSelectedOption");
                        Wronganswer.Text = "The selected answer is Wrong";
                        Wronganswer.ForeColor = System.Drawing.Color.Red;
                    }

                }


            }
            float avg = result / count * 100;
            int avg1 = Convert.ToInt32(avg);
            string pass;
            if(avg1>50)
              {  pass = "passed"; }
            else { pass = "fail"; }
            points.Text = avg1.ToString()+" Points";
            passed.Text = pass;
            points.Visible = true;
            passed.Visible = true;
            btnsubmit.Visible = false;
            btnclose.Visible = true;
            exm.Visible = true;
            lblTimer.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(),
               "text", "startCountdown(10)", true);

        }
    }
}