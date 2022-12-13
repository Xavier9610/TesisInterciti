<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/Pages/MPInterciti.Master" AutoEventWireup="true" CodeBehind="frmCliente.aspx.cs" Inherits="ASPApp.Sources.Pages.frmCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
    <script defer src="https://use.fontawesome.com/releases/v5.15.4/js/all.js" integrity="sha384-rOA1PnstxnOBLzCLMcre8ybwbTmemjzdNlILg8O7z1lUkLXozs4DHonlDtnE7fpc" crossorigin="anonymous"></script>
    <script src="../JavaScript/Java.js"></script>
    <script src="https://kit.fontawesome.com/0075bf0f0e.js" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" class="container align-content-center">
        <br />
        <div class="mx-auto align-content-center" style="width:400px">
            <h2 class="align-content-center">Lista de Clientes</h2>
      </div>
        <br/>
            <div class="mx-auto align-content-center" style="width:450px">
            <div aria-orientation="horizontal" >
            <label class="align-content-center">Buscar por:</label>
            <asp:DropDownList class="align-content-center" ID="ddlFiltro" runat="server">
                <asp:ListItem Text="Nombre" Value="Nombre"></asp:ListItem>
                <asp:ListItem Text="Apellido" Value="Apellido"></asp:ListItem>
                <asp:ListItem Text="Cédula" Value="Cédula"></asp:ListItem>
                <asp:ListItem Text="E-mail" Value="E-mail"></asp:ListItem>
                <asp:ListItem Text="Fecha" Value="Fecha"></asp:ListItem>
                 <asp:ListItem Text="Todo" Value="Todo"></asp:ListItem>

            </asp:DropDownList>
            <label></label>
            <input type="search" placeholder="Buscar..." id="txtSearch" runat="server" />
            <button id="btnSearch" runat="server" style="align-content:center" onserverclick="btnSearch_ServerClick"><i class="fa-solid fa-magnifying-glass"></i></button>
        </div>
            </div>
        <br />
        <div>
            <asp:GridView ID="grdVCliente" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="56px" Width="469px" HorizontalAlign="Center" DataSourceID="ObjectDataSource">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField HeaderText="Opciones de Administrador">
                        <ItemTemplate>
                            <button id="bntSelect" onserverclick="bntSelect_Click" runat="server"><i class="fa-solid fa-eye" style="color:forestgreen"></i></button>
                            <button id="btnEliminar" onclick="return confirm('Are you certain you want to delete this product?');" onserverclick="btnEliminar_Click" runat="server"> <i class="fa-solid fa-trash"  style="color:red"></i> </button>  
                            <button id="btnModificar" onserverclick="btnModificar_Click" runat="server"> <i class="fa-solid fa-pen-to-square"  style="color:cornflowerblue"></i></button>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Foto">
                            <ItemTemplate>
                                <asp:Image id="Img1" runat="server" Width="65" Height="65" CssClass="rounded-circle img-thumbnail" ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String(ASPApp.Sources.Validaciones.Servicio.Decompress(     (byte[])  Eval("Picture")     ))%>' />
    
                            </ItemTemplate>   
                    </asp:TemplateField> 
                    <asp:BoundField DataField="Cedula" HeaderText="Cédula" SortExpression="Cedula" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" SortExpression="FechaNacimiento" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="ForestGreen" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="ForestGreen" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="ForestGreen" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="ForestGreen" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="ListarClientes" TypeName="ASPApp.ServiceReferenceInterciti.ServiceClient"></asp:ObjectDataSource>
  
        </div>
        
    </form>
        
    
</asp:Content>
