<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRegistro.aspx.cs" Inherits="ASPApp.Sources.Pages.frmRegistro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Registro de usuarios</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
    <script src="../JavaScript/JavaScript.js"></script>
</head>
<body>
    <form id="frmRegistro" runat="server">
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
                            <asp:Label runat="server" CssClass="form-control" Text="Fecha de Nacimiento:"></asp:Label>
                            <input runat="server" class="form-control" type="date" id="dateB" max="2004-08-31"/>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Teléfono:"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="Phone" ID="txtTelefono"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Contraseña:"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" ID="txtPass"></asp:TextBox>
                            <asp:Label runat="server" CssClass="form-control" Text="Confirmar Contraseña:"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" ID="txtPassC"></asp:TextBox>
                        </div>
                    </fieldset>
                    <br />
                    <div class="row">
                        <asp:Button runat="server" CssClass="form-control btn btn-success" Text="Registrarme" OnClick="Registrarme_Click" />
                        <br />
                        <br />
                        <asp:Button runat="server" CssClass="form-control btn btn-danger" Text="Cancelar" OnClick="Cancelar_Click" />
                    </div>
                    
                </div>
            </div>
        </div>
    </form>
</body>
</html>
