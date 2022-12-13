<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/Pages/MPInterciti.Master" AutoEventWireup="true" CodeBehind="frmRecorrido.aspx.cs" Inherits="ASPApp.Sources.Pages.frmRecorrido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="https://kit.fontawesome.com/0075bf0f0e.js" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" class="container align-content-center">
        <br />
        <div class="mx-auto align-content-center" style="width:400px">
            <h2 class="align-content-center">Lista de Recorridos</h2>
        </div>
         <br />
         <div class="mx-auto align-content-center" style="width:450px">
            <div aria-orientation="horizontal" >
            <label class="align-content-center">Buscar por:</label>
            <asp:DropDownList class="align-content-center" ID="ddlFiltro" runat="server">
                <asp:ListItem Text="Cliente" Value="Cliente"></asp:ListItem>
                <asp:ListItem Text="Conductor" Value="Conductor"></asp:ListItem>
                <asp:ListItem Text="Origen" Value="Origen"></asp:ListItem>
                <asp:ListItem Text="Destino" Value="Destino"></asp:ListItem>
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
            <asp:GridView ID="grdVCliente" runat="server"  AllowPaging="True" SortedAscendingCellStyle-Wrap="true" AutoGenerateColumns="False" CellSpacing="10" ForeColor="#333333" GridLines="None" Height="56" CellPadding="10" Width="600" HorizontalAlign="Center" DataSourceID="ObjectDataSource">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" HorizontalAlign="Center" />
                <Columns >
                    <asp:TemplateField HeaderText="Opciones de administrador">
                        <ItemTemplate>
                       <button id="bntSelect" onserverclick="bntSelect_Click" runat="server"><i class="fa-solid fa-eye" style="color:forestgreen"></i></button>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cliente">
                            <ItemTemplate>
                                <asp:Image id="Img1" runat="server" Width="65" Height="65" CssClass="rounded-circle img-thumbnail" ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String(ASPApp.Sources.Validaciones.Servicio.Decompress(     ((ASPApp.ServiceReferenceInterciti. Cliente)  Eval("IdCliente")).Picture     ))%>' />
                                <asp:Label runat="server" Text='<%#  ((ASPApp.ServiceReferenceInterciti. Cliente)  Eval("IdCliente")).Nombre+" " +((ASPApp.ServiceReferenceInterciti. Cliente)  Eval("IdCliente")).Apellido  %>'  ></asp:Label>
                            </ItemTemplate>   
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Conductor">
                            <ItemTemplate>
                                <asp:Image id="Img2" runat="server" Width="65" Height="65" CssClass="rounded-circle img-thumbnail" ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String(ASPApp.Sources.Validaciones.Servicio.Decompress(     ((ASPApp.ServiceReferenceInterciti. Conductor)  Eval("IdConductor")).Picture     ))%>' />
                                <asp:Label runat="server" Text='<%#  ((ASPApp.ServiceReferenceInterciti. Conductor)  Eval("IdConductor")).Nombre+" " +((ASPApp.ServiceReferenceInterciti. Conductor)  Eval("IdConductor")).Apellido  %>'  ></asp:Label>
                            </ItemTemplate>   
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Origen">
                            <ItemTemplate>
                               <asp:Label runat="server" Text='<%#  ((string)  Eval("Origen"))  %>' Width="150" Font-Size="Small" ></asp:Label>
                            </ItemTemplate>   
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Destino">
                            <ItemTemplate>
                               <asp:Label runat="server" Text='<%#  ((string)  Eval("Destino"))  %>' Width="150" Font-Size="Small"  ></asp:Label>
                            </ItemTemplate>   
                    </asp:TemplateField> 
                    <asp:BoundField DataField="EstadoRecorrido" HeaderText="Estado" SortExpression="EstadoRecorrido" />
                    <asp:BoundField DataField="FechaRecorrido" HeaderText="Fecha de Recorrido" SortExpression="FechaRecorrido" />
                    <asp:BoundField DataField="IdRecorrido" HeaderText="ID" SortExpression="IdRecorrido" />
                    <asp:BoundField DataField="ValorRecorrido" HeaderText="Valor de Recorrido" SortExpression="ValorRecorrido" />
                    <asp:BoundField DataField="Calificacion" HeaderText="Calificación" SortExpression="Calificacion" />
                    <asp:BoundField DataField="Comentario" HeaderText="Comentario" SortExpression="Comentario" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="ForestGreen" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="ForestGreen" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="ForestGreen" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="ForestGreen" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="ListarRecorrido" TypeName="ASPApp.ServiceReferenceInterciti.ServiceClient"></asp:ObjectDataSource>
  
        </div>
        
    </form>
</asp:Content>
