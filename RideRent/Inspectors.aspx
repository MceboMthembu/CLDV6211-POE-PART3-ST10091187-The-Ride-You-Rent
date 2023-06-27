<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inspectors.aspx.cs" Inherits="RideRent.Inspectors" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inspectors</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="text-center">Inspectors</h1>
            <div class="form-group">
                <label>Inspector No:</label>
                <asp:TextBox ID="InspectorNoTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Name:</label>
                <asp:TextBox ID="NameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Email:</label>
                <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Mobile:</label>
                <asp:TextBox ID="MobileTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <div class="btn-group">
                    <asp:Button ID="InsertButton" runat="server" Text="Insert" OnClick="InsertInspector" CssClass="btn btn-primary" />
                    <div class="ml-2"></div> 
                    <a href="Navigation.aspx" class="btn btn-secondary">Back</a>
                </div>
            </div>
            <hr />
            <asp:GridView ID="InspectorGridView" runat="server" AutoGenerateColumns="False" OnRowEditing="InspectorGridView_RowEditing" OnRowUpdating="InspectorGridView_RowUpdating" OnRowCancelingEdit="InspectorGridView_RowCancelingEdit" OnRowDeleting="InspectorGridView_RowDeleting" CssClass="table table-striped" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" DataKeyNames="InspectorNo">
                <Columns>
                    <asp:BoundField DataField="InspectorNo" HeaderText="Inspector No" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
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
