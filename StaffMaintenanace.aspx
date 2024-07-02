<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="StaffMaintenanace.aspx.cs" Inherits="Train_Management_System.StaffMaintenanace" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container">
       <div class="row">
           <div class="col-md-5">
               <div class="card">
                   <div class="card-body">
                       <div class="row">
                           <div class="col">
                               <center>
                                   <h4>Maintainance</h4>
                               </center>
                           </div>
                       </div>
                       
                       <div class="row">
                           <div class="col">
                               <hr>
                           </div>
                       </div>
                       <div class="row">
                           <div class="col-md-4">
                               
                               <label>Staff ID</label>
                               <div class="form-group">
                                   <div class="input-group">
                                       <asp:TextBox CssClass="form-control" ID="TextBoxContent" runat="server" placeholder="Staff ID"></asp:TextBox>
                                   </div>
                               </div>
                               <label>Train ID</label>
                                <div class="form-group">
                                     <div class="input-group">
                                         <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Train ID"></asp:TextBox>
                                     </div>
                                 </div>
                               <label>Content</label>
                                <div class="form-group">
                                     <div class="input-group">
                                         <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Maintenance content"></asp:TextBox>
                                     </div>
                                 </div>
                               <label>Schedule<asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                                   <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                   <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                   <OtherMonthDayStyle ForeColor="#999999" />
                                   <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                   <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                   <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                   <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                   <WeekendDayStyle BackColor="#CCCCFF" />
                               </asp:Calendar>
                               </label>
                               &nbsp;<div class="form-group">
                                   <div class="input-group">
                                       
                                   </div>
                               </div>
                           </div>
                           
                       </div>
                       <div class="row">
                           <div class="col-4">
                               <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Add"  onclick="Button3_Click"/>
                           </div>
                           <
                       </div>
                   </div>
               </div>
           </div>
       </div>
       <div class="row">
           <div class="col-md-8">
               <div class="card">
                   <div class="card-body">
                       <div class="row">
                           <div class="col">
                               <center>
                                   <h4>maintenance List</h4>
                               </center>
                           </div>
                       </div>
                       <div class="row">
                           <div class="col">
                               <hr>
                           </div>
                       </div>
                       <div class="row">
                           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:train_management_dbConnectionString %>" SelectCommand="SELECT * FROM [Maintenance]"></asp:SqlDataSource>
                           <div class="col">
                               <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="m_id">
                                   <Columns>
                                       <asp:BoundField DataField="m_id" HeaderText="Maintenance ID" ReadOnly="True" SortExpression="m_id" />
                                       <asp:BoundField DataField="train_id" HeaderText="Train ID" SortExpression="train_id" />
                                       <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" />
                                       <asp:BoundField DataField="content" HeaderText="Content" SortExpression="content" />
                                       <asp:TemplateField HeaderText="Status">
                                           <ItemTemplate>
                                               <asp:CheckBox ID="CheckBoxStatus" runat="server" Checked='<%# Convert.ToBoolean(Eval("status")) %>' Enabled="false" />
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="schedule" HeaderText="Schedule" SortExpression="schedule" />
                                   </Columns>
                               </asp:GridView>
                           </div>
                       </div>
                   </div>
               </div>
           </div>
       </div>
   </div>

</asp:Content>
