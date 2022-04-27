<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true"  EnableEventValidation="false"  CodeBehind="TsingleExam.aspx.cs" Inherits="quizapp.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

	 <title>Single Exam</title>
      <link href="css1/style3.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="container-fluid m-4">
      <div class="row">
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     

      
	
    
	
	</div>
  
	  <div class="row">
          
               
			  
          <asp:DropDownList id="Examid" class="p-2 m-1 w-25 h-25" runat ="server" DataTextField="Ename" DataValueField="id" AutoPostBack="True" DataSourceID="SqlDataSource1"/>
            
          
         
          
		  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:quizappDBCon %>" SelectCommand="SELECT [id], [Ename] FROM [Exam]"></asp:SqlDataSource>
            
          
         
          
		  <asp:TextBox id="txtexam" class=" ml-auto m-3  " placeholder="Exam Name" runat ="server" />
	  <asp:Button class="btn btn-warning  ml-auto m-3 " ID="addqbtn" runat="server" Text="AddExam" OnClick="addquestion_Click"  />
  
</div>
		
 
                  
		<div class="row">
	
		
                     <div class="col">
                  <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowSorting="True"  DataSourceID="SqlDataSource2"  DataKeyNames="Eid,Qname,Option1,Option2,Option3,Option4,Correct,Qid" >
                      <Columns>
                          <asp:TemplateField>
                               <ItemTemplate>
                                <asp:Button class="btn btn-info" Text="select" runat="server" OnClick="GridView_Button_Click" />
                                <asp:Button class="btn btn-danger" Text="delete" runat="server" OnClick="GridView_delButton_Click" />
                              </ItemTemplate>
                          </asp:TemplateField>	
                          <asp:BoundField DataField="Eid" HeaderText="Eid" SortExpression="Eid" Visible="false" ReadOnly="True"/>
                          <asp:BoundField DataField="Qid" HeaderText="Qid" SortExpression="Qid" Visible="false" InsertVisible="False" ReadOnly="True" />
                          <asp:BoundField DataField="Qname" HeaderText="Qname" SortExpression="Qname" />
                          <asp:BoundField DataField="Option1" HeaderText="Option1" SortExpression="Option1" />
                          <asp:BoundField DataField="Option2" HeaderText="Option2" SortExpression="Option2" />
                          <asp:BoundField DataField="Option3" HeaderText="Option3" SortExpression="Option3" />

                          <asp:BoundField DataField="Option4" HeaderText="Option4" SortExpression="Option4" />
                          <asp:BoundField DataField="Correct" HeaderText="Correct" SortExpression="Correct" />

                      </Columns>
					  </asp:GridView>
                        
                        
                       
	                    
                        
                        
                       
	                     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:quizappDBCon %>" SelectCommand="SELECT * FROM [Question] WHERE ([Eid] = @Eid)">
                             <SelectParameters>
                                 <asp:ControlParameter ControlID="Examid" Name="Eid" PropertyName="SelectedValue" Type="Int32" />
                             </SelectParameters>
                         </asp:SqlDataSource>
                        
                        
                       
	                    
                        
                        
                       
	</div></div>

     <div class="row">
	  
		
			  
         
         <asp:DropDownList class="p-2 m-1 w-25 h-25" id="Examdurationdrp" runat="server">
              <asp:ListItem Text="Exam Duration" />
			 <asp:ListItem Text="10" />
             <asp:ListItem Text="20" />
             <asp:ListItem Text="30" />
             <asp:ListItem Text="40" />
         </asp:DropDownList>
		   

			   <asp:Button class="btn btn-primary ml-auto  m-3 " ID="publishbtn" runat="server" Text="Publish Paper" OnClick="publishbtn_Click"  />
		   
            
				

            
				

		
	</div>

	</div></div></div>


		    <div class="col-md-5">
            <div class="card">
               <div class="card-body">
                  

	
		
                      
					 
				    <div class="row">

                       

						
					 <div class="col">
		       <table class=" w-100 ">
				    <tr><td><asp:TextBox ID="txtQname" class="w-100" placeholder="Question name" runat ="server" /></td></tr>
				    
			        <tr><td><asp:TextBox  id="txta1"  class="w-100" placeholder="Answer 1" runat ="server" /></td></tr>
				    <tr><td><asp:TextBox  id="txta2" class="w-100" placeholder="Answer 2" runat ="server" /></td></tr>
				    <tr><td><asp:TextBox  id="txta3" class="w-100" placeholder="Answer 3" runat ="server" /></td></tr>
				    <tr><td><asp:TextBox  id="txta4" class="w-100" placeholder="Answer 4" runat ="server" /></td></tr>
				    <tr><td><asp:TextBox  id="txtcorrect" class="w-100" placeholder="Correct Answer" runat ="server" /></td></tr>
			
			</table>
</div>
			

</div>
				    <div class="row justify-content-center">
			<asp:Button class="btn btn-success p-2 m-2 w-50" ID="btnsubmit" runat="server" Text="submit" OnClick="submit_Click"  />
		</div></div></div></div></div>
	



	


    </div>
</asp:Content>
