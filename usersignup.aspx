<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="Train_Management_System.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">'
      <style>
        .error {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="vh-100">
        <div class="container h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-lg-12 col-xl-11">
                    <div class="card text-black" style="border-radius: 25px;">
                        <div class="card-body p-md-5">
                            <div class="row justify-content-center">
                               
                                <div class="col-md-10 col-lg-6 col-xl-5 order-2 order-lg-1">
                                    <p class="text-center h1 fw-bold mb-5 mx-1 mx-md-4 mt-4">Sign up</p>
                                    <div class="d-flex flex-column mb-4">
                                        <div class="d-flex flex-row align-items-center mb-4">
                                            <i class="fas fa-user fa-lg me-3 fa-fw"></i>
                                            <div class="form-outline flex-fill mb-0">
                                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Your Name" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="d-flex flex-row align-items-center mb-4">
                                            <i class="fas fa-user fa-lg me-3 fa-fw"></i>
                                            <div class="form-outline flex-fill mb-0">
                                                <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" placeholder="Age" type="number" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="d-flex flex-row align-items-center mb-4">
                                            <h6 class="mb-2 pb-1 me-3">Gender: </h6>
                                            <div class="form-check form-check-inline">
                                                <asp:RadioButton ID="rbtnFemale" runat="server" CssClass="form-check-input" Text="" GroupName="Gender" Checked="true" />
                                                <label class="form-check-label" for="rbtnFemale">Female</label>
                                            </div>
                                            <div class="form-check form-check-inline">
                                                <asp:RadioButton ID="rbtnMale" runat="server" CssClass="form-check-input" Text="" GroupName="Gender" />
                                                <label class="form-check-label" for="rbtnMale">Male</label>
                                            </div>
                                        </div>
                                        
                                        <div class="d-flex flex-row align-items-center mb-4">
                                            <i class="fas fa-phone fa-lg me-3 fa-fw"></i>
                                            <div class="form-outline flex-fill mb-0">
                                                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="Contact Number" type="tel" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="d-flex flex-row align-items-center mb-4">
                                            <i class="fas fa-lock fa-lg me-3 fa-fw"></i>
                                            <div class="form-outline flex-fill mb-0">
                                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="d-flex flex-row align-items-center mb-4">
                                            <i class="fas fa-key fa-lg me-3 fa-fw"></i>
                                            <div class="form-outline flex-fill mb-0">
                                                <asp:TextBox ID="txtRepeatPassword" runat="server" CssClass="form-control" placeholder="Repeat your password" TextMode="Password" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="d-flex justify-content-center mx-4 mb-3 mb-lg-4">
                                            <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary btn-lg" Text="Register" OnClick="Button1_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-10 col-lg-6 col-xl-7 d-flex align-items-center order-1 order-lg-2">
                                    <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-registration/draw1.webp" class="img-fluid" alt="Sample image">
                                </div>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
