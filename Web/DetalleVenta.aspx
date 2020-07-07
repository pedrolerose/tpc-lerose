<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleVenta.aspx.cs" Inherits="Web.DetalleVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-dark" style="margin-left: 50px; margin-top: 20px;">Detalle Venta</h1>

    <div class="row" style="margin-bottom: 50px; margin-top: 50px; justify-content: center">

        <div class="card col-md-4" style="width: 25%;">
            <div class="card-body" style="margin-left: 50px;">
                <div class="card-title">
                    <label>Nr. Venta:</label>
                    <label><% = carrito.Id %></label>
                </div>
                <div class="card-text">
                    <label>Monto: $</label>
                    <label><% = carrito.Monto %></label>
                </div>
                <div class="card-text">
                    <label>Estado: </label>
                    <label><% = carrito.EstadoVenta.Descripcion %></label>
                </div>
                <div class="card-text">
                    <div class="btn-group dropright">
                        <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Cambiar Estado
                        </button>
                        <div class="dropdown-menu">
                            <% foreach (var e in estados)
                                { %>
                            <a href="DetalleVenta.aspx?idven=<% = carrito.Id.ToString() %>&idestado=<% = e.Id.ToString() %>" class="dropdown-item"><% = e.Descripcion %></a>
                            <% } %>
                        </div>
                    </div>
                </div>
            </div>
            <h6 class="text-dark" style="margin-left: 50px; margin-top: 20px;">Articulos</h6>
            <table class="table" style="margin-left: 30px; margin-right: 10px; width: 70%;">

                <tr>
                    <td class="text-dark">Vista Previa</td>
                    <td class="text-dark">Nombre</td>
                    <td class="text-dark">Precio</td>
                </tr>
                <% foreach (var item in carrito.Articulos)
                    { %>
                <tr>
                    <td class="text-dark">
                        <img src="<% = item.Imagen %>" style="max-height: 50px; max-width: 50px;">
                    </td>
                    <td class="text-dark"><% = item.Nombre %></td>
                    <td class="text-dark">$ <% = item.Precio %></td>
                </tr>
                <% } %>
            </table>
        </div>



    </div>

</asp:Content>
