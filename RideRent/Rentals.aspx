<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rentals.aspx.cs" Inherits="RideRent.Rentals" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rentals</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-center">Create Rental</h2>
            <table class="table">
                <tr>
                    <td>Car No:</td>
                    <td><asp:TextBox ID="CarNoTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Inspector:</td>
                    <td><asp:TextBox ID="InspectorTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Driver:</td>
                    <td><asp:TextBox ID="DriverTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Rental Fee:</td>
                    <td><asp:TextBox ID="RentalFeeTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Start Date:</td>
                    <td><asp:TextBox ID="StartDateTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>End Date:</td>
                    <td><asp:TextBox ID="EndDateTextBox" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <div class="btn-group">
                            <asp:Button ID="CreateRentalButton" runat="server" Text="Create Rental" OnClick="CreateRental" CssClass="btn btn-primary" />
                            <div class="ml-2"></div> <!-- Add small space between the buttons -->
                            <a href="Navigation.aspx" class="btn btn-secondary">Back</a>
                        </div>
                    </td>
                </tr>
            </table>

            <hr />

            <h2 class="text-center">Rental Data</h2>
            <asp:GridView ID="RentalGridView" runat="server" DataKeyNames="CarNo" AutoGenerateColumns="False" OnRowEditing="RentalGridView_RowEditing" OnRowUpdating="RentalGridView_RowUpdating" OnRowCancelingEdit="RentalGridView_RowCancelingEdit" OnRowDeleting="RentalGridView_RowDeleting" CssClass="table table-striped" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="CarNo" HeaderText="CarNo" />
                    <asp:BoundField DataField="Inspector" HeaderText="Inspector" />
                    <asp:BoundField DataField="Driver" HeaderText="Driver" />
                    <asp:BoundField DataField="RentalFee" HeaderText="Rental Fee" />
                    <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:LinkButton ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
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
