<%@ Page Title="" Language="C#" MasterPageFile="~/Site4.Master" AutoEventWireup="true" CodeBehind="userhome.aspx.cs" Inherits="Train_Management_System.userhome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="lblPassengerID" runat="server" Text="Passenger Id:" ></asp:Label>
        <div>
            <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox CssClass="form-control form-control-lg" ID="txtName" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblAge" runat="server" Text="Age:"></asp:Label>
            <asp:TextBox CssClass="form-control form-control-lg" ID="txtAge" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
            <asp:TextBox CssClass="form-control form-control-lg" ID="txtGender" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:"></asp:Label>
            <asp:TextBox CssClass="form-control form-control-lg" ID="txtPhoneNumber" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        
    </div>
</asp:Content>
