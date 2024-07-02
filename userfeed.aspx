<%@ Page Title="" Language="C#" MasterPageFile="~/Site4.Master" AutoEventWireup="true" CodeBehind="userfeed.aspx.cs" Inherits="Train_Management_System.WebForm6" %>
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
	 <div class="container">
<div class="row">
<div class="col-md-5">
<div class="card">
   <div class="card-body">
	  <div class="row">
		 <div class="col">
			<center>
			   <h4>Station</h4>
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
			<label>Feedback ID</label>
			<div class="form-group">
			   <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Feedback Id" ></asp:TextBox>
			</div>
		 </div>
		 <div class="col-md-8">
			<label>Content</label>
			<div class="form-group">
			   <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="SContent" ></asp:TextBox>
			</div>
		 </div>
	  </div>
	  <div class="row">
		 <div class="col-4">
			<asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button2_Click" />
		 </div>
		
		 <div class="col-4">
			<asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button4_Click" />
		 </div>
	  </div>
   </div>
</div>

</div>
        <div class="col-md-7">
<div class="card">
   <div class="card-body">
	  <div class="row">
		 <div class="col">
			<center>
			   <h4>Feedbacks</h4>
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
		   <asp:BoundField DataField="fee_id" HeaderText="Feedback ID" SortExpression="fee_id" />
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
