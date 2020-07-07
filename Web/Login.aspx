﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

</head>
<body>

    <div class="container">
        <div class="row">
            <div class="col">
                <form id="form1" runat="server">

                    <div class="row" style="margin-bottom: 50px; margin-top: 50px; justify-content: center">

                        <div class="card col-md-4" style="width: 25%;">
                            <div class="card-body" style="margin-left: 50px;">

                                <div class="form-group">
                                    <img class="mb-4" src="/docs/4.5/assets/brand/bootstrap-solid.svg" alt="" width="72" height="72" />
                                    <h1 class="mb-3 text-dark">Login</h1>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" ID="txtMail" CssClass="form-control" placeholder="Mail" required="" />
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" ID="txtPass" type="password" CssClass="form-control" placeholder="Password" required="" />
                                    </div>
                                    <button class="btn btn-lg btn-success" id="btnIngresar" onclick="<% Loguear(); %>">Ingresar</button>
                                </div>

                            </div>
                        </div>



                    </div>




                </form>

            </div>
        </div>
    </div>
</body>
</html>
