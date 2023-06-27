<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Navigation.aspx.cs" Inherits="RideRent.Navigation" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Navigation</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .banner {
            background-color: #007bff;
            color: #fff;
            padding: 20px;
            text-align: center;
        }

        .container {
            max-width: 400px;
            margin-top: 30px;
        }

        ul {
            list-style-type: none;
            padding: 0;
        }

        li {
            font-size: 24px;
            margin-bottom: 10px;
        }

        li a {
            font-size: 24px;
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="banner">
            <h1>Navigation</h1>
        </div>
        <div class="container">
            <ul class="nav flex-column">
                <li class="nav-item">
                    <a class="nav-link" href="Car.aspx">Cars</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Inspectors.aspx">Inspectors</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Drivers.aspx">Drivers</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Rentals.aspx">Rentals</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Returns.aspx">Returns</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Default.aspx">Home</a>
                </li>
            </ul>
        </div>

        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
