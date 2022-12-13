<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUDVehiculo.aspx.cs" Inherits="AdminAppWeb.Paginas.CRUDVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     
     
      
     
     <br />

    
     <asp:Table ID="Table3" runat="server" HorizontalAlign="Center">
        <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
            <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:Label ID="Label15" runat="server" ForeColor="#0099FF" HorizontalAlign="Center" Text="Datos de vehiculo" BorderStyle="None"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table2" runat="server" HorizontalAlign="Left">
        <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
            <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:Label ID="lblInfoCrud" runat="server" ForeColor="#0099FF" HorizontalAlign="Center" Text="" BorderStyle="None"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    <br />
       
        <asp:Table ID="tblVehiculo" runat="server" Height="150px" HorizontalAlign="Center" Width="439px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Right"><asp:Label ID="Label11" runat="server" Text="I.D:"></asp:Label>
</asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="txtIDVehiculo" runat="server" Width="100px" HorizontalAlign="Left"></asp:TextBox>
</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Right"><asp:Label ID="Label12" runat="server" Text="Marca:"></asp:Label>
</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:DropDownList ID="ddlMarca" runat="server" DataSourceID="ODSMarca" DataTextField="Marca" DataValueField="Marca">
     </asp:DropDownList>
     <asp:ObjectDataSource ID="ODSMarca" runat="server" SelectMethod="ListarMarcaVehiculo" TypeName="AdminAppWeb.ServiceReferenceInterciti.ServiceClient"></asp:ObjectDataSource>
    
     <asp:Button ID="btnAgregarMarca" runat="server" Text="Agregar Marca" OnClick="btnAgregarMarcaVehiculo_Clicked" />
      <asp:TextBox ID="txtMarcaNew" runat="server" Visible ="false"></asp:TextBox>
      <asp:Button ID="btnGuardarMarca" runat="server" Text="Guardar Marca" Visible="false"  OnClick="btnGuardarMarcaVehiculo_Clicked"/>
</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Right"><asp:Label ID="Label10" runat="server" Text="Modelo:"></asp:Label>
</asp:TableCell>
                <asp:TableCell runat="server">
              <asp:DropDownList ID="ddlModelo" Width="100px" OnSelectedIndexChanged="DdlModelo_SelectedIndexChanged" runat="server" DataSourceID="ODSModelo" DataTextField="Modelo" DataValueField="Modelo">
     </asp:DropDownList>
     <asp:ObjectDataSource ID="ODSModelo" runat="server" SelectMethod="ListarModeloVehiculo" TypeName="AdminAppWeb.ServiceReferenceInterciti.ServiceClient">
         
     </asp:ObjectDataSource>  
      <asp:Button ID="btnAgregarModelo" runat="server" Text="Agregar Modelo" OnClick="btnAgregarModeloVehiculo_Clicked" />
      <asp:TextBox ID="txtModelo" runat="server" Visible ="false"></asp:TextBox>
      <asp:Button ID="btnGuardarModelo" runat="server" Text="Guardar Modelo" Visible="false"  OnClick="btnGuardarModeloVehiculo_Clicked"/>
</asp:TableCell>
                
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Right"><asp:Label ID="Label1" runat="server" Text="Tipo:"></asp:Label>
</asp:TableCell>
                <asp:TableCell runat="server">
         <asp:DropDownList ID="ddlTipo" runat="server" DataSourceID="ODSTipo" DataTextField="Tipo" DataValueField="Tipo">
     </asp:DropDownList>
     <asp:ObjectDataSource ID="ODSTipo" runat="server" SelectMethod="ListarTipoVehiculo" TypeName="AdminAppWeb.ServiceReferenceInterciti.ServiceClient"></asp:ObjectDataSource>
       
      <asp:Button ID="btnAgregarTipo" runat="server" Text="Agregar Tipo" OnClick="btnAgregarTipoVehiculo_Clicked" />
      <asp:TextBox ID="txtTipo" runat="server" Visible ="false"></asp:TextBox>
      <asp:Button ID="btnGuardarTipo" runat="server" Text="Guardar Tipo" Visible="false"  OnClick="btnGuardarModeloVehiculo_Clicked"/>
</asp:TableCell>
                
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Right"><asp:Label ID="Label13" runat="server" Text="Año:"></asp:Label>
</asp:TableCell>
                <asp:TableCell runat="server">   
                    <asp:DropDownList ID="ddlAño" runat="server" DataSourceID="ODSAño" DataTextField="Año" DataValueField="Año">
     </asp:DropDownList>
     <asp:ObjectDataSource ID="ODSAño" runat="server" SelectMethod="ListarAñoVehiculo" TypeName="AdminAppWeb.ServiceReferenceInterciti.ServiceClient"></asp:ObjectDataSource>
               
</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center"><asp:Button ID="btnGuardarVehiculo" runat="server" Text="Guardar" OnClick="btnGuardarVehiculo_Clicked"/></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Right"><asp:Label ID="Label14" runat="server" Text="Placa:"></asp:Label>
</asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="txtPlacaVehiculo" runat="server" Width="100px" HorizontalAlign="Left"></asp:TextBox>
</asp:TableCell>
            </asp:TableRow>
        </asp:Table>

</asp:Content>
