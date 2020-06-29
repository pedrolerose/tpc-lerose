<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BajaArticulo.aspx.cs" Inherits="Web.BajaArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-dark" style="margin-left: 50px; margin-top: 20px;">Eliminar/Modificar Articulos</h1>

    <div class="row" style="margin-bottom: 50px; margin-top: 50px; justify-content: center;">
        <table class="table" style="margin-left: 30px; margin-right: 10px; width: 70%;">

            <tr>
                <td class="text-dark">Vista Previa</td>
                <td class="text-dark">Nombre</td>
                <td class="text-dark">Precio</td>
                <td style="width: 30%;">
                    <label class="text-dark" style="margin-left: 40px;">Acciones</label>
                </td>
            </tr>
            <% foreach (var item in listaArticulos)
                { %>
            <tr>
                <td>
                    <img src="<% = item.Imagen %>" style="max-height: 50px; max-width: 50px;">
                </td>
                <td class="text-dark">
                    <% = item.Nombre %>
                </td>
                <td class="text-dark">
                    $ <% = decimal.Round(item.Precio, 2, MidpointRounding.AwayFromZero) %></td>
                <td>
                    <a href="BajaArticulo.aspx?idModificar=<% = item.Id.ToString() %>" class="btn btn-primary">
                        Modificar
                    </a>
                    <a href="BajaArticulo.aspx?idBorrar=<% = item.Id %>" class="btn btn-danger">
                        Eliminar
                    </a>
                </td>
            </tr>
            <% } %>
        </table>
    </div>


</asp:Content>