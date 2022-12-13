<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/Pages/MPInterciti.Master" AutoEventWireup="true" CodeBehind="frmAdminCRUD.aspx.cs" Inherits="ASPApp.Sources.Pages.frmAdminCRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript/Java.js"></script>
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
                            <asp:Label  runat="server" CssClass="alert-infob" Text=""></asp:Label>
                        </div>
                        <legend class="row justify-content-center">Datos Personales</legend>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Foto:"></asp:Label>
                            <img src="~/Sources/Images/user.png" class="img-thumbnail" height="150" width="150" id="fotoUsuario" runat="server" />
                        </div>
                        <div class="input-group">
                            <asp:FileUpload onchange="mostrarImage(this)" runat="server" CssClass="small form-control" ID="FUImage" />
                        </div>
                        <div class="input-group">
                            <asp:Label ID="lblInfo" runat="server" CssClass="alert-danger" Text=""></asp:Label>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Nombre:"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="SingleLine" ID="txtNombre"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Apellido:"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="SingleLine" ID="txtApellido"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Cédula:"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="Number" ID="txtCedula"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Correo electrónico:"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="Email" ID="txtCorreo"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Activo:"></asp:Label>
                            <input runat="server" type="checkbox" id="estado" />
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Fecha de Nacimiento:"></asp:Label>
                            <input runat="server" class="form-control" type="date" id="dateB" max="2004-08-31"/>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Teléfono:"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="Phone" ID="txtTelefono"></asp:TextBox>
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
