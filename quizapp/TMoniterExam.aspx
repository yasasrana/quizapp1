<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="TMoniterExam.aspx.cs" Inherits="quizapp.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Moniter Exam</title>
      <link href="css1/style7.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

        <p class="hedder7">Monitor Started Exam</p>
       
        
        <div>
            <asp:DropDownList id="examdropdown" class="p-2 m-1 w-25 h-25" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Ename" DataValueField="id" >
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:quizappDBCon %>" SelectCommand="SELECT [id], [Ename] FROM [Exam]"></asp:SqlDataSource>
            <table class="cx2">
                <tr>
                <td class="cx1">
                    <div class="text-center">
                    <asp:Label  class="cx3"  Text="Exam completed " runat="server" /><br />
                    <asp:Label  class="cx4" id="lblmarks" Text="15/20 " runat="server" /><br />
                    <%--<asp:Label  class="cx5" id="lbltime" Text="Time Left: 00:15 mins" runat="server" />--%>
                    </div>
                </td>
                    <td class="cx1" rowspan="2" >
                        <h3 class="cx8 p-3 m-0">Attending Students List</h3>
                    
                          <asp:GridView class="table table-striped table-bordered m-2" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowSorting="True" DataSourceID="SqlDataSource2" DataKeyNames="Eid,Stuid,Sessionid,sStart,sEnd,AnsQ,TotQ,Results" >
                      <Columns>
                          
                         
                          <asp:BoundField DataField="Stuid" HeaderText="Student ID" SortExpression="Stuid"  ReadOnly="True" />
                          <asp:BoundField DataField="Sessionid" HeaderText="Sessionid" SortExpression="Sessionid" InsertVisible="False" Visible="false" ReadOnly="True" />
                          <asp:BoundField DataField="sStart" HeaderText="sStart" SortExpression="sStart" Visible="false"/>
                          <asp:BoundField DataField="sEnd" HeaderText="sEnd" SortExpression="sEnd" Visible="false"/>
                          <asp:BoundField DataField="AnsQ" HeaderText="AnsQ" SortExpression="AnsQ" Visible="false"/>
                          <asp:BoundField DataField="TotQ" HeaderText="TotQ" SortExpression="TotQ" Visible="false"/>
                          <asp:BoundField DataField="Results" HeaderText="Results" SortExpression="Results" Visible="false"/>
                          <asp:TemplateField>
                          <ItemTemplate>
                                <asp:Button class="btn btn-info" Text="select" runat="server" OnClick="GridView_Button_Click" />
                              </ItemTemplate>
                          </asp:TemplateField>
                      
                      </Columns>
					  </asp:GridView>
                           
    
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:quizappDBCon %>" SelectCommand="SELECT * FROM [sessions] WHERE ([Eid] = @Eid)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="examdropdown" Name="Eid" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                           
    
                    </td>
                </tr>
    
                <tr>
                    <td class="cx1">
                           <asp:Label  class="cx6" id="Label1" Text="Exam started Time :" runat="server" /><asp:Label  class="cx6" id="lblStime" Text="" runat="server" /><br />
                           <asp:Label  class="cx7" id="Label2" Text="Exame ending time :" runat="server" /><asp:Label  class="cx7" id="lblEtime" Text="" runat="server" />
                        
                    </td>
                </tr>
            </table>
    
         <p class="butn2">  <asp:Button class="btn btn-danger m-3" Text="End Exam" runat="server" OnClick="Unnamed2_Click" /> </p>
        </div>
        
    </div>
    
    <%--<div class="container-fluid p-5">
      <div class="row">
         <div class="col-md-6">
             <div class="row w-100">
                <div class="card">
                   <div class="card-body w-100">
                       <div class="row">
                           <asp:Label class="cx3" Text="Exam completed " runat="server" />
                           <div class="row">
                            <asp:Label class="cx4 p-3 align-self-md-center" Text="15/20" runat="server" />
                               </div>
                           
                           
                       
                         </div>
                   </div>
                </div>
             </div>
             <div class="row">
                    <div class="card">
                       <div class="card-body">
                          <div class="row">
                               <p class="cx6">Exam started Time :  </p> <br />
                               <p class="cx7">Exame ending time :</p>
                            </div>
                         </div>
                      </div>
                 </div>
            </div>
             <div class="col-md-6 ">
                 <div class="row">
                     <div class="card">
                        <div class="card-body w-100">
                            <div class="row">
                               <h3 class="cx8">Attending Students List</h3>
    
                     <div class="mg">
                    <table class="cx9">
                        <tr >
                            <td class="rig2" > Student 1</td>
                            <td class="rig"></td>
                        </tr>
                    </table>
                    <table class="cx9">
                        <tr >
                            <td class="rig2">Student 2</td>
                            <td class="rig"><b>Completed</b></td>
                        </tr>
                    </table>
                    <table class="cx9">
                        <tr >
                            <td class="rig2" >Student 2</td>
                            <td class="rig"></td>
                        </tr>
    
                    </table>
                    </div>
                     </div></div></div></div></div></div>
                   <div class="row">
                       <asp:Button class="btn btn-danger float-right m-2" Text="End Exam" runat="server" />
   </div> </div>--%>



</asp:Content>
