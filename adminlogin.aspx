<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="Train_Management_System.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="vh-100">
  <div class="container-fluid h-custom">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-md-9 col-lg-6 col-xl-5">
          <img src="imgs/adminicon.jpg "class="img-fluid align-items-center" alt="Sample image" width="400" height="400">
      </div>
      <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
       
         

          <!-- user id input -->
          <div class="form-group">
    <asp:TextBox ID="textbox1" runat="server" CssClass="form-control form-control-lg" placeholder="Enter Admin ID"></asp:TextBox>
    <asp:Label AssociatedControlID="textbox1" CssClass="form-label" runat="server">Admin ID</asp:Label>
</div>

          <!-- Password input -->
          <div class="form-group">
    <asp:TextBox ID="textbox2" runat="server" CssClass="form-control form-control-lg" TextMode="Password" placeholder="Enter Password"></asp:TextBox>
    <asp:Label AssociatedControlID="textbox2" CssClass="form-label" runat="server">Password</asp:Label>
    </div>

          <div class="d-flex justify-content-between align-items-center">
            <!-- Checkbox -->
           <div class="form-group">
    <div class="form-check mb-0">
        <asp:CheckBox ID="checkboxRememberMe" runat="server" CssClass="form-check-input me-2" />
        <label class="form-check-label" for="checkboxRememberMe">
            Remember me
        </label>
   


          <div class="text-center text-lg-start mt-4 pt-2">
             <asp:Button class="btn btn-primary btn-lg" style="padding-left: 2.5rem; padding-right: 2.5rem;" ID="Button1" runat="server"  Text="Login" OnClick="Button1_Click" />

           
          </div>
</div>
    
      </div>
    </div>
  </div>
 
</section>
</asp:Content>
