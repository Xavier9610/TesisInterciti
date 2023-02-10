using AppTesisTestConductor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTesisTestConductor.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.GoogleMaps;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace AppTesisTestConductor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRUDPage : ContentPage
    {
        Vehiculo vehiculo;
        Recorrido recorrido;
        MisUbicaciones misUbicaciones;
        bool isThereData;
        private MediaFile _file;
        public CRUDPage()
        {
            InitializeComponent();
            txtSearch.SearchButtonPressed += BuscarUbicacionByText;
            btnAddVehiculo.Clicked += GuardarVehiculo;
            btnDeleteVehiculo.Clicked += EliminarVehiculo;
            btnSelectVehiculo.Clicked += SeleccionarVehiculo;
        }
        private async void GuradarLugar(object sender, EventArgs e)
        {
            if (txtDireccionUbi.Text != "" && txtLatUbi.Text != "" && txtLngUbi.Text != "" )
            {
                if (Servicio.client.AgregarUbicaciones(Convert.ToDecimal(txtLatUbi.Text),Convert.ToDecimal(txtLngUbi.Text),Servicio.usuarioConectado.IdConductor,txtDireccionUbi.Text) == 0)
                {
                    await Device.InvokeOnMainThreadAsync(async () => {
                        await DisplayAlert("Info!", "Creación exitosa!", "ok");
                    });
                }
                else
                {
                    await Device.InvokeOnMainThreadAsync(async () => {
                        await DisplayAlert("", "Error!", "ok");
                    });
                }
            }
        }

        private async void EliminarLugar(object sender, EventArgs e)
        {
            if (Servicio.client.AgregarUbicaciones(Convert.ToDecimal(txtLatUbi.Text), Convert.ToDecimal(txtLngUbi.Text), Servicio.usuarioConectado.IdConductor, txtDireccionUbi.Text) == 0)
            {
                await Device.InvokeOnMainThreadAsync(async () => {
                    await DisplayAlert("Info!", "Eliminación exitosa!", "ok");
                });
            }
            else
            {
                await Device.InvokeOnMainThreadAsync(async () => {
                    await DisplayAlert("", "Error!", "ok");
                });
            }
        }

        private async void SeleccionarVehiculo(object sender, EventArgs e)
        {
           
            Servicio.usuarioConectado.Vehiculo = (vehiculo);
            ServiceReferenceInterciti.Conductor c = Servicio.client.FindConductorByID(Servicio.usuarioConectado.IdConductor);
            c.Vehiculo = Servicio.client.FindVehiculoByID(vehiculo.IdVehiculo);
            
                if (Servicio.client.ActualizarConductor(c) ==0)
                {
                    await Device.InvokeOnMainThreadAsync(async () => {
                        await DisplayAlert("Info!", "Selección exitosa!", "ok");
                    });

                }
                else
                {
                    await Device.InvokeOnMainThreadAsync(async () => {
                        await DisplayAlert("","Error!","ok");
                    });
                }
            
        }

        private async void EliminarVehiculo(object sender, EventArgs e)
        {
            if (Servicio.client.EliminarConductor(Servicio.usuarioConectado.IdConductor) == 0)
            {
                await Device.InvokeOnMainThreadAsync(async () => {
                    await DisplayAlert("Info!", "Selección exitosa!", "ok");
                });
            }
            else
            {
                await Device.InvokeOnMainThreadAsync(async () => {
                    await DisplayAlert("", "Error!", "ok");
                });
            }
        }

        private async void GuardarVehiculo(object sender, EventArgs e)
        {
            try
            {
                if (txtAño.SelectedItem.ToString() != "" && txtTipo.SelectedItem.ToString() != "" && txtMarca.SelectedItem.ToString() != "" && txtModelo.SelectedItem.ToString() != "" && txtPlaca.Text != "" && _file.GetStream() !=null)
                {
                    if (IsThereData)
                    {
                        /*var aux = Servicio.client.FindVehiculoByID(vehiculo.IdVehiculo);

                        if (Servicio.client.ActualizarVehiculo() == 0)
                        {
                            await Device.InvokeOnMainThreadAsync(async () => {
                                await DisplayAlert("Info!", "Creación exitosa!", "ok");
                            });
                        }
                        else
                        {
                            await Device.InvokeOnMainThreadAsync(async () => {
                                await DisplayAlert("Info!", "Creación erronea! \nIntente mas tarde", "ok");
                            });
                        }*/
                    }
                    else
                    {
                        if (Servicio.client.AgregarVehiculo(txtPlaca.Text, Servicio.client.FindTipoVehiculoByTipo(txtTipo.SelectedItem.ToString()), Servicio.client.FindModeloVehiculoByModelo(txtModelo.SelectedItem.ToString()).IdModelo, Servicio.client.FindAñoVehiculoByIdAño(txtAño.SelectedItem.ToString()).IdAño, Servicio.client.FindMarcaVehiculoByMarca(txtMarca.SelectedItem.ToString()), Servicio.ResizeImage(Servicio.ImageSourceToBytes(fotoV.Source))) == 0)
                        {
                            await Device.InvokeOnMainThreadAsync(async () => {
                                await DisplayAlert("Info!", "Creación exitosa!", "ok");
                            });
                        }
                        else
                        {
                            await Device.InvokeOnMainThreadAsync(async () => {
                                await DisplayAlert("Info!", "Creación erronea! \nIntente mas tarde", "ok");
                            });
                        }
                    }
                    
                    
                }
            }
            catch
            {
                await Device.InvokeOnMainThreadAsync(async () => {
                    await DisplayAlert("Info!", "Creación erronea! \nExisten datos erroneos", "ok");
                });
            }
            
        }

        private async void BuscarUbicacionByText(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                var p = Servicio.client.GetLatLngForAddress(txtSearch.Text + "+Ecuador");
                MostrarResultados(p);
            }
        }
        private async void MostrarResultados(IEnumerable<string> p)
        {
            List<string> vs = new List<string>();
            vs.Clear();
            foreach (var iter in p.ToList())
            {
                var aux = Servicio.client.GetAddress(Convert.ToDouble(iter.Split(":")[0]), Convert.ToDouble(iter.Split(":")[1]));
                vs.Add(aux);
            }
            lstVResultados.ItemsSource = vs;
            lstVResultados.IsVisible = true;
        }
        private async void CambiarFoto(object sender, EventArgs e)
        {
            await Plugin.Media.CrossMedia.Current.Initialize();
            var source = await Application.Current.MainPage.DisplayActionSheet("Selecciona una imagen", "Cancelar", null,
                "Galeria", "Camara");
            if (source == "Cancelar")
            {
                this._file = null;
                return;
            }
            else if (source == "Galeria")
            {
                this._file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    CompressionQuality = 40,
                    CustomPhotoSize = 35,
                    PhotoSize = PhotoSize.MaxWidthHeight,
                    MaxWidthHeight = 2000
                }).ConfigureAwait(true);
            }
            else if (source == "Camara")
            {
                this._file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Photographs",
                    SaveToAlbum = true,
                    CompressionQuality = 40,
                    CustomPhotoSize = 35,
                    PhotoSize = PhotoSize.MaxWidthHeight,
                    MaxWidthHeight = 2000,
                    DefaultCamera = CameraDevice.Rear
                }).ConfigureAwait(true);
            }
            if (this._file != null)
            {
                fotoV.Source = ImageSource.FromStream(() =>
                {

                    var stream = _file.GetStream();
                    return stream;
                });
            }
        }
        public CRUDPage(Vehiculo vehiculo,bool data)
        {
            InitializeComponent();

            btnCambiarFoto.Clicked += CambiarFoto;
            this.isThereData = data;
            this.Vehiculo = vehiculo;
            layoutRecorridos.IsVisible = false;
            layoutVehiculo.IsVisible = true;
            layoutUbicaciones.IsVisible = false;
            txtSearch.SearchButtonPressed += BuscarUbicacionByText;
            Llenar(Vehiculo);
            btnAddVehiculo.Clicked += GuardarVehiculo;
            btnDeleteVehiculo.Clicked += EliminarVehiculo;
            btnSelectVehiculo.Clicked += SeleccionarVehiculo;
        }
        public CRUDPage(Recorrido recorrido, bool data)
        {
            InitializeComponent();
            this.isThereData = data;
            this.Recorrido = recorrido;
            layoutRecorridos.IsVisible = true;
            layoutVehiculo.IsVisible = false;
            layoutUbicaciones.IsVisible = false;
            txtSearch.SearchButtonPressed += BuscarUbicacionByText;
            Llenar(Recorrido);
        }
        public CRUDPage(MisUbicaciones recorrido, bool data)
        {
            InitializeComponent();
            this.misUbicaciones = recorrido;
            this.isThereData = data;
            layoutRecorridos.IsVisible = false;
            layoutVehiculo.IsVisible = false;
            layoutUbicaciones.IsVisible = true;
            txtSearch.SearchButtonPressed += BuscarUbicacionByText;
            btnAddLugar.Clicked += GuradarLugar;
            btnDeleteLugar.Clicked += EliminarLugar;
            mapaUbi.PinDragEnd += UbicacionPin;
            Llenar(recorrido);
        }

        private void UbicacionPin(object sender, PinDragEventArgs e)
        {
            MostrarUbi(e.Pin.Position.Latitude,e.Pin.Position.Longitude,mapaUbi);
        }

        public async void MostrarUbi(double ltd,double lng,Map mapa)
        {
            Position p = new Position(ltd, lng);
            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(p, Distance.FromKilometers(0.5))
                            );
            mapa.Pins.Clear();

            Pin pin = new Pin
            {
                Type = PinType.Place,
                Address = "Mi ubicacion",
                Label = "Direccion",
                Position = new Position(ltd,lng)
            };
            var direccion = Servicio.GetAddressByQuery(pin.Position);
            txtLatUbi.Text = ltd.ToString();
            txtLngUbi.Text = lng.ToString();
            txtDireccionUbi.Text = direccion;
            pin.IsDraggable = true;
            mapa.Pins.Add(pin);
        }
        

        private void Llenar(Vehiculo vehiculo)
        {
            
            txtMarca.ItemsSource = Servicio.WCFToAppList(Servicio.client.ListarMarcaVehiculo());
            txtModelo.ItemsSource = Servicio.WCFToAppList(Servicio.client.ListarModeloVehiculo());
            txtTipo.ItemsSource = Servicio.WCFToAppList(Servicio.client.ListarTipoVehiculo());
            txtAño.ItemsSource = Servicio.WCFToAppList(Servicio.client.ListarAnioVehiculo());
            if (isThereData)
            {
                txtPlaca.Text = Servicio.client.FindVehiculoByID(vehiculo.IdVehiculo).Placa;
                txtAño.SelectedItem = vehiculo.Año;
                txtMarca.SelectedItem = vehiculo.Marca;
                txtModelo.SelectedItem = vehiculo.Modelo;
                txtTipo.SelectedItem = vehiculo.Tipo;
                fotoV.Source = vehiculo.Picture.Source;
                btnAddVehiculo.IsEnabled = false;
                btnAddVehiculo.IsVisible = false;
                lblGuardar.IsVisible = false;
                btnCambiarFoto.IsVisible = false;
                btnCambiarFoto.IsEnabled= false;
                lblCambiarFoto.IsVisible = false;
            }
            else
            {
                btnAddVehiculo.IsEnabled = true;
                btnAddVehiculo.IsVisible = true;
                lblGuardar.IsVisible = true;
                btnDeleteLugar.IsEnabled = false;
                 btnDeleteVehiculo.IsVisible = false;
                lblEliminar.IsVisible = false;
                btnSelectVehiculo.IsEnabled = false;
                btnSelectVehiculo.IsVisible = false;
                lblSeleccionar.IsVisible = false;
                btnCambiarFoto.IsVisible = true;
                btnCambiarFoto.IsEnabled = true;
                lblCambiarFoto.IsVisible = true;



            }


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
                MostrarUbi((double)recorrido.LatitudOrigen, (double)recorrido.LongitudOrigen, (double)recorrido.LatitudDestino, (double)recorrido.LongitudDestino, mapaRecorridos);
                txtMoney.Text = recorrido.ValorRecorrido.ToString();
            }


        }

        

        private async void Llenar(MisUbicaciones misUbicaciones)
        {
            if (isThereData)
            {
                MostrarUbi(Convert.ToDouble(misUbicaciones.Latitud), Convert.ToDouble(misUbicaciones.Longitud), mapaUbi);
                txtLatUbi.Text = misUbicaciones.Latitud.ToString();
                txtLngUbi.Text = misUbicaciones.Longitud.ToString();
                txtDireccionUbi.Text = misUbicaciones.Direccion;
            }
            else
            {
                Ubicacion ubicacion = new Ubicacion();
              //  await ubicacion.GetUbicacionGPS();
              //  MostrarUbi(ubicacion.UbicacionV.Latitude, ubicacion.UbicacionV.Longitude, mapaUbi); 
            }
            
        }
        private void MostrarUbi(double latitudOrigen, double longitudOrigen, double latitudDestino, double longitudDestino, Xamarin.Forms.GoogleMaps.Map mapa)
        {
            Position p1 = new Position(latitudOrigen, longitudOrigen);
            Position p2 = new Position(latitudDestino, longitudDestino);
            Position p = new Position((double)(latitudOrigen + latitudDestino) / 2, (double)(longitudOrigen + longitudDestino) / 2);
            var distancia = Servicio.GetDistance((decimal)p1.Latitude, (decimal)p2.Latitude, (decimal)p1.Longitude, (decimal)p2.Longitude);
            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(p, Distance.FromKilometers(distancia / 2)));
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
            Polyline polyline = new Polyline();
            polyline.StrokeColor = Color.ForestGreen;
            polyline.Positions.Add(p1); polyline.Positions.Add(p2);
            mapa.Polylines.Add(polyline);
            mapa.Pins.Add(pin1);
            mapa.Pins.Add(pin2);
        }

        public Vehiculo Vehiculo { get => vehiculo; set => vehiculo = value; }
        public Recorrido Recorrido { get => recorrido; set => recorrido = value; }
        public MisUbicaciones MisUbicaciones { get => misUbicaciones; set => misUbicaciones = value; }
        public bool IsThereData { get => isThereData; set => isThereData = value; }
    }
}