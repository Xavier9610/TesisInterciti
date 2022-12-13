<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/Pages/MPInterciti.Master" AutoEventWireup="true" CodeBehind="frmPerfil.aspx.cs" Inherits="ASPApp.Sources.Pages.frmPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Perfil
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container d-flex justify-content-center">
            <div class="col-8">
                <div class="form-control card card-body">
                    <div class="row justify-content-center">
                        <asp:Label runat="server" CssClass="row justify-content-center h3">Registro de Usuarios</asp:Label>
                    </div>
                    <fieldset>
                        <legend class="row justify-content-center">Datos Personales</legend>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Foto:"></asp:Label>
                            <img src="~/Sources/Images/user.png" class="img-thumbnail" height="150" width="150" id="fotoUsuario" runat="server" />
                        </div>
                        <div class="input-group">
                            <input type="file" onchange="mostrarImage(this)" runat="server" class="small form-control" ID="FUImage"/>
                        </div>
                        <div class="input-group">
                            <asp:Label ID="lblInfo" runat="server" CssClass="alert-danger" Text=""></asp:Label>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Nombre:"></asp:Label>
                            <input runat="server" class="form-control" type="text" id="txtNombre" />
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Apellido:"></asp:Label>
                            <input runat="server" class="form-control" type="text" id="txtApellido" />
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Cédula:"></asp:Label>
                            <input runat="server" class="form-control" type="number" id="txtCedula" />
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Correo electrónico:"></asp:Label>
                            <input runat="server" class="form-control" type="email" id="txtCorreo" />
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Fecha de Nacimiento:"></asp:Label>
                            <input runat="server" class="form-control" type="date" id="dateB" max="2004-08-31"/>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Teléfono:"></asp:Label>
                            <input runat="server" class="form-control" type="tel" id="txtTelefono" />
                        </div>
                        
                    </fieldset>
                    <br />
                    <div class="row">
                        <button runat="server" CssClass="form-control btn btn-success" OnClick="Guardar_Click">Guardar</button>         
                    </div>
                    <br />
                    <div class="row">
                        <button runat="server" CssClass="form-control btn btn-danger" OnClick="Cancelar_Click">Regresar</button>
                    </div>
                     <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Cambiar contrase:"></asp:Label>
                           
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Contraseña:"></asp:Label>
                            <input runat="server" class="form-control" type="password" id="txtPass" />
                            <asp:Label runat="server" CssClass="form-control" Text="Confirmar Contraseña:"></asp:Label>
                            <input runat="server" class="form-control" type="password" id="txtPassC" />
                        </div>
                    <br />
                    <div class="row">
                        <button runat="server" class="form-control btn btn-dark" onclick="Cambiar_Click" >Cambiar Contraseña</button>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
