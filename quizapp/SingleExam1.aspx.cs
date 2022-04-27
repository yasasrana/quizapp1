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
    public partial class SingleExam1 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["quizappDBCon"].ConnectionString;
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

            lblduration.Text = "Exam Duration :" + Session["duration"].ToString() + "mins";

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

        void createSession()
        {
            //Response.Write("<script>alert('Testing');</script>");
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO sessions (Eid,Stuid,sStart) values(@Eid,@stuid,@sStart)", con);
                cmd.Parameters.AddWithValue("@Eid", Session["Eid"]);
                cmd.Parameters.AddWithValue("@stuid", Session["Sid"]);
                cmd.Parameters.AddWithValue("@sStart", DateTime.Now.ToString("HH:mm:ss"));

                // cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                // cmd.Parameters.AddWithValue("@department", DropDownList1.SelectedItem.Value);
                // cmd.Parameters.AddWithValue("@intake", DropDownList2.SelectedItem.Value);

                cmd.ExecuteNonQuery();
                con.Close();
                sessionid();
                Response.Write("<script>alert('Session Started');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            float result = 0;
            float count = 0;

            foreach (RepeaterItem ri in Repeater1.Items)
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
            
            string pass;
            if (avg > 40)
            { pass = "passed";
                points.Text = avg + " Points";
                passed.Text = pass;
                passed.ForeColor = System.Drawing.Color.ForestGreen;
            }
            else { pass = "fail";
                points.Text = avg + " Points";
                passed.Text = pass;
                passed.ForeColor = System.Drawing.Color.Red;
            }

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE sessions SET   AnsQ=@AnsQ,TotQ=@TotQ  ,Results=@Results,sEnd=@sEnd     WHERE Sessionid=@Sessionid ", con);

                cmd.Parameters.AddWithValue("@AnsQ", result);
                cmd.Parameters.AddWithValue("@sEnd", DateTime.Now.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("@TotQ", count);
                cmd.Parameters.AddWithValue("@Results", avg);
                cmd.Parameters.AddWithValue("@Sessionid", Session["Sessionid"]);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Exam Completed Successfully');</script>");


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

            points.Visible = true;
            passed.Visible = true;
            btnsubmit.Visible = false;
            btnclose.Visible = true;
            exm.Visible = true;
            lblTimer.Visible = false;
        }


        //void Updatepublish()
        //{
        //    //Response.Write("<script>alert('Testing');</script>");
        //    try
        //    {
        //        SqlConnection con = new SqlConnection(strcon);
        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        SqlCommand cmd = new SqlCommand("UPDATE sessions SET sStart=@sStart , sEnd=@sEnd, AnsQ=@AnsQ,TotQ=@TotQ  ,Results=@Results     WHERE id=@id ", con);

        //        cmd.Parameters.AddWithValue("@sStart", Examdurationdrp.SelectedItem.Value);

        //        cmd.Parameters.AddWithValue("@id", Examid.SelectedItem.Value);


        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        Response.Write("<script>alert('Exam Published Successfully');</script>");
                


        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script>alert('" + ex.Message + "');</script>");
        //    }
        //}

        void sessionid()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from sessions where Eid ='" + Session["Eid"] + "' and stuid='" + Session["Sid"] + "'  ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        Session["Sessionid"] = dr.GetValue(2).ToString();

                        // Session["status"] = dr.GetValue(7).ToString();
                    }

                }
                else
                {
                    Response.Write("<script>alert('NO Exam Selected');</script>");
                }

            }
            catch (Exception ex)
            {

            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            int a = int.Parse(Session["duration"].ToString());
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(),
               "text", "startCountdown("+a+")", true);
            createSession();
            
            startbtn.Visible = false;
            btnsubmit.Visible = true;
            Repeater1.Visible = true;
            lblduration.Visible = false;
            backbtn.Visible = false;




        }

        protected void Btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("SExams.aspx");
        }


        
         public bool HasPassedFrom()
          {

            DateTime fromDate = DateTime.Now;

            String expireDate = "2022 - 04 - 27 10:10:57.000";
              DateTime  a= Convert.ToDateTime(expireDate);
            return a - fromDate > TimeSpan.FromSeconds(1);
           }
        
    }
}