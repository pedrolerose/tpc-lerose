<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebApp.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="margin-left:50px;margin-top:20px;">Detalle</h1>
    <div class="row" style="margin-bottom:50px;margin-top:50px; justify-content: center">
        <div class="card col-md-4" style="width: 25%;" >
            <div class="card-body" style="margin-left: 50px;">
                <h5 class="card-title"><% = articulo.Nombre %></h5>
                <p class="card-text"><% = articulo.Marca.Descripcion %></p>
                <p class="card-text">$ <% = decimal.Round(articulo.Precio, 2, MidpointRounding.AwayFromZero) %></p>
                <p class="card-text"><% = articulo.Descripcion %></p>
                <button class="btn btn-success" onclick="<% AgregarCarrito(articulo); %>">Agregar al Carrito</button>
            </div>
        </div>
    <div class="card col-md-4" style="width: 100px;" >
            <img src="<% = articulo.Imagen %>" class="card-img-top" alt="...">
        </div>
        </div>
    <a href="Listado.aspx" class="btn btn-info" style="margin-left: 70px;">Listado</a>
</asp:Content>
