using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using AppTesisTestClient.Services;
using AppTesisTestClient.Models;
using Plugin.LocalNotification;
using Plugin.LocalNotification.EventArgs;
using System.Threading;
using System.Timers;
using NPOI.SS.Formula.Functions;

namespace AppTesisTestClient.Views
{
    public partial class AboutPage : ContentPage
    {
        Location ubicacionInicial = new Location();
        Location ubicacionFinal = new Location();
        Ubicacion ubicacion = new Ubicacion();
        bool sourceSelected;
        static bool inicio;
        Recorrido recorrido;
        int calificiacion;
        System.Timers.Timer timer;
        BackgroundWorker thread = new BackgroundWorker();
        BackgroundWorker threadTracking = new BackgroundWorker();
        int seg = 60, min = 4;

        public AboutPage()
        {
            InitializeComponent();
           LlenarTipoVehiculo();
            IniciarControles();
        }

        private void LlenarTipoVehiculo()
        {
            btnTipoVehiculo.Items.Clear();
            if (Servicio.client.ListarTipoVehiculo()!=null)
            {
                foreach (var iter in Servicio.client.ListarTipoVehiculo())
                {
                    btnTipoVehiculo.Items.Add(iter.Tipo);
                }
            }
        }

        private void IniciarControles()
        {
            inicio = true;
            rBtnInicio.BorderColor = Color.Green;
            rBtnInicio.TextColor = Color.Green;
            sourceSelected = false;
            dateRecorrido.Date = DateTime.Now.Date;
            rBtnReserva.IsChecked = true;
            mapaAppCliente.MyLocationButtonClicked += MiUbicacion;
            mapaAppCliente.PinDragEnd += UbicacionPin;
            txtOferta.TextChanged += LlenarRBoton;
            btnSolicitar.Clicked += SolicitarRecorrido;
            btnSolicitar.IsEnabled = false;
            btnSolicitar.BackgroundColor = Color.Black;
            btnUbicacionFin.Clicked += SeleccionarFin;
            btnUbicacionInicio.Clicked += SeleccionarInicio;
            dateRecorrido.DateSelected += FechaSeleccionada;
            btnDateRecorrido.Clicked += SeleccionarDate;
            lstVResultados.ItemSelected += UbicacionSeleccionada;
            lstListaRecorrido.ItemSelected += ConductorSeleccionado;
            btnTipoVehiculo.SelectedIndexChanged += CambiaTipoVehiculo;
            btnCancelarCalif.Clicked +=  CancelarCalificacion;
            btnEnviar.Clicked += EnviarCalificacion;
            btnEnviar.IsEnabled = false;
            btnEmo1.Clicked += BtnEmo1_Clicked;
            btnEmo2.Clicked += BtnEmo2_Clicked;
            btnEmo3.Clicked += BtnEmo3_Clicked;
            btnEmo4.Clicked += BtnEmo4_Clicked;
            btnEmo5.Clicked += BtnEmo5_Clicked;
            btnCancelAll.Clicked += CancelarRecorrido;
            rBtnInicio.CheckedChanged += ControlRbtn;
            rBtnFin.CheckedChanged += ControlRbtn;
            rBtnOferta.CheckedChanged += ControlRbtn;
            rBtnReserva.CheckedChanged += ControlRbtn;
            rBtnTipoVehiculo.CheckedChanged += ControlRbtn;
            txtOferta.TextChanged += OfertaSet;
            btnMiUbi.Clicked += MiUbicacionByButtom;
            btnMiAceptarUbicacion.Clicked += UbicacionAceptada;
            btnMiCancelarUbicacion.Clicked += UbicacionCancelada;
            txtSearch.SearchButtonPressed += BuscarUbicacionByText;
            txtSearch.IsEnabled = false;

            mapaAppCliente.IsTrafficEnabled = true;
            mapaAppCliente.UiSettings.CompassEnabled = true;
         
            layoutCalificarRecorrido.IsVisible = false;
            layoutDirecciones.IsVisible = true;//inicia el realizar la reserva
            layoutSeleccionDirecciones.IsVisible = false;
            layoutSolicitar.IsVisible = false;
            layoutBarraBu.IsVisible = true;
            layoutBusquedaResult.IsVisible = false;
            NotificationCenter.Current.NotificationReceived +=MostrarNotificaciones;
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += ConteoEnCero;
            thread.DoWork += Escuchar;
            threadTracking.DoWork += Tracking;
            dateRecorrido.MinimumDate = DateTime.Now;
            MoveToActualUbicacion();
        }

