<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiCarrito.aspx.cs" Inherits="WebApp.MiCarrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="margin-left: 50px; margin-top: 20px;">Carrito</h1>

    <div class="row" style="margin-bottom: 50px; margin-top: 50px; justify-content: center;">
        <table class="table" style="margin-left: 30px; margin-right: 10px; width: 70%;">

            <tr>
                <td>Vista Previa</td>
                <td>Nombre</td>
                <td>Precio</td>
                <td>Cantidad</td>
                <td style="width: 30%;">
                    <label style="margin-left: 40px;">Acciones</label></td>
            </tr>
            <% foreach (var item in carritoFront)
                { %>
            <tr>
                <td>
                    <img src="<% = item.Imagen %>" style="max-height: 50px; max-width: 50px;"></td>
                <td><% = item.Nombre %></td>
                <td>$ <% = decimal.Round(item.Precio, 2, MidpointRounding.AwayFromZero) %></td>
                <td><% = ContarCant(item) %></td>
                <td>
                    <a href="Detalle.aspx?idart=<% = item.Id.ToString() %>" class="btn btn-primary">Detalle</a>

                    <a href="MiCarrito.aspx?idAgregar=<% = item.Id.ToString() %>" class="btn btn-success">
                        <svg class="bi bi-cart-plus" width="1em" height="1em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                            <path fill-rule="evenodd" d="M8.5 5a.5.5 0 0 1 .5.5v2a.5.5 0 0 1-.5.5h-2a.5.5 0 0 1 0-1H8V5.5a.5.5 0 0 1 .5-.5z" />
                            <path fill-rule="evenodd" d="M8 7.5a.5.5 0 0 1 .5-.5h2a.5.5 0 0 1 0 1H9v1.5a.5.5 0 0 1-1 0v-2z" />
                            <path fill-rule="evenodd" d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 0 0 2 1 1 0 0 0 0-2zm7 0a1 1 0 1 0 0 2 1 1 0 0 0 0-2z" />
                        </svg>
                    </a>

                    <a href="MiCarrito.aspx?idQuitar=<% = item.Id.ToString() %>" class="btn btn-warning">
                        <svg class="bi bi-cart-dash" width="1em" height="1em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                            <path fill-rule="evenodd" d="M6 7.5a.5.5 0 0 1 .5-.5h4a.5.5 0 0 1 0 1h-4a.5.5 0 0 1-.5-.5z" />
                            <path fill-rule="evenodd" d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 0 0 2 1 1 0 0 0 0-2zm7 0a1 1 0 1 0 0 2 1 1 0 0 0 0-2z" />
                        </svg>
                    </a>

                    <a href="MiCarrito.aspx?idBorrar=<% = item.Codigo %>" class="btn btn-danger">
                        <svg class="bi bi-trash" width="1em" height="1em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                            <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z" />
                            <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4L4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z" />
                        </svg>
                    </a>
                </td>
            </tr>
            <% } %>
        </table>
    </div>
    <div class="row" style="justify-content: center;">
        <h5>Total: $ <% = decimal.Round(total, 2, MidpointRounding.AwayFromZero) %></h5>
    </div>

    <div class="row" style="justify-content: center;">
        <button class="btn btn-danger" onclick="<% TirarTodo(); %>" style="width: 250px;">Tirar Todo!</button>
        <a href="FormularioCompra.aspx" class="btn btn-success" style="width: 250px; margin-left: 20px;">Comprar!</a>
    </div>
    <div class="row">
        <a href="Listado.aspx" class="btn btn-info" style="margin-left: 70px;">Atras</a>
    </div>

</asp:Content>
