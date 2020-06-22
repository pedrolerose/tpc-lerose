<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="WebApp.Listado" %>

<asp:Content runat="server" ID="Listado" ContentPlaceHolderID="ContentPlaceHolder1">

    <h1 style="margin-left: 50px; margin-top: 20px;" class="text-dark">Lista Articulos</h1>

    <div class="row" style="margin-top: 10px; justify-content: center">
        <div class="btn-group dropright">
            <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                Filtrar por Categoria
            </button>
            <div class="dropdown-menu">
                <% foreach (var cat in categorias)
                    { %>
                <a href="Listado.aspx?idcat=<% = cat.Id.ToString() %>" class="dropdown-item"><% = cat.Descripcion %></a>
                <% } %>
                <div class="dropdown-divider"></div>
                <a href="Listado.aspx" class="dropdown-item">Quitar Filtro</a>
            </div>
        </div>
    </div>

    <div class="row" style="margin: 50px; justify-content: center">
        <div class="card-group" style="margin-left: 10px; margin-right: 10px;">

            <% foreach (var item in listaArticulos)
                { %>
            <div class="card">

                <a href="Detalle.aspx?idart=<% = item.Id.ToString() %>">
                    <div class="row" style="margin: 10px; height: 200px;">
                        <img src="<% = item.Imagen %>" class="card-img-top" alt="..." style="height: 200px; width: 200px;">
                    </div>
                </a>

                <div class="card-body">

                    <a href="Detalle.aspx?idart=<% = item.Id.ToString() %>">
                        <div class="row" style="margin: 10px; height: 50px;">
                            <h5 class="card-title text-dark"><% = item.Nombre %></h5>
                        </div>
                    </a>

                    <div class="row" style="margin: 10px; height: 25px;">
                        <p class="card-text text-dark">$ <% = decimal.Round(item.Precio, 2, MidpointRounding.AwayFromZero) %></p>
                    </div>

                    <div class="row" style="margin: 10px; height: 38px;">
                        <a href="Listado.aspx?idart=<% = item.Id.ToString() %>" class="btn btn-success">
                            <svg class="bi bi-cart3" width="1em" height="1em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                <path fill-rule="evenodd" d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .49.598l-1 5a.5.5 0 0 1-.465.401l-9.397.472L4.415 11H13a.5.5 0 0 1 0 1H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l.84 4.479 9.144-.459L13.89 4H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 0 0 2 1 1 0 0 0 0-2zm7 0a1 1 0 1 0 0 2 1 1 0 0 0 0-2z" />
                            </svg>
                            Agregar
                        </a>
                    </div>

                </div>
            </div>
            <% } %>
        </div>
    </div>

</asp:Content>
