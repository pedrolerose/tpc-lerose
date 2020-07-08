<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OlvidePass.aspx.cs" Inherits="Web.OlvidePass1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row" style="margin-bottom: 50px; margin-top: 50px; justify-content: center">

                        <div class="card col-md-4" style="width: 25%;">
                            <div class="card-body" style="margin-left: 50px;">

                                <div class="form-group">
                                    <img class="mb-4" src="/docs/4.5/assets/brand/bootstrap-solid.svg" alt="" width="72" height="72" />
                                    <h1 class="mb-3 text-dark">Nueva Clave</h1>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" ID="txtMail" type="text" CssClass="form-control" placeholder="Mail" required="" />
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" ID="txtDoc" type="text" CssClass="form-control" placeholder="Documento" required="" />
                                    </div>
                                    <a class="btn btn-lg btn-success" id="btnIngresar" href="OlvidePass.aspx?mail="+ <% = txtMail.Text %>+ "&doc=" +<% = txtDoc.Text %> >Enviar Mail</a>
                                </div>

                            </div>
                        </div>

</asp:Content>
