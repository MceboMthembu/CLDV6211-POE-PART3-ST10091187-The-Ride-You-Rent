<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RideRent.Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .container {
            max-width: 400px;
            margin-top: 100px;
        }
    </style>
</head>
<body>
    <form id="formLogin" runat="server" class="needs-validation" novalidate>
        <div class="container">
            <h2 class="mb-4">Login</h2>
            <div class="form-group">
                <label for="txtName">Name:</label>
                <input type="text" id="txtName" runat="server" class="form-control" required />
                <div class="invalid-feedback">
                    Please enter your name.
                </div>
            </div>
            <div class="form-group">
                <label for="txtEmail">Email:</label>
                <input type="email" id="txtEmail" runat="server" class="form-control" required />
                <div class="invalid-feedback">
                    Please enter a valid email address.
                </div>
            </div>
            <div class="form-group">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
            </div>
            <div class="text-danger">
                <asp:Label ID="lblError" runat="server" EnableViewState="false"></asp:Label>
            </div>
        </div>

        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
        <script>
            // Custom form validation
            (function () {
                'use strict';
                window.addEventListener('load', function () {
                    var form = document.getElementById('formLogin');
                    form.addEventListener('submit', function (event) {
                        if (!form.checkValidity()) {
                            event.preventDefault();
                            event.stopPropagation();
                        }
                        form.classList.add('was-validated');
                    }, false);
                }, false);
            })();
        </script>
    </form>
</body>
</html>
