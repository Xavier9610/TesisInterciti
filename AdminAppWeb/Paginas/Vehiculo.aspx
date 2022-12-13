<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vehiculo.aspx.cs" Inherits="AdminAppWeb.Paginas.Vehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
        
               <asp:Label ID="Label9" runat="server" ForeColor="#0099FF" HorizontalAlign="Center" Text="Administración de Vehiculo" BorderStyle="None"></asp:Label>
   
    <br />
         
    <br />
    
    <asp:Table ID="Table1" runat="server" HorizontalAlign="Left">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:TextBox ID="txtFiltro" runat="server" Height="22px" Hint="buscar..."></asp:TextBox></asp:TableCell>
            <asp:TableCell runat="server"><asp:Button ID="btnFiltrar" runat="server" OnClick="Button1_Click" Text="Buscar" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label10" runat="server" Text="       Buscar Por: "></asp:Label>
    
    
    
    <asp:DropDownList ID="ddlFlist" runat="server" AutoPostBack="True" Height="24px" Width="190px">
        <asp:ListItem Value="N">NOMBRE</asp:ListItem>
        <asp:ListItem Value="I">ID</asp:ListItem>
        <asp:ListItem Value="A">APELLIDO</asp:ListItem>
        <asp:ListItem Value="C">CORREO</asp:ListItem>
    </asp:DropDownList>
    
    
    
    <br />
    &nbsp;<br />
    
    <br />
    <asp:GridView ID="grdVVehiculo" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="3" DataSourceID="ODSVehiculo" GridLines="Vertical" Height="160px" OnSelectedIndexChanged="lbxVehiculos_SelectedIndexChanged" Width="158px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px">
        <AlternatingRowStyle BackColor="Gainsboro" />
        <Columns>
            <asp:BoundField DataField="IdVehiculo" HeaderText="IdVehiculo" SortExpression="IdVehiculo" />
            <asp:BoundField DataField="Marca1" HeaderText="Marca1" SortExpression="Marca1" />
            <asp:BoundField DataField="Modelo1" HeaderText="Modelo1" SortExpression="Modelo1" />
            <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa" />
            <asp:BoundField DataField="Tipo1" HeaderText="Tipo1" SortExpression="Tipo1" />
            <asp:BoundField DataField="Año1" HeaderText="Año1" SortExpression="Año1" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
     <asp:ObjectDataSource ID="ODSVehiculo" runat="server" SelectMethod="ListarVehiculo" TypeName="AdminAppWeb.ServiceReferenceInterciti.ServiceClient"></asp:ObjectDataSource>
          <br />

    <asp:Table ID="tblBotones" runat="server" HorizontalAlign="Center">
        <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="40px">
            <asp:TableCell runat="server" HorizontalAlign="Center" Width="100px">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Clicked"/>
            

</asp:TableCell>
            <asp:TableCell runat="server" HorizontalAlign="Center" Width="100px">
                <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Clicked"/>
            

</asp:TableCell>
            <asp:TableCell runat="server" HorizontalAlign="Center" Width="100px">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Clicked"/>
            

</asp:TableCell>
        </asp:TableRow>
        
    </asp:Table>

</asp:Content>
