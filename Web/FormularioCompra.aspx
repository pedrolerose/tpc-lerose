<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCompra.aspx.cs" Inherits="WebApp.FormularioCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="margin-left: 50px; margin-top: 20px;">Informacion para el envio</h1>
    <div class="row" style="margin-left: 500px;">
        <div class="col-md-12">

            <div class="row col-center">

                <div class="row">
                    <div class="row col-md-10 form-check" style="margin: 30px;">

                        <div class="row">
                            <label class="form-check-label">Nombre:</label>
                            <input class="form-control" type="text" name="name" value="" />
                        </div>
                        <div class="row">
                            <label class="form-check-label">Apellido:</label>
                            <input class="form-control" type="text" name="name" value="" />
                        </div>
                        <div class="row">
                            <label class="form-check-label">Dni:</label>
                            <input class="form-control" type="text" name="name" value="" />
                        </div>

                    </div>
                </div>

                <div class="row">
                    <div class="row col-md-10 form-check" style="margin: 30px;">

                        <div class="row">
                            <label class="form-check-label">Direccion:</label>
                            <input class="form-control" type="text" name="name" value="" />
                        </div>
                        <div class="row">
                            <label class="form-check-label">Mail:</label>
                            <input class="form-control" type="text" name="name" value="" />
                        </div>
                        <div class="row">
                            <label class="form-check-label">Telefono:</label>
                            <input class="form-control" type="text" name="name" value="" />
                        </div>

                    </div>
                </div>

            </div>

            <div class="row">
                <button class="btn btn-success" onclick="<% Finalizar(); %>" style="width: 250px;margin-left:350px;">Finalizar Compra</button>
            </div>

        </div>
    </div>

    <div class="row">
        <a href="MiCarrito.aspx" class="btn btn-info" style="margin-left: 70px;">Atras</a>
    </div>
     <div class="row">
         <p style="margin-left: 538px;color: #b6b2b2">Si no completa la informacion nos quedamos con el dinero, Politica de la empresa</p>
    </div>
</asp:Content>
