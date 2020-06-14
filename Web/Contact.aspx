<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="margin-left: 50px; margin-top: 20px;">Contacto</h1>
    <h3 style="margin-left: 50px; margin-top: 20px;">Queres decirnos algo?</h3>

    <div class="row" style="margin-bottom: 50px; margin-top: 50px; justify-content: center">
        <div class="card col-md-6" style="width: 25%;">
            <div class="card-body" style="margin-left: 20px; justify-content: center">
                <address>
                    Center Pepe Sa<br />
                    Calle False 123, BA 98052-6399<br />
                    <abbr title="Telefono">Telefono:</abbr>
                    425.555.0100 (lineas rotativas / osea no te atendemos)
                </address>
                <address>
                    <strong>Soporte:</strong>   <a href="mailto:Soporte@mentira.com">Soporte@mentira.com</a><br />
                    <strong>Trabajo:</strong> <a href="mailto:Trabajo@mentira.com">Trabajo@mentira.com</a>
                </address>
                <a href="Listado.aspx" class="btn btn-primary" style="margin-left: 190px;">Pagina Principal</a>
            </div>
        </div>
    </div>

</asp:Content>