        private async void CancelarRecorrido(object sender, EventArgs e)
        {

            if (threadTracking.IsBusy)
            {
                threadTracking.WorkerSupportsCancellation = true;
                threadTracking.CancelAsync();
            }
            if (thread.IsBusy)
            {
                threadTracking.WorkerSupportsCancellation = true;
                threadTracking.CancelAsync();
            }
            ServiceReferenceInterciti.Recorrido recorridoAux = Servicio.client.FindRecorridoById(recorrido.IdRecorrido);
            recorridoAux.EstadoRecorrido = -1;
            if (Servicio.client.ActualizarRecorrido((recorridoAux)) != 0)
            {
              await DisplayAlert("Error", "No se ha logrado contactar a este usuario", "OK");
            }
            else
            {
                await DisplayAlert("Finalizado!", "El viaje fue cancelado!", "OK");
                layoutDirecciones.IsVisible = true;
                rBtnFin.IsChecked = false;
                rBtnInicio.IsChecked = false;
                rBtnOferta.IsChecked = false;
                rBtnTipoVehiculo.IsChecked = false;
                layoutCalificarRecorrido.IsVisible = false;
                timer.Stop();
                min = 4;
                seg = 60;

            }
        }

        private void BtnEmo5_Clicked(object sender, EventArgs e)
        {
            calificiacion = 5;
            btnEnviar.IsEnabled = true;
            
        }

        private void BtnEmo4_Clicked(object sender, EventArgs e)
        {
            calificiacion = 4;
            btnEnviar.IsEnabled = true;
        }

        private void BtnEmo3_Clicked(object sender, EventArgs e)
        {
            calificiacion = 3;
            btnEnviar.IsEnabled = true;
        }

        private void BtnEmo2_Clicked(object sender, EventArgs e)
        {
            calificiacion = 2;
            btnEnviar.IsEnabled = true;
        }

        private void BtnEmo1_Clicked(object sender, EventArgs e)
        {
            calificiacion = 1;
            btnEnviar.IsEnabled = true;
        }

        private async void EnviarCalificacion(object sender, EventArgs e)
        {
            ServiceReferenceInterciti.Recorrido recorrido = Servicio.client.FindRecorridoById(this.recorrido.IdRecorrido);
            if (txtComentario != null)
            {
                recorrido.Comentario = txtComentario.Text;
            }
            else
            {
                recorrido.Comentario = "";
            }
            recorrido.Calificacion = calificiacion;
            recorrido.EstadoRecorrido = 8;
            if (Servicio.client.ActualizarRecorrido(recorrido) == 0)
            {
                await Device.InvokeOnMainThreadAsync(async () => {
                    await DisplayAlert("Gracias", "Gracias por usar este servicio!", "Aceptar");
                    layoutDirecciones.IsVisible = true;
                    rBtnFin.IsChecked = false;
                    rBtnInicio.IsChecked = false;
                    rBtnOferta.IsChecked = false;
                    rBtnTipoVehiculo.IsChecked = false;
                    layoutCalificarRecorrido.IsVisible = false;
                    mapaAppCliente.Pins.Clear();
                    mapaAppCliente.Polylines.Clear();
                });

            }
            else
            {
                await Device.InvokeOnMainThreadAsync(async () => {
                    await DisplayAlert("mal", "mal", "Aceptar");
                });
            }

        }

