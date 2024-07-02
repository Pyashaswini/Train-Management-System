<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="adminstation.aspx.cs" Inherits="Train_Management_System.WebForm4" %>
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
			   <h4>Train</h4>
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
			<label>Train ID</label>
			<div class="form-group">
			   <div class="input-group">
				  <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
				  
			   </div>
			</div>
		 </div>
		
	  </div>
	  <div class="row">
		 <div class="col-4">
			<asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button2_Click"  />
		 </div>
		
		 <div class="col-4">
			<asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button4_Click"/>
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
			   <h4>Train List</h4>
			</center>
		 </div>
	  </div>
	  <div class="row">
		 <div class="col">
			<hr>
		 </div>
	  </div>
	  <div class="row">
					  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:train_management_dbConnectionString %>" SelectCommand="SELECT * FROM [Train]"></asp:SqlDataSource>
		 <div class="col">
			<asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="Train_id">
                         <Columns>
                             <asp:BoundField DataField="Train_id" HeaderText="Train_id" ReadOnly="True" SortExpression="Train_id" />
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
