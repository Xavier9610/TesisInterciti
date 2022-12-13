<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUDConductor.aspx.cs" Inherits="AdminAppWeb.Paginas.CRUDConductor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
        <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
            <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:Label ID="Label9" runat="server" ForeColor="#0099FF" HorizontalAlign="Center" Text="Administración de conductores" BorderStyle="None"></asp:Label>
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
        <asp:Table ID="tblCliente" runat="server" ForeColor="#0066FF" GridLines="Vertical" HorizontalAlign="Left">
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
                  <asp:TableRow runat="server" HorizontalAlign="Left">
                      <asp:TableCell runat="server"><asp:Label ID="Label16" runat="server" Text="Numero de Licencia:"></asp:Label></asp:TableCell>
                      <asp:TableCell runat="server"><asp:TextBox ID="txtLicencia" runat="server" Width="100px" HorizontalAlign="Left"></asp:TextBox></asp:TableCell>
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
                                <asp:TableCell runat="server" Width="100px">
                                    <asp:Calendar ID="cFechaNacimiento" OnSelectionChanged="cFecha_Clicked" runat="server" Visible="false" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="130px" NextPrevFormat="FullMonth" Width="300px">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                                </asp:Calendar>
                                <div >
                                    <asp:TextBox ID="txtFecha" runat="server" Width="70px" VerticalAlign="Middle" HorizontalAlign="Left" OnTextChanged="TxtFecha_TextChanged1"></asp:TextBox>
                                <asp:Button ID="btnCalendario" runat="server" Text="Calendario" Width="80px" VerticalAlign="Middle" HorizontalAlign="Right" OnClick="btnCalendario_Clicked"/>
                                </div>
                            
                    </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server"  VerticalAlign="Middle">
                                  <asp:TableCell runat="server" Height="40px" HorizontalAlign="Right">
                                      <asp:Label ID="Label8" runat="server" Text="Contraseña:" HorizontalAlign="Right"></asp:Label>
                               
    </asp:TableCell>
                                   <asp:TableCell runat="server">
                                        <input ID="txtPass" type="password" runat="server" HorizontalAlign="Left"/>
                                
    </asp:TableCell>
                        </asp:TableRow>
    <asp:TableRow runat="server" Height="40px" HorizontalAlign="Center" VerticalAlign="Middle">
            <asp:TableCell runat="server" HorizontalAlign="Center"></asp:TableCell>
            <asp:TableCell runat="server" HorizontalAlign="Left">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Clicked" />
            </asp:TableCell>
        </asp:TableRow>
           </asp:Table>
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
    <br />
    <asp:Button ID="btnRegresar" HorizontalAlign="Left" runat="server"  Text="&lt;&lt;Regresar" OnClick="btnVolver_Clicked"/>
</asp:Content>
