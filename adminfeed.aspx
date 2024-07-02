<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="adminfeed.aspx.cs" Inherits="Train_Management_System.adminfeed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">
    $(document).ready(function () {

        //$(document).ready(function () {
        //$('.table').DataTable();
        // });

        $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        //$('.table1').DataTable();
    });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
<div class="card">
   <div class="card-body">
	  <div class="row">
		 <div class="col">
			<center>
			   <h4>Feedback List</h4>
			</center>
		 </div>
	  </div>
	  <div class="row">
		 <div class="col">
			<hr>
		 </div>
	  </div>
	  <div class="row">
		   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:train_management_dbConnectionString %>" SelectCommand="SELECT * FROM [Feedback]"></asp:SqlDataSource>
           <div class="col">
			<asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="fee_id">
       <Columns>
           <asp:BoundField DataField="fee_id" HeaderText="Feedback ID" ReadOnly="True" SortExpression="fee_id" />
           <asp:BoundField DataField="content" HeaderText="Content" SortExpression="content" />
		   <asp:BoundField DataField="p_id" HeaderText="Passenger ID" ReadOnly="True" SortExpression="p_id" />
       </Columns>
			</asp:GridView>
	  </div>
   </div>
</div>
</div>
		</div>
</asp:Content>
