<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SingleExam1.aspx.cs" Inherits="quizapp.SingleExam1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Exam</title>
   
	<link href="css1/style6.css" rel="stylesheet" type="text/css" />

      <%--bootstrap css--%>
    <link href="bootstrap/bootstrap_spacelab.min.css" rel="stylesheet" />
   
     <%--datatables css--%>
	<link href="data%20tables/css/jquery.dataTables.min.css" rel="stylesheet" />
     <%--font awesome css--%>
	<link href="font%20awesome/css/all.css" rel="stylesheet" />

    
     <%--custom css--%>
	<link href="css/customstylesheet.css" rel="stylesheet" />

     <%--jquery--%>
	<script src="bootstrap/js/jquery-3.5.1.slim.min.js"></script>
	 <%--popper js--%>
    <script src="bootstrap/js/popper.min.js"></script>
	
    <%--Datatables js--%>
    <script src="datatables/js/jquery.dataTables.min.js"></script>
     <%--bootstrap js--%>
    <script src="bootstrap/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
      <script>
        function startCountdown(timeLeft) {
            var interval = setInterval(countdown, 1000);
            update();


            function countdown() {
                if (--timeLeft > 0) {
                    update();
                } else {
                    clearInterval(interval);
                    update();
                    completed();
                }
            }

            function update() {
                hours = Math.floor(timeLeft / 3600);
                minutes = Math.floor((timeLeft % 3600) / 60);
                seconds = timeLeft % 60;

                document.getElementById('lblTimer').innerHTML = 'Time Left :' + hours + ':' + minutes + ':' + seconds;
            }

            function completed() {

                document.getElementById("<%=btnsubmit.ClientID %>").click();
            }
        }


      </script>

      
       
      
      <div class="container p-4">
      <div class="row">
         <div class="col mx-auto">
            <div class="card ">
               <div >
                   <div id="results" visible="false">
              
       
        
              <div class="text-center">
                  <asp:Label id="exm" visible="false" Text="Exam Results" runat="server" /><br />
          <asp:Label  ID="lblexam" class="h5" Text="" runat="server"   /><br />
              <asp:Label  ID="lblduration" class="h5" Text="" runat="server"   /><br />
            <asp:Label  ID="passed" class="h1" Text="Passed" runat="server"   visible="false"> </asp:Label><br />
            <asp:Label ID="points" class="h3" Text="A - 89 points" runat="server"  visible="false" /><br />
                  <asp:Button class="btn btn-primary btn-center " ID="btnclose" runat="server" Text="Close" OnClick="Button1_Click"  visible="false"/>
                     <asp:Label id="lblTimer" class="center" runat="server" />
                   <asp:Button class="btn btn-primary btn-center " ID="startbtn" runat="server" Text="start exam" OnClick="Button2_Click"  visible="true"/>
                   <asp:Button class="btn btn-warning btn-center " ID="backbtn" runat="server" Text="Go back" OnClick="Btnback_Click"  visible="true"/>
             </div>
  
    
   
                
              </div>
            <div>
           
            <asp:Repeater ID="Repeater1" runat="server" Visible="false" >  
                <ItemTemplate>  
                      
              
		
		

			<div class="card-body">
			<p class="ax2"><br><br>Q: <%#Eval("Qname")%></p>
			<div class="border2">
                 <table>
			    
                <tr><td><asp:RadioButton ID="RadioButton1" runat="server" Text='<%#Eval("Option1")%>' GroupName="rdexam"/></td></tr>
				<tr><td><asp:RadioButton ID="RadioButton2" runat="server" Text='<%#Eval("Option2")%>' GroupName="rdexam"/></td></tr>
				<tr><td><asp:RadioButton ID="RadioButton3" runat="server" Text='<%#Eval("Option3")%>' GroupName="rdexam"/></td></tr>
			    <tr><td><asp:RadioButton ID="RadioButton4" runat="server" Text='<%#Eval("Option4")%>' GroupName="rdexam"/></td></tr>
				</table>

			</div>

                <asp:Label ID="LabCorrectAns" Text='<%#Eval("Correct")%>' runat="server" Visible="false"/>
			</div>
                  <asp:Label ID="UserSelectedOption" Text="" runat="server" />

			

		
	
                </ItemTemplate>  
            </asp:Repeater>  

            
        </div>  
  </div>  <div class="text-center"><asp:Button ID="btnsubmit"  class="btn btn-danger m-4 " visible="false" Text="End Exam" runat="server" OnClick="btnsubmit_Click" /> </div>

          </div>
            </div>
         </div>
    </div>
    </form>
</body>
</html>
