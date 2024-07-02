<%@ Page Title="" Language="C#" MasterPageFile="~/Site4.Master" AutoEventWireup="true" CodeBehind="userticket.aspx.cs" Inherits="Train_Management_System.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
$(document).ready(function () {

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
                                    <h4>Book Ticket</h4>
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
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Train ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Seat</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Seat"></asp:TextBox>
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
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Button ID="Button1" runat="server" Text="Book Ticket" CssClass="btn btn-primary btn-block" OnClick="Button1_Click" />
                            </div>
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
	   
	    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:train_management_dbConnectionString %>" SelectCommand="SELECT * FROM [Train_Route]"></asp:SqlDataSource>
<div class="col">
		<asp:GridView class="table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" DataKeyNames="schedule_id">
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
        <div class="row">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Ticket List</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="row">
   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:train_management_dbConnectionString %>"
    SelectCommand="SELECT ticket_id, p_id, train_id, seat_id, ticket_date FROM [Passenger_Ticket] WHERE p_id = @passengerID">
    <SelectParameters>
        <asp:SessionParameter Name="passengerID" SessionField="userid" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="ticket_id" HeaderText="Ticket ID" ReadOnly="True" SortExpression="ticket_id" />
        <asp:BoundField DataField="p_id" HeaderText="Passenger ID" SortExpression="p_id" />
        <asp:BoundField DataField="train_id" HeaderText="Train ID" SortExpression="train_id" />
        <asp:BoundField DataField="seat_id" HeaderText="Seat" SortExpression="seat_id" />
        <asp:BoundField DataField="ticket_date" HeaderText="Ticket Date" SortExpression="ticket_date" />
    </Columns>
</asp:GridView>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
