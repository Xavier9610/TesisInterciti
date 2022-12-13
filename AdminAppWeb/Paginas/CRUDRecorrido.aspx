﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUDRecorrido.aspx.cs" Inherits="AdminAppWeb.Paginas.CRUDRecorrido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
            <br />
            <br />
            <br />
    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
        <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
            <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:Label ID="Label9" runat="server" ForeColor="#0099FF" HorizontalAlign="Center" Text="Administración de recorridos" BorderStyle="None"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
            <br />
    <asp:Table ID="tblCliente" runat="server" OnDataBinding="lbxClientes_SelectedIndexChanged" ForeColor="#0066FF" GridLines="Vertical" HorizontalAlign="Center">
        <asp:TableRow runat="server"  VerticalAlign="Middle">
                <asp:TableCell runat="server" Height="40px" VerticalAlign="Middle" HorizontalAlign="Right">
                    <asp:Label ID="Label1" runat="server" Text="ID:" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell runat="server" Width="100px">
                     <asp:TextBox ID="txtID" runat="server" Width="100px" HorizontalAlign="Left"></asp:TextBox>
                </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server"  VerticalAlign="Middle">
                 <asp:TableCell runat="server" Height="40px" HorizontalAlign="Right">
                      <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell runat="server" Width="100px" >
                      <asp:TextBox ID="txtNombre" runat="server" Width="100px" HorizontalAlign="Left"></asp:TextBox>
                </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow runat="server"  VerticalAlign="Middle">
                 <asp:TableCell runat="server" Height="40px" HorizontalAlign="Right">
                       <asp:Label ID="Label3" runat="server" Text="Apellido:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell runat="server" Width="100px">
                        <asp:TextBox ID="txtApellido" runat="server" Width="100px" HorizontalAlign="Left"></asp:TextBox>
                </asp:TableCell>
             </asp:TableRow>
             <asp:TableRow runat="server"  VerticalAlign="Middle">
                        <asp:TableCell runat="server" Height="40px" HorizontalAlign="Right">
                            <asp:Label ID="Label4" runat="server" Text="C.I:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" Width="100px">
                             <asp:TextBox ID="txtCI" runat="server" Width="100px" HorizontalAlign="Left"></asp:TextBox>
                        </asp:TableCell>
               </asp:TableRow>
               <asp:TableRow runat="server"  VerticalAlign="Middle">
                         <asp:TableCell runat="server" Height="40px" HorizontalAlign="Right">
                            <asp:Label ID="Label5" runat="server" Text="Correo:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" Width="200px">
                            <asp:TextBox ID="txtCorreo" runat="server" Width="200px" HorizontalAlign="Left"></asp:TextBox>
                        </asp:TableCell>
              </asp:TableRow>
              <asp:TableRow runat="server" VerticalAlign="Middle">
                         <asp:TableCell runat="server" Height="40px" HorizontalAlign="Right">                                    
                             <asp:Label ID="Label6" runat="server" Text="Telefono"></asp:Label>
                          </asp:TableCell>
                          <asp:TableCell runat="server" Width="100px">
                             <asp:TextBox ID="txtTelefono" runat="server" Width="100px" HorizontalAlign="Left"></asp:TextBox>
                           </asp:TableCell>
               </asp:TableRow>
               <asp:TableRow runat="server" HorizontalAlign="Right" VerticalAlign="Middle">
                            <asp:TableCell runat="server" Height="40px" HorizontalAlign="Right">
                              <asp:Label ID="Label7" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server" Width="100px" HorizontalAlign="Center">
                                <asp:Calendar ID="cFechaNacimiento" runat="server" Visible="false" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="130px" NextPrevFormat="FullMonth" Width="300px">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                                </asp:Calendar>
                                <div >
                                    <asp:TextBox ID="TextBox1" runat="server" Width="100px" VerticalAlign="Middle" HorizontalAlign="Left"></asp:TextBox>
                                <asp:Button ID="btnCalendario" runat="server" Text="Calendario" Width="60px" VerticalAlign="Middle" HorizontalAlign="Right" OnClick="btnCalendario_Clicked"/>
                                </div>
                                
                            </asp:TableCell>
                </asp:TableRow>
       </asp:Table>
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
        <asp:TableRow runat="server" Height="40px" HorizontalAlign="Center" VerticalAlign="Middle">
            <asp:TableCell runat="server" HorizontalAlign="Center"></asp:TableCell>
            <asp:TableCell runat="server" HorizontalAlign="Center">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Clicked" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
</asp:Content>
