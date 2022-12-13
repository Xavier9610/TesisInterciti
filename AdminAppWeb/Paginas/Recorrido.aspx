<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recorrido.aspx.cs" Inherits="AdminAppWeb.Paginas.Recorrido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
          
               <asp:Label ID="Label9" runat="server" ForeColor="#0099FF" HorizontalAlign="Center" Text="Administración de Recorrido" BorderStyle="None"></asp:Label>
          
    <br />
    
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:TextBox ID="txtFiltro" runat="server" Height="22px" Hint="buscar..."></asp:TextBox></asp:TableCell>
            <asp:TableCell runat="server"><asp:Button ID="btnFiltrar" runat="server" OnClick="Button1_Click" Text="Buscar" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    
    
    <br />
    <asp:GridView ID="grdVRecorrido" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ODSRecorrido" ForeColor="#333333" GridLines="None" Height="170px" OnSelectedIndexChanged="lbxConductores_SelectedIndexChanged" Width="87px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="IdRecorrido" HeaderText="ID" SortExpression="IdRecorrido" />
            <asp:BoundField DataField="LatitudOrigen" HeaderText="LatitudOrigen" SortExpression="LatitudOrigen" />
            <asp:BoundField DataField="FechaRecorrido" HeaderText="FechaRecorrido" SortExpression="FechaRecorrido" />
            <asp:BoundField DataField="IdCliente" HeaderText="IdCliente" SortExpression="IdCliente" />
            <asp:BoundField DataField="IdConductor" HeaderText="IdConductor" SortExpression="IdConductor" />
            <asp:BoundField DataField="LatitudDestino" HeaderText="LatitudDestino" SortExpression="LatitudDestino" />
            <asp:BoundField DataField="LongitudDestino" HeaderText="LongitudDestino" SortExpression="LongitudDestino" />
            <asp:BoundField DataField="LongitudOrigen" HeaderText="LongitudOrigen" SortExpression="LongitudOrigen" />
            <asp:BoundField DataField="ValorRecorrido" HeaderText="ValorRecorrido" SortExpression="ValorRecorrido" />
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
     <asp:ObjectDataSource ID="ODSRecorrido" runat="server" SelectMethod="ListarRecorrido" TypeName="AdminAppWeb.ServiceReferenceInterciti.ServiceClient"></asp:ObjectDataSource>
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
