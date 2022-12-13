<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="ASPApp.Sources.Pages.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Inicio de Sesión</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
</head>
<body runat="server">
    <form id="frmLogin" runat="server" class="container d-flex justify-content-center align-items-center">
        <div runat="server" class="col-5">
            <div runat="server" class="modal-title align-content-lg-center h3">
                <asp:Label runat="server" Text="Inicio de Sesión" Font-Size="Larger" ForeColor="ForestGreen"></asp:Label>
            </div>
            <div runat="server" class="form-control card card-body align-items-center h3">
                <asp:Image runat="server" ImageUrl="~/Sources/Images/logoInterciti.png" Height="200"/>
                <asp:Label runat="server" ID="lblInfo" CssClass="alert-danger"></asp:Label>
            </div>
            <br />
            <div runat="server" class="input-group">
                <asp:Label runat="server" CssClass="form-control" >Correo electrónico</asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtUsuario"></asp:TextBox>
            </div>
            <br />
            <div runat="server" class="input-group">
                <asp:Label runat="server" CssClass="form-control" >Contraseña</asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" ID="txtPass"></asp:TextBox>
            </div>
            <br />
            <div runat="server" class="input-group">
             <%--   <asp:Button runat="server" Text="Iniciar de Sesión"" CssClass="form-control btn btn-success" ID="btnLogin"  />--%>
                <button id="btnLogin" runat="server" class="form-control btn btn-success" onserverclick="btnLogin_ServerClick"> Iniciar de Sesión</button>
            </div>
            <br />
            <br />
            <div runat="server" class="input-group align-content-center">
                <asp:Label runat="server" Text="No tienes cuenta? Registrate"></asp:Label>
                <asp:LinkButton runat="server" Text="Aqui!" PostBackUrl="~/Sources/Pages/frmRegistro.aspx"></asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