        private void CancelarCalificacion(object sender, EventArgs e)
        {
               
            ServiceReferenceInterciti.Recorrido recorrido = Servicio.client.FindRecorridoById(this.recorrido.IdRecorrido);
            recorrido.EstadoRecorrido = 0;
            if (Servicio.client.ActualizarRecorrido(recorrido) == 0)
            {
                layoutDirecciones.IsVisible = true;
                rBtnFin.IsChecked = false;
                rBtnInicio.IsChecked = false;
                rBtnOferta.IsChecked = false;
                rBtnTipoVehiculo.IsChecked = false;
                layoutCalificarRecorrido.IsVisible = false;
                mapaAppCliente.Pins.Clear();
                mapaAppCliente.Polylines.Clear();
            }

            }

        private async void Tracking(object sender, DoWorkEventArgs e)
        {
            try
            {
                thread.WorkerSupportsCancellation = true;
                thread.CancelAsync();
                double distancia = 1000;
                while (distancia >= 0.05)
                {
                    var miUbicacion = Servicio.client.FindUbicacionByNombre("TepmX", Servicio.usuarioConectado.IdCliente);
                    if (miUbicacion != null)
                    {
                        if (inicio)
                        {
                            Thread.Sleep(6000);
                            distancia = Servicio.GetDistance((decimal)miUbicacion.Latitud, recorrido.LatitudOrigen, (decimal)miUbicacion.Longitud, recorrido.LongitudOrigen);
                            await Device.InvokeOnMainThreadAsync(() => {
                                mapaAppCliente.Polylines.Clear();
                                mapaAppCliente.Pins.Clear();
                                mapaAppCliente.MoveToRegion(MapSpan.FromCenterAndRadius(
                                                new Position(((double)miUbicacion.Latitud + (double)recorrido.LatitudOrigen) / 2, ((double)miUbicacion.Longitud + (double)recorrido.LongitudOrigen) / 2), Distance.FromKilometers(distancia / 2))
                            );
                            });
                            Pin pin = new Pin { Position = new Position((double)miUbicacion.Latitud, (double)miUbicacion.Longitud), Label = "Mi ubicacion", Type = PinType.Place, Icon = BitmapDescriptorFactory.FromBundle("car.png") };
                            Pin pin1 = new Pin { Position = new Position((double)recorrido.LatitudOrigen, (double)recorrido.LongitudOrigen), Label = recorrido.Origen, Type = PinType.Place, Icon = BitmapDescriptorFactory.FromBundle("source.png") };
                            Polyline p = new Polyline();
                            p.StrokeColor = Color.ForestGreen;
                            p.Positions.Add(pin.Position); p.Positions.Add(pin1.Position);

                            await Device.InvokeOnMainThreadAsync(() => {
                                lblDistancia.Text = distancia.ToString() + "Km";
                                mapaAppCliente.Polylines.Add(p);
                                mapaAppCliente.Pins.Add(pin);
                                mapaAppCliente.Pins.Add(pin1);
                            });
                            Servicio.client.ActualizarUbicaciones(miUbicacion);
                        }
                        else
                        {
                            Thread.Sleep(6000);
                            await ubicacion.GetUbicacionGPS();
                            distancia = Servicio.GetDistance((decimal)miUbicacion.Latitud, recorrido.LatitudOrigen, (decimal)miUbicacion.Longitud, recorrido.LongitudDestino);
                            await Device.InvokeOnMainThreadAsync(() => {
                                mapaAppCliente.Polylines.Clear();
                                mapaAppCliente.Pins.Clear();
                                mapaAppCliente.MoveToRegion(MapSpan.FromCenterAndRadius(
                                                new Position(((double)miUbicacion.Latitud + (double)recorrido.LatitudDestino) / 2, ((double)miUbicacion.Longitud + (double)recorrido.LongitudDestino) / 2), Distance.FromKilometers(distancia / 2))
                            );
                            });
                            Pin pin = new Pin { Position = new Position((double)miUbicacion.Latitud, (double)miUbicacion.Longitud), Label = "Mi ubicacion", Type = PinType.Place, Icon = BitmapDescriptorFactory.FromBundle("car.png") };

                            Pin pin1 = new Pin { Position = new Position((double)recorrido.LatitudDestino, (double)recorrido.LongitudDestino), Label = recorrido.Destino, Type = PinType.Place, Icon = BitmapDescriptorFactory.FromBundle("destination.png") };
                            Polyline p = new Polyline();
                            p.StrokeColor = Color.ForestGreen;
                            p.Positions.Add(pin.Position); p.Positions.Add(pin1.Position);

                            await Device.InvokeOnMainThreadAsync(() => {
                                lblDistancia.Text = distancia.ToString() + "Km";
                                mapaAppCliente.Polylines.Add(p);
                                mapaAppCliente.Pins.Add(pin);
                                mapaAppCliente.Pins.Add(pin1);

                            });

                        }
                    }

                }
                inicio = false;
            }
            catch (Exception a)
            {
                await DisplayAlert("Error", a.Message, "OK");
                var recorrido = Servicio.client.FindRecorridoById(this.recorrido.IdRecorrido);
                recorrido.EstadoRecorrido = -1;
                if (Servicio.client.ActualizarRecorrido((recorrido)) != 0)
                {
                    await DisplayAlert("Error", "No se ha logrado contactar a este usuario", "OK");
                }
                else
                {
                    await DisplayAlert("Finalizado!", "El viaje a finalizado!", "OK");
                }
            }
            
        }

