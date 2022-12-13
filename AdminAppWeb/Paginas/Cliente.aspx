<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="AdminAppWeb.Paginas.Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       
               <asp:Label ID="Label9" runat="server" ForeColor="#0099FF" HorizontalAlign="Center" Text="Administración de clientes" BorderStyle="None" Height="40px" Width="209px"></asp:Label>
         
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
    <asp:GridView ID="grdVCliente" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ODSCliente" ForeColor="#333333" GridLines="None" Height="56px" OnSelectedIndexChanged="lbxClientes_SelectedIndexChanged" Width="469px" HorizontalAlign="Left">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="IdCliente" HeaderText="ID" SortExpression="IdCliente" />
            <asp:BoundField DataField="Apellido" HeaderText="APELLIDO" SortExpression="Apellido" />
            <asp:BoundField DataField="Nombre" HeaderText="NOMBRE" SortExpression="Nombre" />
            <asp:BoundField DataField="Cedula" HeaderText="CI" SortExpression="Cedula" />
            <asp:BoundField DataField="Correo" HeaderText="CORREO" SortExpression="Correo" />
            <asp:BoundField DataField="Telefono" HeaderText="PHONE" SortExpression="Telefono" />
            <asp:BoundField DataField="FechaNacimiento" HeaderText="BIRTH" SortExpression="FechaNacimiento" DataFormatString="MM/dd/yyyy" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>

    <asp:ObjectDataSource ID="ODSCliente" runat="server" SelectMethod="ListarClientes" TypeName="AdminAppWeb.ServiceReferenceInterciti.ServiceClient"></asp:ObjectDataSource>

          <br />
          <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
          <br />
    <asp:Table ID="tblBotones" runat="server" HorizontalAlign="Justify">
        <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="40px">
            <asp:TableCell runat="server" HorizontalAlign="Center" Width="100px">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Clicked " />
               
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
