<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NoEsUsuario.aspx.cs" Inherits="Web.NoEsUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row" style="margin-bottom: 50px; margin-top: 50px; justify-content: center">

        <div class="card col-md-8" style="width: 25%;">

            <div class="card-body" style="margin-left: 20px; justify-content: center">

                <h1 class="card-title">No esta logueado,</h1>
                <h1 class="card-title">Para continuar la compra debe estar logueado</h1>

                <div style="margin-top:30px;">

                    <a href="Login.aspx" class="btn btn-primary" style="margin-left: 190px;">Iniciar Sesion</a>
                    <a href="Registracion.aspx" class="btn btn-primary" style="margin-left: 190px;">Registrarse</a>
                    <a href="Listado.aspx" class="btn btn-primary" style="margin-left: 190px;">Pagina Principal</a>

                </div>

            </div>

        </div>

    </div>

</asp:Content>
