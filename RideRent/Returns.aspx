<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Returns.aspx.cs" Inherits="RideRent.Returns" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Return Page</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="text-center">Return Page</h1>
            <h3 class="text-center">Create New Return</h3>
            <div class="form-group">
                <label for="CarNoTextBox">Car No:</label>
                <asp:TextBox ID="CarNoTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="InspectorTextBox">Inspector:</label>
                <asp:TextBox ID="InspectorTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="DriverTextBox">Driver:</label>
                <asp:TextBox ID="DriverTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="ReturnDateTextBox">Return Date:</label>
                <asp:TextBox ID="ReturnDateTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="ElapsedDaysTextBox">Elapsed Days:</label>
                <asp:TextBox ID="ElapsedDaysTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="FineTextBox">Fine:</label>
                <asp:TextBox ID="FineTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="text-center">
                <div class="btn-group">
                    <asp:Button ID="CreateReturnButton" runat="server" Text="Create Return" OnClick="CreateReturn" CssClass="btn btn-primary" />
                    <div class="ml-2"></div> 
                    <a href="Navigation.aspx" class="btn btn-secondary">Back</a>
                </div>
            </div>
            <hr />
            <h3 class="text-center">Existing Returns</h3>
            <asp:GridView ID="ReturnGridView" runat="server" DataKeyNames="CarNo" OnRowDeleting="ReturnGridView_RowDeleting" CssClass="table table-striped" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                <Columns>
                    <asp:CommandField ShowDeleteButton="true" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
        </div>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