        private void OfertaSet(object sender, TextChangedEventArgs e)
        {
            if (txtOferta.Text == "" || txtOferta.Text == null)
            {
                rBtnOferta.IsChecked = false;

            }
        }

        private async void Escuchar(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                var a = await EscucharSolicitudes();
                Thread.Sleep(3000);
                await Device.InvokeOnMainThreadAsync(() => {
                    if (a!=null)
                    {
                        lstListaRecorrido.ItemsSource = a;
                    }
                });
                Thread.Sleep(6000);
            }
            
        }
        private async Task<List<Models.Recorrido>> EscucharSolicitudes()
        {
            try
            {
                List<Models.Recorrido> recorridosAux = new List<Models.Recorrido>();
                var recorridos = Servicio.WCFToAppList(Servicio.client.FindRecorridosByCliente(Servicio.usuarioConectado.IdCliente));
                if (recorridos != null)
                {
                    foreach (var iter in recorridos)
                    {
                        NotificationRequest notificacion = new NotificationRequest();
                        notificacion.ReturningData = "Dummy Data";
                        switch (iter.IdEstadoRecorrido)
                        {
                            case 2:
                                notificacion.Title = "Respuestas!";
                                notificacion.Description = $"{iter.IdConductor.Nombre}. Quiere ser tu conductor.";
                                notificacion.NotificationId = iter.IdConductor.IdConductor;
                                notificacion.BadgeNumber = iter.IdConductor.IdConductor;
                                await NotificationCenter.Current.Show(notificacion);
                                recorridosAux.Add(iter);
                                break;
                            case 4:
                                recorrido = iter;
                                notificacion.Title = "Llego el conductor!";
                                notificacion.Description = $"{iter.IdConductor.Nombre}. Te esta esperando!";
                                notificacion.NotificationId = iter.IdConductor.IdConductor;
                                notificacion.BadgeNumber = iter.IdConductor.IdConductor;
                                await NotificationCenter.Current.Show(notificacion);
                                //  recorridosAux.Add(iter);
                                ServiceReferenceInterciti.Recorrido recorridoAux = Servicio.client.FindRecorridoById(recorrido.IdRecorrido);
                                recorridoAux.EstadoRecorrido = 5;
                                inicio = false;
                                if (!threadTracking.IsBusy)
                                {
                                    Servicio.client.ActualizarRecorrido(recorridoAux);
                                    threadTracking.RunWorkerAsync();
                                }
                                break;
                            case 6:
                                recorrido = iter;
                                recorridoAux = Servicio.client.FindRecorridoById(iter.IdRecorrido);
                                recorridoAux.EstadoRecorrido = 7;
                                if (Servicio.client.ActualizarRecorrido((recorridoAux)) != 0)
                                {
                                    await DisplayAlert("Error", "No se ha logrado contactar a este usuario", "OK");
                                }
                                notificacion.Title = "Recorrido Finalizado!";
                                notificacion.Description = $"{iter.IdCliente.Nombre} ya llegaste a tu destino!";
                                notificacion.NotificationId = iter.IdConductor.IdConductor;
                                notificacion.BadgeNumber = iter.IdConductor.IdConductor;
                                await NotificationCenter.Current.Show(notificacion);
                                thread.WorkerSupportsCancellation = true;
                                threadTracking.WorkerSupportsCancellation = true;
                                thread.CancelAsync();
                                threadTracking.CancelAsync();
                                thread.Dispose();
                                threadTracking.Dispose();
                                await Device.InvokeOnMainThreadAsync(() => {
                                    layoutRecorrido.IsVisible = false;
                                    layoutCalificarRecorrido.IsVisible = true;
                                    mapaAppCliente.Pins.Clear();
                                    mapaAppCliente.Polylines.Clear();
                                });
                                break;
                            case -1:
                                notificacion.Title = "Recorrido Cancelado!";
                                notificacion.Description = $"El recorrido fue cancelado!";
                                notificacion.NotificationId = iter.IdConductor.IdConductor;
                                notificacion.BadgeNumber = iter.IdConductor.IdConductor;
                                await NotificationCenter.Current.Show(notificacion);
                                await Device.InvokeOnMainThreadAsync(async () => {
                                    await DisplayAlert("Gracias", "Gracias por usar este servicio!", "Aceptar");
                                    layoutDirecciones.IsVisible = true;
                                    rBtnFin.IsChecked = false;
                                    rBtnInicio.IsChecked = false;
                                    rBtnOferta.IsChecked = false;
                                    rBtnTipoVehiculo.IsChecked = false;
                                    layoutCalificarRecorrido.IsVisible = false;
                                    mapaAppCliente.Pins.Clear();
                                    mapaAppCliente.Polylines.Clear();
                                });
                                break;
                            default:
                                break;
                        }
                    }
                    return recorridosAux;
                }
            }
            catch (Exception e)
            {
              //  await DisplayAlert("Error", e.Message, "OK");
                var recorrido = Servicio.client.FindRecorridoById(this.recorrido.IdRecorrido);
                recorrido.EstadoRecorrido = -1;
                if (Servicio.client.ActualizarRecorrido((recorrido)) != 0)
                {
              //      await DisplayAlert("Error", "No se ha logrado contactar a este usuario", "OK");
                }
                else
                {
               //     await DisplayAlert("Finalizado!", "El viaje a finalizado con exito", "OK");
                }
            }
            return null;
        }

        

