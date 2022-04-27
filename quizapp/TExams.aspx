<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="TExams.aspx.cs" Inherits="quizapp.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <link href="css1/style4.css" rel="stylesheet" type="text/css">
    <title>Exam info</title>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


       <div class="container-fluid">
      <p class="hedder4">Exams</p>
       
      <div class="stexam"> 
          <asp:TextBox class="p-2 m-2" placeholder="Search" runat="server" />
          <asp:Button class="btn-primary p-2 m-2" Text="Search" runat="server" />
      </div> 
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
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:quizappDBCon %>" SelectCommand="SELECT [Ename], [status], [lupdated] FROM [Exam]"></asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="Ename" HeaderText="Exam" SortExpression="Ename" />
                                <asp:BoundField DataField="lupdated" HeaderText="Last Updated" SortExpression="lupdated" />
                                <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                            </Columns>
                         </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
    </div></div></div>
</asp:Content>
