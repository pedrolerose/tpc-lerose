<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormaPago.aspx.cs" Inherits="Web.FormaPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="margin-left: 100px; margin-top: 20px;">Seguro de tu compra? Ingrese el medio de pago</h1>
    <div class="row" style="margin-left: 500px;">
        <div class="col-md-12">

            <div class="row col-center">

                <div class="row">
                    <div class="row col-md-10 form-check" style="margin: 30px;">

                        <div class="row">
                            <label class="form-check-label">Numero de Tarjeta:</label>
                            <asp:TextBox ID="numeroTarjeta" CssClass="form-control btn-secondary" runat="server" />
                        </div>

                        <div class="row">
                            <label class="form-check-label">Nombre Titular:</label>
                            <asp:TextBox ID="nombreTitular" CssClass="form-control btn-secondary" runat="server" />
                        </div>

                        <div class="row">
                                <label class="form-check-label">Fecha Vencimiento:</label>
                            </div>
                        <div class="row">
                            <div class="col-md-4">
                                <asp:TextBox ID="vencimientoDia" CssClass="form-control btn-secondary" placeholder="Dia" runat="server" />
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="vencimientoMes" CssClass="form-control btn-secondary" placeholder="Mes" runat="server" />
                            </div>
                        </div>

                        <div class="row">
                            <label class="form-check-label">Cod. Seguridad:</label>
                            <asp:TextBox ID="codigo" CssClass="form-control btn-secondary" runat="server" />
                        </div>

                    </div>
                </div>


            </div>

            <div class="row">
                <button class="btn btn-success" onclick="<% Finalizar(); %>" style="width: 250px;margin-left:350px;">Finalizar Compra</button>
            </div>

        </div>
    </div>

    <style type="text/css"> 
    input::-webkit-input-placeholder { /* WebKit browsers */
        color:    #f51!important;
    }
    input:-moz-placeholder { /* Mozilla Firefox 4 to 18 */
        color:    #f51!important;
    }
    input::-moz-placeholder { /* Mozilla Firefox 19+ */
        color:    #f51!important;
    }
    input:-ms-input-placeholder { /* Internet Explorer 10+ */
        color:    #f51!important;
    }
</style>

</asp:Content>
