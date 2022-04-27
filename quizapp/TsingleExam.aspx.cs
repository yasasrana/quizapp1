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
    public partial class WebForm5 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["quizappDBCon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

         //   GridView1.DataBind();

            //fetchdatadropdown();




        }


        protected void submit_Click(object sender, EventArgs e)
        {
            if (checkQuestionexist())
            {
                UpdateQuestion();
                formclear();
                Updatepublish1();
            }
            else
            {
                createQuestion();
                formclear();
                Updatepublish1();

            }
           


        }

        protected void publishbtn_Click(object sender, EventArgs e)
        {

            Updatepublish();
            Updatepublish1();


        }

        protected void addquestion_Click(object sender, EventArgs e)
        {
            if (checkexamNAme())
            {
                createExam();
                formclear();
            }
            else
            {
                Response.Write("<script>alert('Exam name already exist');</script>");

            }


        }


        void fetchdatadropdown()
        {
            SqlConnection con = new SqlConnection(strcon);
            string com = "Select  id,ename from exam";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            Examid.DataSource = dt;
            Examid.DataBind();
            Examid.DataTextField = "ename";
            Examid.DataValueField = "id";
            Examid.DataBind();
        }


        void createQuestion()
        {
            if (validation())
            {//Response.Write("<script>alert('Testing');</script>");
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("INSERT INTO question (Eid,Qname,Option1,Option2,Option3,Option4,Correct) values(@Eid,@Qname,@Option1,@Option2,@Option3,@Option4,@Correct)", con);
                    cmd.Parameters.AddWithValue("@Eid", Examid.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Qname", txtQname.Text.Trim());
                    cmd.Parameters.AddWithValue("@Option1", txta1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Option2", txta2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Option3", txta3.Text.Trim());
                    cmd.Parameters.AddWithValue("@Option4", txta4.Text.Trim());
                    cmd.Parameters.AddWithValue("@Correct", txtcorrect.Text.Trim());
                    // cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                    // cmd.Parameters.AddWithValue("@department", DropDownList1.SelectedItem.Value);
                    // cmd.Parameters.AddWithValue("@intake", DropDownList2.SelectedItem.Value);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    CheckExamID();
                    GridView1.DataBind();
                    //fetchdatadropdown();
                    Response.Write("<script>alert('Question Successfully Added');</script>");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Fill the missing fields');</script>");
            }
        }

        void UpdateQuestion()
        {
            if (validation())
            {
                try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE Question SET  Option1=@Option1 ,Option2=@Option2,Option3=@Option3,Option4=@Option4,Correct=@Correct  WHERE Qname=@Qname ", con);

                cmd.Parameters.AddWithValue("@Option1", txta1.Text.Trim());
                cmd.Parameters.AddWithValue("@Option2", txta2.Text.Trim());
                cmd.Parameters.AddWithValue("@Option3", txta3.Text.Trim());
                cmd.Parameters.AddWithValue("@Option4", txta4.Text.Trim());
                cmd.Parameters.AddWithValue("@Correct", txtcorrect.Text.Trim());
                cmd.Parameters.AddWithValue("@Qname", txtQname.Text.Trim());





                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Question Updated Successfully');</script>");
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

            }
            else
            {
                Response.Write("<script>alert('Fill the missing fields');</script>");
            }
        }
        void Updatepublish()
        {
            if (validationpublished())
            {//Response.Write("<script>alert('Testing');</script>");
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE Exam SET Status='published' , duration=@duration lupdated=@lupdated  WHERE id=@id ", con);

                    cmd.Parameters.AddWithValue("@duration", Examdurationdrp.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@lupdated", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@id", Examid.SelectedItem.Value);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Exam Published Successfully');</script>");
                    GridView1.DataBind();


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please select Exam Duration');</script>");
            }
        }

        void Updatepublish1()
        {
           //Response.Write("<script>alert('Testing');</script>");
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE Exam SET  lupdated=@lupdated  WHERE id=@id ", con);

                   
                    cmd.Parameters.AddWithValue("@lupdated", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@id", Examid.SelectedItem.Value);


                cmd.ExecuteNonQuery();
                    con.Close();
                   
                    GridView1.DataBind();


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            
        }
        void createExam()
        {
            if (validationExm())
            {//Response.Write("<script>alert('Testing');</script>");
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("INSERT INTO Exam (Ename) values(@Ename)", con);
                    cmd.Parameters.AddWithValue("@Ename", txtexam.Text.Trim());
                    // cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                    // cmd.Parameters.AddWithValue("@department", DropDownList1.SelectedItem.Value);
                    // cmd.Parameters.AddWithValue("@intake", DropDownList2.SelectedItem.Value); 

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('Exam name Successfully Added');</script>");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }

            else
            {
                Response.Write("<script>alert('Exam name field cannot be Empty');</script>");

            }
        }

        bool checkQuestionexist()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from Question where Qname ='" + txtQname.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        bool checkexamNAme()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from Exam where Ename ='" + txtexam.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    return false;

                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        void CheckExamID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from Exam where id ='" + Examid.SelectedItem.Value + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        txtexam.Text = dr.GetValue(1).ToString();

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

       

        void fetchdropdown()
        {

            SqlConnection con = new SqlConnection(strcon);
            string com = "Select * from Exam";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            Examid.DataSource = dt;
            Examid.DataBind();
            Examid.DataTextField = "ename";
            Examid.DataValueField = "id";
            Examid.DataBind();
        }

       void formclear()
        {

            txta1.Text = "";
            txta2.Text = "";
            txta3.Text = "";
            txta4.Text = "";
            txtcorrect.Text = "";
            txtexam.Text = "";
            txtQname.Text = "";
        }


        protected void GridView_Button_Click(object sender, EventArgs e)
        {



            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            txtQname.Text = (GridView1.DataKeys[rowIndex].Values[1]).ToString();
            txta1.Text = (GridView1.DataKeys[rowIndex].Values[2]).ToString();
            txta2.Text = (GridView1.DataKeys[rowIndex].Values[3]).ToString();
            txta3.Text = (GridView1.DataKeys[rowIndex].Values[4]).ToString();
            txta4.Text = (GridView1.DataKeys[rowIndex].Values[5]).ToString();
            txtcorrect.Text = (GridView1.DataKeys[rowIndex].Values[6]).ToString();

        }

        bool validation()
        {
            if(txtQname.Text=="" || txta1.Text == ""|| txta2.Text == ""|| txta3.Text == "" || txta4.Text == "" || txtcorrect.Text == "")
            {
                return false;
            }

            else 
            {
                return true;
            }
        }

        bool validationpublished()
        {
            if (Examdurationdrp.SelectedValue== "Exam Duration")
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        bool validationExm()
        {
            if (txtexam.Text == "")
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        protected void GridView_delButton_Click(object sender, EventArgs e)
        {



            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

           string Eid = (GridView1.DataKeys[rowIndex].Values[0]).ToString();
            string Qid = (GridView1.DataKeys[rowIndex].Values[7]).ToString();






                     try
                    {
                        SqlConnection con = new SqlConnection(strcon);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        SqlCommand cmd = new SqlCommand("DELETE from Question WHERE Eid='" + Eid+ "' and Qid='" + Qid + "' ", con);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Question Question Successfully');</script>");
                        
                        GridView1.DataBind();
                         formclear();

                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }

                
            

        }





    }
}