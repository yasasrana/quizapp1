<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="SExamResults.aspx.cs" Inherits="quizapp.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="css1/style5.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="results">
     <p class="hedder5">Exam Results</p>
       
        
        <div class="text-center">
        <div class="Stu_Result">
            <div><h4>Exam completed</h4></div> 
        <div class="pass"><h1>Passed</h1></div>
        <div class="point"><h3>A - 89 points</h3></div>
    </div>
  
    
   
        <asp:Button class="btn btn-success btn-center " ID="Button2" runat="server" Text="Close" OnClick="Button1_Click" />
    </div></div>
     

</asp:Content>
