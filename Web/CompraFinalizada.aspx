<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompraFinalizada.aspx.cs" Inherits="WebApp.CompraFinalizada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row" style="margin-bottom: 50px; margin-top: 50px; justify-content: center">
        <div class="card col-md-6" style="width: 25%;">
            <div class="card-body" style="margin-left: 20px;justify-content: center">
                <h1 class="card-title">Su compra ha sido exitosa,</h1>
                <h1 class="card-title">en breve nos contactaremos</h1>
                <a href="Listado.aspx" class="btn btn-primary" style="margin-left: 190px;">Pagina Principal</a>
            </div>
        </div>
    </div>

</asp:Content>
