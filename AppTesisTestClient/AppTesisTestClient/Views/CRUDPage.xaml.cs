
using AppTesisTestClient.Models;
using AppTesisTestClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace AppTesisTestClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRUDPage : ContentPage
    {
        Vehiculo vehiculo;
        Recorrido recorrido;
        MisUbicaciones misUbicaciones;
        bool isThereData;
        public CRUDPage()
        {
            InitializeComponent();
            txtSearch.SearchButtonPressed += BuscarUbicacionByText;
        }

        private async void GuradarLugar(object sender, EventArgs e)
        {
            if (txtDireccionUbi.Text != "" && txtLatUbi.Text != "" && txtLngUbi.Text != "")
            {
                if (Servicio.client.AgregarUbicaciones(Convert.ToDecimal(txtLatUbi.Text), Convert.ToDecimal(txtLngUbi.Text), Servicio.usuarioConectado.IdCliente, txtDireccionUbi.Text) == 0)
                {
                    await Device.InvokeOnMainThreadAsync(async () => {
                        await DisplayAlert("Info!", "Creación exitosa!", "ok");
                        await Navigation.PopAsync();
                    });

                }
                else
                {
                    await Device.InvokeOnMainThreadAsync(async () => {
                        await DisplayAlert("", "Error!", "ok");
                        await Navigation.PopAsync();
                    });
                }
            }
        }
        private void UbicacionPin(object sender, PinDragEventArgs e)
        {
            MostrarUbi(e.Pin.Position.Latitude, e.Pin.Position.Longitude, mapaUbi);
        }

        public async void MostrarUbi(double ltd, double lng,Xamarin.Forms.GoogleMaps. Map mapa)
        {
            Position p = new Position(ltd, lng);
            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(p, Distance.FromKilometers(0.5)));
            mapa.Pins.Clear();
            Pin pin = new Pin
            {
                Type = PinType.Place,
                Address = "Mi ubicacion",
                Label = "Direccion",
                Position = new Position(ltd, lng)
            };
            var direccion = Servicio.GetAddressByQuery(pin.Position);
            txtLatUbi.Text = ltd.ToString();
            txtLngUbi.Text = lng.ToString();
            txtDireccionUbi.Text = direccion;
            pin.IsDraggable = true;
            mapa.Pins.Add(pin);
        }
        private async void EliminarLugar(object sender, EventArgs e)
        {
            if (Servicio.client.EliminarUbicaciones(Servicio.usuarioConectado.IdCliente) == 0)
            {
                await Device.InvokeOnMainThreadAsync(async () => {
                    await DisplayAlert("Info!", "Eliminación exitosa!", "ok");
                    await Navigation.PopAsync();
                });

            }
            else
            {
                await Device.InvokeOnMainThreadAsync(async () => {
                    await DisplayAlert("", "Error!", "ok");
                });
            }
        }
        
        private async void BuscarUbicacionByText(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                List<string> similarPlaces = Servicio.client.GetPlacesForAddress(txtSearch.Text + "+Ecuador");

                lstVResultados.ItemsSource = similarPlaces;
                lstVResultados.IsVisible = true;
            }


        }
        
        
        public CRUDPage(Recorrido recorrido, bool data)
        {
            InitializeComponent();
            this.isThereData = data;
            this.Recorrido = recorrido;
            layoutRecorridos.IsVisible = true;
            mapaRecorridos.IsVisible = true;
            layoutUbicaciones.IsVisible = false;
            Llenar(Recorrido);
        }
        public CRUDPage(MisUbicaciones recorrido, bool data)
        {
            InitializeComponent();
            this.misUbicaciones = recorrido;
            this.isThereData = data;
            layoutRecorridos.IsVisible = false;
            layoutUbicaciones.IsVisible = true;
            txtLatUbi.IsEnabled = false;
            txtLngUbi.IsEnabled = false;
            txtDireccionUbi.IsEnabled= false;
            txtSearch.SearchButtonPressed += BuscarUbicacionByText;
            lstVResultados.ItemSelected += UbiSelected;
            btnAddLugar.Clicked += GuradarLugar;
            btnDeleteLugar.Clicked += EliminarLugar;
            mapaUbi.PinDragEnd += UbicacionPin;
            Llenar(recorrido);
        }

        private async void UbiSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var s = lstVResultados.SelectedItem.ToString();
            var p = Servicio.client.GetLatLngForAddress(txtSearch.Text + "+Ecuador");
            Ubicacion ubicacion = new Ubicacion();
            ubicacion.UbicacionV = new Location(Convert.ToDouble(p.FirstOrDefault().Split(":")[0], System.Globalization.CultureInfo.InvariantCulture), Convert.ToDouble(p.FirstOrDefault().Split(":")[1], System.Globalization.CultureInfo.InvariantCulture));

            MostrarUbi(ubicacion.UbicacionV.Latitude, ubicacion.UbicacionV.Longitude, mapaUbi);
            txtLatUbi.Text = ubicacion.UbicacionV.Latitude.ToString();
            txtLngUbi.Text = ubicacion.UbicacionV.Longitude.ToString();
            txtDireccionUbi.Text = s;
            lstVResultados.IsVisible = false;
        }

        

        

        private void Llenar(Recorrido recorrido)
        {
            if (IsThereData)
            {
                txtCliente.Text = recorrido.IdCliente.Nombre;
                txtConductor.Text = recorrido.IdConductor.Nombre;
                txtMoney.Text = recorrido.ValorRecorrido.ToString();
                txtOrigen.Text = recorrido.Origen;
                txtDestino.Text = recorrido.Destino;
                MostrarUbi((double)recorrido.LatitudOrigen, (double)recorrido.LongitudOrigen, (double)recorrido.LatitudDestino, (double)recorrido.LongitudDestino,mapaRecorridos);
                txtMoney.Text = recorrido.ValorRecorrido.ToString();
            }


        }

        private void MostrarUbi(double latitudOrigen, double longitudOrigen, double latitudDestino, double longitudDestino, Xamarin.Forms.GoogleMaps.Map mapa)
        {
            Position p1 = new Position(latitudOrigen, longitudOrigen);
            Position p2 = new Position(latitudDestino, longitudDestino);
            Position p = new Position((double)(latitudOrigen + latitudDestino) / 2, (double)( longitudOrigen+ longitudDestino ) / 2);
            Polyline polyline = new Polyline();
            polyline.StrokeColor = Color.ForestGreen;
            polyline.Positions.Add(p1); polyline.Positions.Add(p2);
            var distancia = Servicio.GetDistance((decimal)p1.Latitude, (decimal)p2.Latitude, (decimal)p1.Longitude, (decimal)p2.Longitude);
            mapa.MoveToRegion(MapSpan.FromPositions(polyline.Positions));
            mapa.Pins.Clear();
            Pin pin1 = new Pin
            {
                Type = PinType.Place,
                Address = recorrido.Origen,
                Label = "Direccion",
                Position = p1,
                Icon = BitmapDescriptorFactory.FromBundle("source.png")
            };
            Pin pin2 = new Pin
            {
                Type = PinType.Place,
                Address = recorrido.Destino,
                Label = "Direccion",
                Position = p2,
                Icon = BitmapDescriptorFactory.FromBundle("destination.png")
            };
            pin1.IsDraggable = false;
            pin2.IsDraggable = false;
            
            mapa.Polylines.Add(polyline);
            mapa.Pins.Add(pin1);
            mapa.Pins.Add(pin2);    
        }
        private async void Llenar(MisUbicaciones misUbicaciones)
        {
            if (isThereData)
            {
                MostrarUbi(Convert.ToDouble(misUbicaciones.Latitud), Convert.ToDouble(misUbicaciones.Longitud), mapaUbi);
                txtLatUbi.Text = misUbicaciones.Latitud.ToString();
                txtLngUbi.Text = misUbicaciones.Longitud.ToString();
                txtDireccionUbi.Text = misUbicaciones.Direccion;
                btnDeleteLugar.IsVisible = true;
                btnDeleteLugar.IsEnabled = true;
            }
            else
            {
                btnDeleteLugar.IsVisible = false;
                btnDeleteLugar.IsEnabled = false;
                Ubicacion ubicacion = new Ubicacion();
                await ubicacion.GetUbicacionGPS();
                MostrarUbi(-0.21270, - 78.49210, mapaUbi);
            }

        }


        public Vehiculo Vehiculo { get => vehiculo; set => vehiculo = value; }
        public Recorrido Recorrido { get => recorrido; set => recorrido = value; }
        public MisUbicaciones MisUbicaciones { get => misUbicaciones; set => misUbicaciones = value; }
        public bool IsThereData { get => isThereData; set => isThereData = value; }
    }
}