<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="SExams.aspx.cs" Inherits="quizapp.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css1/style4.css" rel="stylesheet" type="text/css">
    <title>Student Exam</title>
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    
    
      <div class="container p-5">
      <div class="row">
         <div class="col-mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Exams</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:quizappDBCon %>" SelectCommand="SELECT [Ename], [duration], [status], [id] FROM [Exam] where (([status]='published') OR ([status]='Exam Ended'))"></asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"  DataKeyNames="id,status,Ename,duration" >
                            
                            
                            <Columns>
                                <asp:BoundField DataField="Ename" HeaderText="Ename" SortExpression="Ename" />
                                <asp:BoundField DataField="duration" HeaderText="duration" SortExpression="duration" />

                                <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" Visible="false"/>
                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false" />
                                 <asp:TemplateField>
                                  <ItemTemplate>
                                <asp:Button class="btn btn-info" Text="select" runat="server" OnClick="GridView_Button_Click" />
                              </ItemTemplate>
                             </asp:TemplateField>
                            </Columns>
                             </asp:GridView>
                     </div>
                  </div>
                          </div>
            </div>
         </div>
    </div></div>
</asp:Content>
