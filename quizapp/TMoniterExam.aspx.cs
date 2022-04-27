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
    public partial class WebForm6 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["quizappDBCon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }




        protected void GridView_Button_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            //int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[6]);
            //lblStime.Text = (GridView1.DataKeys[rowIndex].Values[0]).ToString();
            //Response.Write("<script>alert('"+id+"');</script>");
            lblStime.Text = (GridView1.DataKeys[rowIndex].Values[3]).ToString();
            lblEtime.Text = (GridView1.DataKeys[rowIndex].Values[4]).ToString();
            lblmarks.Text = (GridView1.DataKeys[rowIndex].Values[5]).ToString() + "/" + (GridView1.DataKeys[rowIndex].Values[6]).ToString();
           // lblStime.Text = (GridView1.DataKeys[rowIndex].Values[0]).ToString();
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            UpdateEndExam();
        }

        void UpdateEndExam()
        {
            //Response.Write("<script>alert('Testing');</script>");
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE Exam SET Status='Exam Ended'    WHERE id=@id ", con);

             

                cmd.Parameters.AddWithValue("@id", examdropdown.SelectedItem.Value);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Exam Ended Successfully');</script>");
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}