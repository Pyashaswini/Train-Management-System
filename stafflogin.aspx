<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="stafflogin.aspx.cs" Inherits="Train_Management_System.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <section class="vh-100">
  <div class="container-fluid h-custom">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-md-9 col-lg-6 col-xl-5">
          <img src="imgs/sign-in-page-flat-design-concept-illustration-icon-account-login-user-login-abstract-metaphor-can-use-for-landing-page-mobile-app-ui-posters-banners-free-vector.jpg" 
          class="img-fluid" alt="Sample image"width="400" height="400">
      </div>
      <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
       
         

          <!-- user id input -->
          <div class="form-outline mb-4">
            <asp:TextBox ID="textbox1" runat="server" class="form-control form-control-lg" placeholder="Enter Staff ID" />
            <label class="form-label" for="textbox1">Staff ID</label>
          </div>

          <!-- Password input -->
          <div class="form-outline mb-3">
           <asp:TextBox ID="textbox2" runat="server" type="password" class="form-control form-control-lg" placeholder="Enter password" />
<label class="form-label" for="textbox2">Password</label>
          </div>

          <div class="d-flex justify-content-between align-items-center">
            <!-- Checkbox -->
            <div class="form-check mb-0">
              <input class="form-check-input me-2" type="checkbox" value="" id="form2Example3" />
              <label class="form-check-label" for="form2Example3">
                Remember me
              </label>
           
          <div class="text-center text-lg-start mt-4 pt-2">
<asp:Button class="btn btn-primary btn-lg" style="padding-left: 2.5rem; padding-right: 2.5rem;" ID="Button1" runat="server"  Text="Login" OnClick="Button1_Click1" />

           
          </div>

    
      </div>
    </div>
  </div>
 
</section>
</asp:Content>
