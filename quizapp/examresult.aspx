<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="examresult.aspx.cs" Inherits="quizapp.examresult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>results</title>
     <link href="css1/style5.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
       <p class="hedder5">Exam Results</p>
        <div class="sidebar"></div>
        <nav></nav>
        
        <div class="Stu_Result">
            <div><h4>Exam completed</h4></div> 
        <div class="pass"><h1>Passed</h1></div>
        <div class="point"><h3>A - 89 points</h3></div>
    </div>
    <div>
        <div class="question">
            <div><h4>Questions</h4></div>
        
        <div class="question1">
            <div><h4>Question 1</h4>            </div>
        <div class="question2">
            <div><h4>Question 2 </h4></div>
        <div class="question3">
            <h4>Question 3</h4>
            <table class="tab">
                <tr><td><b>Correct</b></td></tr>
            </table>
        </div>
    </div>
    <div><button class="close">Close</button></div>
    </form>
</body>
</html>
