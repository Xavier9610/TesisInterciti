<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/Pages/MPInterciti.Master" AutoEventWireup="true" CodeBehind="frmAño.aspx.cs" Inherits="ASPApp.Sources.Pages.frmAño" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="https://kit.fontawesome.com/0075bf0f0e.js" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" class="container align-content-center">
        <br />
        <div class="mx-auto align-content-center" style="width:300px">
            <h2 class="align-content-center">Lista de Administradores</h2>
        </div>        <div class="mx-auto align-content-center" style="width:400px">
            <div aria-orientation="horizontal" >
            <label class="align-content-center">Buscar por:</label>
            <asp:DropDownList class="align-content-center" ID="ddlFiltro" runat="server">
                <asp:ListItem Text="Tipo" Value="Tipo"></asp:ListItem>
                <asp:ListItem Text="Año" Value="Año"></asp:ListItem>
                <asp:ListItem Text="Modelo" Value="Modelo"></asp:ListItem>
                <asp:ListItem Text="Marca" Value="Marca"></asp:ListItem>
                <asp:ListItem Text="Placa" Value="Placa"></asp:ListItem>
                 <asp:ListItem Text="Todo" Value="Todo"></asp:ListItem>

            </asp:DropDownList>
            <label></label>
            <input type="search" placeholder="Buscar..." id="txtSearch" runat="server" />
            <button id="btnSearch" runat="server" style="align-content:center" onserverclick="btnSearch_ServerClick"><i class="fa-solid fa-magnifying-glass"></i></button>
        </div>
            </div>
        <br />
        <div class="mx-auto" style="width:300px" >
            <div class="row">
                <div class="col align-self-end">
                      <button id="btnCreate" onserverclick="btnCreate_Click" runat="server"><i class="fa-solid fa-square-plus"></i>Nuevo</button>
                </div>
            </div>
        </div>
        <br />
        <div>
            <asp:GridView ID="grdVCliente" runat="server" AllowPaging="True" HeaderStyle-HorizontalAlign="Center" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="56px" Width="469px" HorizontalAlign="Center" DataSourceID="ObjectDataSource">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField HeaderText="Opciones de administrador">
                        <ItemTemplate>
                            <button id="bntSelect" onserverclick="bntSelect_Click" runat="server"><i class="fa-solid fa-eye" style="color:forestgreen"></i></button>
                            <button id="btnEliminar" onclick="return confirm('Are you certain you want to delete this product?');" onserverclick="btnEliminar_Click" runat="server"> <i class="fa-solid fa-trash"  style="color:red"></i> </button>  
                            <button id="btnModificar" onserverclick="btnModificar_Click" runat="server"> <i class="fa-solid fa-pen-to-square"  style="color:cornflowerblue"></i></button>

                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Año" HeaderText="Año" SortExpression="Año" />
                    
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="ForestGreen" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="ForestGreen" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                <PagerStyle BackColor="ForestGreen" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="ForestGreen" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="ListarAnioVehiculo" TypeName="ASPApp.ServiceReferenceInterciti.ServiceClient"></asp:ObjectDataSource>
  
        </div>
        
    </form>
</asp:Content>
