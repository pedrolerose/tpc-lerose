<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioPass.aspx.cs" Inherits="Web.OlvidePass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>Cambio Pass</title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

</head>
<body>
        <div class="container">
        <div class="row">
            <div class="col">
                <form id="form2" runat="server">

                    <div class="row" style="margin-bottom: 50px; margin-top: 50px; justify-content: center">

                        <div class="card col-md-4" style="width: 25%;">
                            <div class="card-body" style="margin-left: 50px;">

                                <div class="form-group">
                                    <img class="mb-4" src="/docs/4.5/assets/brand/bootstrap-solid.svg" alt="" width="72" height="72" />
                                    <h3 class="mb-3 text-dark">Deje sus datos, enviaremos un mail</h3>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" ID="txtPass" type="password" CssClass="form-control" placeholder="Password" required="" />
                                    </div>
                                    <a class="btn btn-lg btn-success" id="btnIngresar" href="CambioPass.aspx?doc="+ <% = dni %> +"&dniListo="+ <% = txtPass.Text %>" >Cambiar</a>
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
