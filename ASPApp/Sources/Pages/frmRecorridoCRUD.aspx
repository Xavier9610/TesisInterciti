<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/Pages/MPInterciti.Master" AutoEventWireup="true" CodeBehind="frmRecorridoCRUD.aspx.cs" Inherits="ASPApp.Sources.Pages.frmRecorridoCRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
   <%-- <script src="//maps.google.com/maps?file=api&amp;v=2&amp;sensor=false&amp;key=AIzaSyA9aYe_5AjTo-ooOnOhQjnsWAeqBwA-ARs" type="text/javascript"></script>--%>
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false" type="text/javascript"></script>  
    <script>  
        var mapcode;
        var diag;
        function initialize() {
            mapcode = new google.maps.Geocoder();
            var lnt = new google.maps.LatLng(26.45, 82.85);
            var diagChoice = {
                zoom: 9,
                center: lnt,
                diagId: google.maps.MapTypeId.ROADMAP
            }
            diag = new google.maps.Map(document.getElementById('map_populate'), diagChoice);
        }
        function getmap() {
            var completeaddress = document.getElementById('txtDestino').innerText;

            mapcode.geocode({ 'address': completeaddress }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    diag.setCenter(results[0].geometry.location);
                    var hint = new google.maps.Marker({
                        diag: diag,
                        position: results[0].geometry.location
                    });
                } else {
                    alert('Location Not Tracked. ' + status);
                }
            });
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script> 
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
                        <legend class="row justify-content-center">Datos de Recorrido</legend>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Cliente:"></asp:Label>
                            <img src="~/Sources/Images/user.png" class="img-thumbnail" height="150" width="150" id="fotoCliente" runat="server" />
                            <div class="input-group">
                                <div class="input-group">
                                    <label>Nombre:</label>
                                    <asp:TextBox runat="server" ID="txtClienteNombre"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <label>Apellido:</label>
                                    <asp:TextBox runat="server" ID="txtClienteApellido"></asp:TextBox>
                                </div>
                                <asp:Button runat="server" ID="btnCliente" CssClass="btn btn-success form-control" Text="Ver informacion de Cliente" OnClick="btnCliente_Click" />
                             </div>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Cliente:"></asp:Label>
                            <img src="~/Sources/Images/user.png" class="img-thumbnail" height="150" width="150" id="fotoConductor" runat="server" />
                            <div class="input-group">
                                <div class="input-group">
                                    <label>Nombre:</label>
                                    <asp:TextBox runat="server" ID="txtConductorNombre"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <label>Apellido:</label>
                                    <asp:TextBox runat="server" ID="txtConductorApellido"></asp:TextBox>
                                </div>
                                <asp:Button runat="server" ID="btnConductor" CssClass="btn btn-success form-control" Text="Ver informacion de Conductor" OnClick="btnConductor_Click" />
                             </div>
                        </div>
                        <div class="input-group">
                            <asp:Label ID="lblInfo" runat="server" CssClass="alert-danger" Text=""></asp:Label>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Punto de Partida:"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="SingleLine" ID="txtOrigen"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Destino:"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="SingleLine" ID="txtDestino"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Calificacion:"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="Number" ID="txtCalificacion"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Comentario:"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="Email" ID="txtComentario"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Fecha de Recorrido:"></asp:Label>
                            <input runat="server" class="form-control" type="date" id="dateR" max="2004-08-31"/>
                        </div>
                        <div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Valor de Recorrido:"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="Phone" ID="txtValor"></asp:TextBox>
                        </div>
                        <%--<div class="input-group">
                            <asp:Label runat="server" CssClass="form-control" Text="Mapa:"></asp:Label>
                            <div id="map_populate" style="width:100%; height:500px; border: 5px solid #5E5454;">  </div>
                            
                        </div>--%>
                    </fieldset>
                    <br />
                    <div class="row">
                        <asp:Button runat="server" ID="btnVolver" CssClass="form-control btn btn-danger" Text="Volver" OnClick="btnVolver_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