        private async void ConteoEnCero(object sender, ElapsedEventArgs e)
        {
            seg--;
            if (seg == 0)
            {
                min--;
                seg = 60;
            }
            await Device.InvokeOnMainThreadAsync(() => {
                lblTiempo.Text = String.Format(" {0}:{1:00}", min, seg);
            });
            if (min < 0)
            {
                min = 4;
                seg = 60;
                await Device.InvokeOnMainThreadAsync(async() => {
                    await DisplayAlert("Time out", "No se ha aceptado solicitudes", "Aceptar");
                });
                
            }
        }

        private void MostrarNotificaciones(NotificationEventArgs e)
        {
        }

        private async void ConductorSeleccionado(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem !=null)
            {
                string a = "";
                recorrido = (Recorrido)lstListaRecorrido.SelectedItem;
                ServiceReferenceInterciti.Recorrido recorridoAux = Servicio.client.FindRecorridoById(recorrido.IdRecorrido);
                await Device.InvokeOnMainThreadAsync(async () => {
                    a = await DisplayActionSheet($"Desea aceptar el viaje con el\n conductor {recorrido.IdConductor.Nombre}? ", "Aceptar", "Cancelar");
                });
                if (a == "Aceptar")
                {
                    await Device.InvokeOnMainThreadAsync( () => {
                        layoutRespuestas.IsVisible = false;
                        lblTiempo.Text = "Distancia: ";
                        lblRecorrido.Text = "";
                    });
                    timer.Stop();
                }
                lstListaRecorrido.SelectedItem = null;
                Iniciar(recorridoAux);
            }
            
            

        }

        private async void Iniciar(ServiceReferenceInterciti.Recorrido recorridoAux)
        {
            recorridoAux.EstadoRecorrido = 3;
            if (Servicio.client.ActualizarRecorrido(recorridoAux) == 0)
            {
                if (!threadTracking.IsBusy)
                {
                    inicio = true;
                    threadTracking.RunWorkerAsync();
                }

            }
            else
            {
                await Device.InvokeOnMainThreadAsync(async () => {
                    await DisplayAlert("mal", "mal", "Aceptar");
                });
            }
        }

        private void CambiaTipoVehiculo(object sender, EventArgs e)
        {
            rBtnTipoVehiculo.IsChecked = true;
        }

        private void LlenarRBoton(object sender, TextChangedEventArgs e)
        {
            rBtnOferta.IsChecked = true;
        }

        private void ControlRbtn(object sender, CheckedChangedEventArgs e)
        {
            if (rBtnInicio.IsChecked && rBtnFin.IsChecked && rBtnOferta.IsChecked && rBtnReserva.IsChecked && rBtnTipoVehiculo.IsChecked)
            {
                btnSolicitar.BackgroundColor = Color.GreenYellow;
                btnSolicitar.IsEnabled = true;
            }
            else {
                btnSolicitar.BackgroundColor = Color.Black;
                btnSolicitar.IsEnabled = false;
            }
            
        }

        private void SeleccionarDate(object sender, EventArgs e)
        {
            dateRecorrido.Focus();
        }



        private async void UbicacionSeleccionada(object sender, SelectedItemChangedEventArgs e)
        {
            var p =  Servicio.client.GetLatLngForAddress(lstVResultados.SelectedItem.ToString());
            ubicacion.UbicacionV = new Location(Convert.ToDouble(p.First().Split(":")[0]), Convert.ToDouble(p.First().Split(":")[1]));
            MoveToActualUbicacion(ubicacion);
            layoutBusquedaResult.IsVisible = false;
        }

        private void BuscarUbicacionByText(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                var p = Servicio.client.GetLatLngForAddress(txtSearch.Text + "+Ecuador");
                MostrarResultados(p);
            }
            

        }

        private async void MostrarResultados(IEnumerable<string> p)
        {
            layoutBusquedaResult.IsVisible = true;
            List<string> vs = new List<string>();
            vs.Clear();
            foreach (var iter in p.ToList())
            {
                var aux = Servicio.client.GetAddress(Convert.ToDouble(iter.Split(":")[0]) , Convert.ToDouble(iter.Split(":")[1]));
                vs.Add(aux);
            }
            lstVResultados.ItemsSource = vs;
        }
        
        private async void SolicitarRecorrido(object sender, EventArgs e)
        {
            layoutDirecciones.IsVisible = false;
            layoutBarraBu.IsVisible = false;
            layoutRecorrido.IsVisible = true;
            if (Servicio.client.AgregarRecorrido((decimal)ubicacionInicial.Latitude, (decimal)ubicacionInicial.Longitude, (decimal)ubicacionFinal.Longitude, (decimal)ubicacionFinal.Latitude, dateRecorrido.Date, Convert.ToDecimal(txtOferta.Text), null, Servicio.usuarioConectado.IdCliente,1, 0,"") != 0) {
                await DisplayAlert("Error!", "No se logro crear la solicitud. Intente nuevamente", "OK");
                return;
            }
            thread.RunWorkerAsync();
            timer.Start();
        }

     
        private void UbicacionCancelada(object sender, EventArgs e)
        {
            sourceSelected = false;
            txtSearch.IsEnabled = false;
            MostrarMainDirecciones();
        }

        private async void UbicacionAceptada(object sender, EventArgs e)
        {
            
            if (sourceSelected)
            {
                ubicacionInicial = ubicacion.UbicacionV;
                
                rBtnInicio.IsChecked = true;
                sourceSelected = false;
                txtSearch.IsEnabled = false;
                var direccion = Servicio.client.GetAddress(ubicacionInicial.Latitude, ubicacionInicial.Longitude);
                btnUbicacionInicio.Text = direccion;
                MostrarMainDirecciones();
                return;
            }
            else            
            {
                
                rBtnFin.IsChecked = true;
                ubicacionFinal = ubicacion.UbicacionV;
                var direccion = Servicio.client.GetAddress(ubicacionFinal.Latitude, ubicacionFinal.Longitude);
                btnUbicacionFin.Text = direccion;
                MostrarMainDirecciones();
            }
            txtSearch.IsEnabled = false;
        }

        private void MostrarMainDirecciones()
        {
            layoutDirecciones.IsVisible = true;//inicia el realizar la reserva
            layoutSeleccionDirecciones.IsVisible = false;
            layoutBarraBu.IsVisible = true;
        }

        private void MiUbicacionByButtom(object sender, EventArgs e)
        {
            MoveToActualUbicacion();
        }

        private void FechaSeleccionada(object sender, DateChangedEventArgs e)
        {
            rBtnReserva.IsChecked = true;
        }

        private async void SeleccionarInicio(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoadingApp());
            sourceSelected = true;
            txtSearch.IsEnabled = true;
            txtSearch.Focus();
            MoveToActualUbicacion();
            MostrarSeleccionarDirecciones();
            await Navigation.PopAsync();
        }

        private void MostrarSeleccionarDirecciones()
        {
            layoutSeleccionDirecciones.IsVisible = true;
            layoutDirecciones.IsVisible = false;
            layoutBarraBu.IsVisible = true;
        }

        private async void SeleccionarFin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoadingApp());
            MoveToActualUbicacion();
            sourceSelected = false;
            txtSearch.IsEnabled = true;
            txtSearch.Focus();
            MostrarSeleccionarDirecciones();
            await Navigation.PopAsync();
        }

        private void UbicacionPin(object sender, PinDragEventArgs e)
        {
            Location location = new Location(e.Pin.Position.Latitude, e.Pin.Position.Longitude);
            ubicacion.UbicacionV = location;
            MoveToActualUbicacion(ubicacion);
        }


        async void MoveToActualUbicacion()
        {

            Device.BeginInvokeOnMainThread(async () => {
                await ubicacion.GetUbicacionGPS();
                Position position = new Position(ubicacion.UbicacionV.Latitude, ubicacion.UbicacionV.Longitude);
                mapaAppCliente.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(1))
                    );
                 mapaAppCliente.Pins.Clear();

                  Pin pin = new Pin
                  {
                //      Type = PinType.Place,
                      Address = "Mi ubicacion",
                      Label = "Direccion",
                      Position = position, IsDraggable=true//, Icon=BitmapDescriptorFactory.DefaultMarker(Color.Azure)
                      ,Icon = BitmapDescriptorFactory.FromBundle("user.png")
                  };
               
               mapaAppCliente.Pins.Add(pin);
               
            });


        }
        void MoveToActualUbicacion(Ubicacion ubicacion)
        {
            Device.BeginInvokeOnMainThread(() => {
                mapaAppCliente.MoveToRegion(MapSpan.FromCenterAndRadius(
                                        new Position(ubicacion.UbicacionV.Latitude, ubicacion.UbicacionV.Longitude), Distance.FromKilometers(1))
                    );
                mapaAppCliente.Pins.Clear();

                Pin pin = new Pin
                {
                    Type = PinType.Place,
                    Address = "Mi ubicacion",
                    Label = "",
                    Position = new Position(ubicacion.UbicacionV.Latitude, ubicacion.UbicacionV.Longitude),
                    Icon = BitmapDescriptorFactory.FromBundle("user.png")
                };
                pin.IsDraggable = true;
                mapaAppCliente.Pins.Add(pin);
              
            });

        }
        private void MiUbicacion(object sender, MyLocationButtonClickedEventArgs e)
        {
        }

        private void Mapaclickeado(object sender, MapClickedEventArgs e)
        {
        }

        private void MapaFocus(object sender, FocusEventArgs e)
        {
        }
    }
}