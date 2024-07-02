<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Adminroute.aspx.cs" Inherits="Train_Management_System.Adminroute" %>
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
			   <h4>route</h4>
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
		 <div class="col-md-4">
			<label>Departure station</label>
			<div class="form-group">
			   <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Station"></asp:TextBox>
			</div>
		 </div>
		  <div class="col-md-4">
		<label>Arrival station</label>
		<div class="form-group">
		   <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Station"></asp:TextBox>
		</div>
		</div>
		  <div class="col-md-4">
		<label>Departure time</label>
		<div class="form-group">
		   <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Time"></asp:TextBox>
		</div>
		</div>
		  <div class="col-md-4">
		<label>Arrival time</label>
		<div class="form-group">
		   <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Time"></asp:TextBox>
		</div>
		</div>
	  </div>
	  <div class="row">
		 <div class="col-4">
			<asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Add"  OnClick="Button2_Click" />
		 </div>
		 
		 <div class="col-4">
			<asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button4_Click"  />
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
			   <h4>Route List</h4>
			</center>
		 </div>
	  </div>
	  <div class="row">
		 <div class="col">
			<hr>
		 </div>
	  </div>
	   
	    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:train_management_dbConnectionString %>" SelectCommand="SELECT * FROM [Train_Route]"></asp:SqlDataSource>
<div class="col">
		<asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="schedule_id">
          <Columns>
				<asp:BoundField DataField="train_id" HeaderText="Train ID" ReadOnly="True" SortExpression="train_id" />
				<asp:BoundField DataField="dep_station_id" HeaderText="from" SortExpression="dep_station_id" />
				 <asp:BoundField DataField="arr_station_id" HeaderText="to" ReadOnly="True" SortExpression="arr_station_id" />
			  <asp:BoundField DataField="arrival" HeaderText="departure at" ReadOnly="True" SortExpression="arrival" />
			  <asp:BoundField DataField="departure" HeaderText="arrival at" ReadOnly="True" SortExpression="departure" />
          </Columns>
		</asp:GridView>	  
   </div>
	   </div>
</div>
</div>
</div>
</div>
</asp:Content>
