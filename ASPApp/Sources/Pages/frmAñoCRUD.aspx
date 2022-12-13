<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/Pages/MPInterciti.Master" AutoEventWireup="true" CodeBehind="frmAñoCRUD.aspx.cs" Inherits="ASPApp.Sources.Pages.frmAñoCRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="frmRegistro" runat="server">
        <div class="container d-flex justify-content-center">
            <div class="col-8">
                <div class="form-control card card-body">
                    <div class="row justify-content-center">
                        <asp:Label ID="lblTitulo" runat="server" CssClass="row justify-content-center h3"></asp:Label>
                    </div>
                    <fieldset>
                        <div class="input-group">
                            <asp:Label  runat="server" CssClass="alert-infob" Text="" ID="lblInfo"></asp:Label>
                        </div>
                        <legend class="row justify-content-center">AÑO</legend>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Año:"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="SingleLine" ID="txtAño"></asp:TextBox>
                        </div>
                    </fieldset>
                    <br />
                    <div class="row">
                        <asp:Button runat="server" ID="btnRegistrar" CssClass="form-control btn btn-success" Visible="false" Text="Registrar Cliente" OnClick="btnRegistrar_Click" />
                    </div>
                    <br />
                    <div class="row">
                        <asp:Button runat="server" ID="btnVolver" CssClass="form-control btn btn-danger" Text="Volver" OnClick="btnVolver_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
