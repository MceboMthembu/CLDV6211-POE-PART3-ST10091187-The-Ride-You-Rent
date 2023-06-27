<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="RideRent.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            background-image: url('C:\Users\lab_services_student\source\repos\RideRent\RideRent\Images');
            background-repeat: no-repeat;
            background-position: center center;
            background-attachment: fixed;
            background-size: cover;
        }
    </style>

    <div class="jumbotron">
        <h1 class="display-4">About The Ride You Rent</h1>
        <p class="lead">Welcome to The Ride You Rent, your premier destination for car rentals.</p>
        <hr class="my-4">
        <p>
            We can provide you with a vehicle for a particular occasion, a road trip you're planning, or just a short-term means of transportation. You can discover the ideal vehicle for your journey in our fleet, which includes automobiles of different types and models all suited to your needs.
        
        <p>
            Our commitment to exceptional customer service sets us apart. We strive to make your rental experience smooth, convenient, and enjoyable. Our friendly and knowledgeable staff is ready to assist you with any inquiries or requests you may have.
        </p>
        <p>
          The Ride You Rent is your go-to partner for inexpensive and dependable transportation thanks to its competitive pricing and versatile rental options. Call us right away to schedule your next journey!
        </p>
        <a class="btn btn-primary btn-lg" href="Contact.aspx" role="button">Contact Us</a>
        <a class="btn btn-secondary btn-lg" href="Default.aspx" role="button">Go Back</a>
    </div>
</asp:Content>