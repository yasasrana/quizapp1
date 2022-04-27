<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="quizapp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="agency/css/styles.css" rel="stylesheet" />
         <link href="bootstrap/bootstrap_spacelab.min.css" rel="stylesheet" />
         <script src="bootstrap/js/bootstrap.min.js"></script>
    <title>Login</title>
</head>
<body  >
   

    
    <form id="form1" runat="server">
       
    
    <div class="container">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div "card text-white bg-primary mb-3">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h3> Quiz App Login</h3>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Username</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Enter Your Username"></asp:TextBox>
                        </div>
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Enter Your Password" TextMode="Password"></asp:TextBox>
                        </div>
                         
                        <div class="form-group">
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                        </div>
                       
                     </div>
                  </div>
               </div>
            

      </div>
   </div>
      </div></div>
        </div></div>
    </form>
</body>
</html>
