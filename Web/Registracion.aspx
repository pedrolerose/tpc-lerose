<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registracion.aspx.cs" Inherits="Web.Registracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="margin-left: 50px; margin-top: 20px;">Registracion</h1>
    <div class="row" style="margin-left: 500px;">
        <div class="col-md-12">

            <div class="row col-center">

                <div class="row">
                    <div class="row col-md-10 form-check" style="margin: 30px;">

                        <div class="row">
                            <label class="form-check-label">Mail:</label>
                            <asp:TextBox ID="mail" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label">Nombre y Apellido:</label>
                            <asp:TextBox ID="nombre" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label">Calle:</label>
                            <asp:TextBox ID="calle" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label">Provincia:</label>
                            <asp:TextBox ID="provincia" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                         <div class="row">
                            <label class="form-check-label">Codigo Postal:</label>
                            <asp:TextBox ID="postal" CssClass="form-control btn-secondary" runat="server" />
                        </div>

                    </div>
                </div>

                <div class="row">
                    <div class="row col-md-10 form-check" style="margin: 30px;">

                        <div class="row">
                            <label class="form-check-label">Clave:</label>
                            <asp:TextBox ID="clave" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label">Nr. Documento:</label>
                            <asp:TextBox ID="documento" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label">Telefono:</label>
                            <asp:TextBox ID="telefono" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label">Nr. Calle:</label>
                            <asp:TextBox ID="numeroCalle" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label">Localidad:</label>
                            <asp:TextBox ID="localidad" CssClass="form-control btn-secondary" runat="server" />
                        </div>

                    </div>
                </div>

            </div>

            <div class="row">
                <button class="btn btn-success" onclick="<% Registrar(); %>" style="width: 250px;margin-left:350px;">Registrar</button>
            </div>

        </div>
    </div>


</asp:Content>
