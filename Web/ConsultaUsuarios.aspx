<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaUsuarios.aspx.cs" Inherits="Web.ConsultaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="margin-left: 50px; margin-top: 20px;">Usuarios</h1>

    <div class="row" style="margin-bottom: 50px; margin-top: 50px; justify-content: center;">
        <table class="table" style="margin-left: 30px; margin-right: 10px; width: 70%;">

            <tr>
                <td class="text-dark">Nombre</td>
                <td class="text-dark">Documento</td>
                <td class="text-dark">Mail</td>
                <td class="text-dark">Fecha Registro</td>
                <td style="width: 30%;">
                    <label class="text-dark">Acciones</label></td>
            </tr>
            <% foreach (var item in usuarios)
                { %>
            <tr>
                <td class="text-dark"><% = item.Nombre %></td>
                <td class="text-dark"><% = item.NumeroDocumento.ToString() %></td>
                <td class="text-dark"><% = item.Mail %></td>
                <td class="text-dark"><% = item.Fecha %></td>
                <td>
                    <a href="DetalleUsuario.aspx?idusu=<% = item.Id.ToString() %>" class="btn btn-primary">Detalle</a>
                    <!--<a href="MiCarrito.aspx?idBorrar=<% = item.Id %>" class="btn btn-danger">Grisar Venta</a>-->
                </td>
            </tr>
            <% } %>
        </table>
    </div>

</asp:Content>
