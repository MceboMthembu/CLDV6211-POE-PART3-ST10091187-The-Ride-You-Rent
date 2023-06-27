<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Car.aspx.cs" Inherits="RideRent.Car" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Car Management</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Car Management</h1>

            <div class="row">
                <div class="col-md-6">
                    <h3>Add New Car</h3>
                    <div class="form-group">
                        <label for="CarNoTextBox">Car No:</label>
                        <asp:TextBox ID="CarNoTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="MakeTextBox">Make:</label>
                        <asp:TextBox ID="MakeTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="ModelTextBox">Model:</label>
                        <asp:TextBox ID="ModelTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="BodyTypeTextBox">Body Type:</label>
                        <asp:TextBox ID="BodyTypeTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="KilometresTextBox">Kilometres Travelled:</label>
                        <asp:TextBox ID="KilometresTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="ServiceKilometresTextBox">Service Kilometres:</label>
                        <asp:TextBox ID="ServiceKilometresTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="AvailableTextBox">Available:</label>
                        <asp:TextBox ID="AvailableTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Button ID="InsertCarButton" runat="server" Text="Insert" OnClick="InsertCar" CssClass="btn btn-primary" />
                </div>
            </div>

            <div class="row mt-4">
                <div class="col-md-12">
                    <h3>Car List</h3>
                    <asp:GridView ID="CarGridView" runat="server" AutoGenerateColumns="False" OnRowEditing="CarGridView_RowEditing" OnRowUpdating="CarGridView_RowUpdating" OnRowCancelingEdit="CarGridView_RowCancelingEdit" OnRowDeleting="CarGridView_RowDeleting" CssClass="table table-striped" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" DataKeyNames="CarNo">
                        <Columns>
                            <asp:BoundField DataField="CarNo" HeaderText="Car No" ReadOnly="true" />
                            <asp:BoundField DataField="Make" HeaderText="Make" />
                            <asp:BoundField DataField="Model" HeaderText="Model" />
                            <asp:BoundField DataField="BodyType" HeaderText="Body Type" />
                            <asp:BoundField DataField="KilometresTravelled" HeaderText="Kilometres Travelled" />
                            <asp:BoundField DataField="ServiceKilometres" HeaderText="Service Kilometres" />
                            <asp:BoundField DataField="Available" HeaderText="Available" />
                            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" ButtonType="Button" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
