<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleUsuario.aspx.cs" Inherits="Web.DetalleUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-dark" style="margin-left: 50px; margin-top: 20px;">Detalle Usuario</h1>

    <div class="row" style="margin-bottom: 50px; margin-top: 50px; justify-content: center">

        <div class="card col-md-4" style="width: 25%;">
            <h6 class="text-dark" style="margin-left: 50px; margin-top: 20px;">Perfil:</h6>
            <div class="card-body" style="margin-left: 50px;">
                <div class="row">
                    <p class="card-text">
                        <label>Nombre: </label>
                        <label><% = usuario.Nombre %></label>

                    </p>
                </div>
                <div class="row">
                    <p class="card-text">
                        <label>Documento: </label>
                        <label><% = usuario.NumeroDocumento %></label>
                    </p>
                </div>
                <div class="row">
                    <p class="card-text">
                        <label>Mail: </label>
                        <label><% = usuario.Mail %></label>

                    </p>
                </div>
                <div class="row">
                    <p class="card-text">
                        <label>Fecha Registro: </label>
                        <label><% = usuario.Fecha %></label>
                    </p>
                </div>
            </div>
        </div>

        <div class="card col-md-4" style="width: 25%;">
            <h6 class="text-dark" style="margin-left: 50px; margin-top: 20px;">Datos Envio:</h6>
            <div class="card-body" style="margin-left: 50px;">
                <div class="row">
                    <p class="card-text">
                        <label>Calle: </label>
                        <label><% = usuario.Calle %></label>
                    </p>
                </div>
                <div class="row">
                    <p class="card-text">
                        <label>Numero: </label>
                        <label><% = usuario.NumeroCalle %></label>
                    </p>
                </div>
                <div class="row">
                    <p class="card-text">
                        <label>Provincia: </label>
                        <label><% = usuario.Provincia %></label>
                    </p>
                </div>
                <div class="row">
                    <p class="card-text">
                        <label>Localidad: </label>
                        <label><% = usuario.Localidad %></label>
                    </p>
                </div>
                <div class="row">
                    <p class="card-text">
                        <label>Codigo Postal: </label>
                        <label><% = usuario.CodigoPostal %></label>
                    </p>
                </div>
                <div class="row">
                    <p class="card-text">
                        <label>Telefono: </label>
                        <label><% = usuario.Telefono %></label>
                    </p>
                </div>
            </div>
        </div>

    </div>

    <div class="row" style="margin-bottom: 50px; margin-top: 50px; justify-content: center">

        <div class="card col-md-6" style="width: 25%;">
            <h6 class="text-dark" style="margin-left: 50px; margin-top: 20px;">Compras:</h6>
            <div class="card-body" style="margin-left: 50px;">
                <table class="table" style="margin-left: 30px; margin-right: 10px; width: 70%;">

                    <tr>
                        <td class="text-dark">Nr. Compra</td>
                        <td class="text-dark">Monto</td>
                        <td class="text-dark">Fecha</td>
                    </tr>
                    <% foreach (var item in compras)
                        { %>
                    <tr>
                        <td class="text-dark"><% = item.Id %></td>
                        <td class="text-dark">$ <% = item.Monto %></td>
                        <td class="text-dark"><% = item.Fecha %></td>
                    </tr>
                    <% } %>
                </table>
            </div>
        </div>

    </div>


</asp:Content>
