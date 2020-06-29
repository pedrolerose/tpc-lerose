<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaArticulo.aspx.cs" Inherits="Web.AltaArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-dark" style="margin-left: 50px; margin-top: 20px;"><% = leyenda %> Articulo</h1>
    <div class="row" style="margin-left: 500px;">
        <div class="col-md-12">

            <div class="row col-center">

                <div class="row">
                    <div class="row col-md-10 form-check" style="margin: 30px;">

                        <div class="row">
                            <label class="form-check-label text-dark">Codigo:</label>
                            <asp:TextBox ID="codigo" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Nombre:</label>
                            <asp:TextBox ID="nombre" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Descripcion:</label>
                            <asp:TextBox ID="descripcion" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Precio:</label>
                            <asp:TextBox ID="precio" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="row col-md-10 form-check" style="margin: 30px;">

                        <div class="row">
                            <label class="form-check-label text-dark">Marca:</label>
                            <asp:DropDownList ID="DropMarca" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Categoria:</label>
                            <asp:DropDownList ID="DropCategoria" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Imagen:</label>
                            <asp:TextBox ID="imagen" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <button class="btn btn-success" onclick="<% Agregar(); %>" style="width: 273px; height: 42px; margin-top: 20px;"><% = leyenda %></button>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>

