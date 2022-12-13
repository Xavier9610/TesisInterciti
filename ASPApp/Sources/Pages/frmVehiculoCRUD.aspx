<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/Pages/MPInterciti.Master" AutoEventWireup="true" CodeBehind="frmVehiculoCRUD.aspx.cs" Inherits="ASPApp.Sources.Pages.frmVehiculoCRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
    <script defer src="https://use.fontawesome.com/releases/v5.15.4/js/all.js" integrity="sha384-rOA1PnstxnOBLzCLMcre8ybwbTmemjzdNlILg8O7z1lUkLXozs4DHonlDtnE7fpc" crossorigin="anonymous"></script>
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
                        <legend class="row justify-content-center"> Datos de Vehículo</legend>
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
                            <asp:Label runat="server" CssClass="form-control" Text="Marca:"></asp:Label>
                            <asp:DropDownList runat="server" DataSourceID="ObjectDataSource1" DataTextField="Marca" DataValueField="IdMarca" ID="txtMarca"></asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListarMarcaVehiculo" TypeName="ASPApp.ServiceReferenceInterciti.ServiceClient"></asp:ObjectDataSource>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Modelo:"></asp:Label>
                            <asp:DropDownList runat="server" DataSourceID="ObjectDataSource2" DataTextField="Modelo" DataValueField="IdModelo" ID="txtModelo"></asp:DropDownList>
                            
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="ListarModeloVehiculo" TypeName="ASPApp.ServiceReferenceInterciti.ServiceClient"></asp:ObjectDataSource>
                            
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Tipo:"></asp:Label>
                            <asp:DropDownList runat="server" DataSourceID="tipo" DataTextField="Tipo" DataValueField="IdTipoVehiculo" ID="txtTipo" ></asp:DropDownList>
                            <asp:ObjectDataSource ID="tipo" runat="server" SelectMethod="ListarTipoVehiculo" TypeName="ASPApp.ServiceReferenceInterciti.ServiceClient"></asp:ObjectDataSource>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Año:"></asp:Label>
                            <asp:DropDownList runat="server" DataSourceID="an" DataTextField="Año" DataValueField="IdAño" ID="anio"></asp:DropDownList>
                            <asp:ObjectDataSource ID="an" runat="server" SelectMethod="ListarAnioVehiculo" TypeName="ASPApp.ServiceReferenceInterciti.ServiceClient"></asp:ObjectDataSource>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Placa:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPlaca"></asp:TextBox>
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
