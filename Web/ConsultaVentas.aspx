<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaVentas.aspx.cs" Inherits="Web.ConsultaVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1 style="margin-left: 50px; margin-top: 20px;">Ventas</h1>

    <div class="row" style="margin-bottom: 50px; margin-top: 50px; justify-content: center;">
        <table class="table" style="margin-left: 30px; margin-right: 10px; width: 70%;">

            <tr>
                <td class="text-dark">Fecha</td>
                <td class="text-dark">Nr. Venta</td>
                <td class="text-dark">Monto</td>
                <td style="width: 30%;">
                    <label class="text-dark">Acciones</label></td>
            </tr>
            <% foreach (var item in ventas)
                { %>
            <tr>
                <td class="text-dark"><% = item.Fecha %></td>
                <td class="text-dark"><% = item.Id %></td>
                <td class="text-dark">$ <% = item.Monto %></td>
                <td>
                    <a href="DetalleVenta.aspx?idven=<% = item.Id.ToString() %>" class="btn btn-primary">Detalle</a>
                    <!--<a href="MiCarrito.aspx?idBorrar=<% = item.Id %>" class="btn btn-danger">Grisar Venta</a>-->
                </td>
            </tr>
            <% } %>
        </table>
    </div>


</asp:Content>
