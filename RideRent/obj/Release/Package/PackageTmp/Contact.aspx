<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="RideRent.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Contact Us</h1>
        <p>Have questions? Need assistance? Get in touch with us.</p>

        <div class="row">
            <div class="col-md-6">
                <h3>Address</h3>
                <p>5675 Jump Street Street</p>
                <p>Meadows Park, Benoni, 1768</p>
            </div>
            <div class="col-md-6">
                <h3>Phone</h3>
                <p>+27 63 456 7890</p>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <h3>Email</h3>
                <p>info@therideUrent.com</p>
            </div>
            <div class="col-md-6">
                <h3>Operating Hours</h3>
                <p>Monday - Friday: 9:00 AM - 5:00 PM</p>
                <p>Saturday - Sunday: Closed</p>
            </div>
        </div>

        <h3>Send us a Message</h3>
        <asp:Label ID="lblStatus" runat="server" Visible="false"></asp:Label>
        <div class="form-group">
            <label for="name">Name</label>
            <input type="text" class="form-control" id="txtName" placeholder="Your name" runat="server">
        </div>
        <div class="form-group">
            <label for="email">Email</label>
            <input type="email" class="form-control" id="txtEmail" placeholder="Your email" runat="server">
        </div>
        <div class="form-group">
            <label for="message">Message</label>
            <textarea class="form-control" id="txtMessage" rows="5" placeholder="Your message" runat="server"></textarea>
        </div>
        <button type="submit" class="btn btn-primary" runat="server" OnClick="btnSubmit_Click">Submit</button>
        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-default" OnClick="btnBack_Click" />
    </div>
</asp:Content>