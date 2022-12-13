using System;
using System.ComponentModel;
using Xamarin.Forms;
using AppTesisTestConductor.Services;
using Xamarin.Forms.GoogleMaps;
using System.Threading.Tasks;
using System.Collections.Generic;
using ServiceReferenceInterciti;
using Plugin.LocalNotification;
using Plugin.LocalNotification.EventArgs;
using System.Timers;
using System.Threading;
namespace AppTesisTestConductor.Views
{
    public partial class AboutPage : ContentPage
    {
        static Ubicacion ubicacion = new Ubicacion();
        static bool inicio=false;
        static bool start;
        Models. Recorrido recorrido;
        System.Timers.Timer timer;
        int seg=60, min=4;
        BackgroundWorker thread = new BackgroundWorker();
        BackgroundWorker threadTracking = new BackgroundWorker();
        public AboutPage()
        {
            InitializeComponent();
            MoveToActualUbicacion();
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += ConteoEnCero;
            thread.DoWork += LlenarRecorridosRecibidos;
            threadTracking.DoWork += Tracking;
            //
            switchEscucharSolicitudes.Toggled += ActivarEscuchaSolicitudes;
            NotificationCenter.Current.NotificationTapped += NotificacionTapp;
            lstListaRecorrido.ItemSelected += RecocrridoSeleccionada;
            btnLlegue.Clicked += Llegue;
            btnLlegue.IsVisible = false;
            lblLlegue.IsVisible = false;
            //

        }

        private async void Llegue(object sender, EventArgs e)
        {
            if (threadTracking.IsBusy)
            {
                thread.WorkerSupportsCancellation = true;
                threadTracking.WorkerSupportsCancellation = true;
                thread.CancelAsync();
                threadTracking.CancelAsync();
            }
            
            ServiceReferenceInterciti.Recorrido recorridoAux = Servicio.client.FindRecorridoById(recorrido.IdRecorrido);
            recorridoAux.EstadoRecorrido = 8;
            if (Servicio.client.ActualizarRecorrido((recorridoAux)) != 0)
            {
                await DisplayAlert("Error", "No se ha logrado contactar a este usuario", "OK");
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () => {
                    await DisplayAlert("Fin", recorrido.IdCliente.Nombre + ". Ha llegado a su destino. \nBuen trabajo! ", "OK" );
                    layoutActivar.IsVisible = true;
                    lblDistancia.Text = "";
                    lblTiempo.IsVisible = true;
                    lblTiempo.Text = "0:00";
                    lblinfo.Text = "Esperar solicitudes";
                    threadTracking.WorkerSupportsCancellation = true;
                    btnLlegue.IsVisible = false;
                    lblLlegue.IsVisible = false;
                    switchEscucharSolicitudes.IsVisible = true;
                    switchEscucharSolicitudes.Toggled -= ActivarEscuchaSolicitudes;
                    switchEscucharSolicitudes.IsToggled = false;
                    switchEscucharSolicitudes.Toggled += ActivarEscuchaSolicitudes;
                    mapaApp.Pins.Clear();
                    mapaApp.Polylines.Clear();


                    return;
                });
            }
            
        }

        private async void Tracking(object sender, DoWorkEventArgs e)
        {
            if (thread.IsBusy)
            {
                thread.WorkerSupportsCancellation = true;
                thread.CancelAsync();
            }
            
            try
            {
                await ubicacion.GetUbicacionGPS();
                ServiceReferenceInterciti.MisUbicaciones miUbicacion = new MisUbicaciones { Direccion = "TepmX", IdCreador = recorrido.IdCliente.IdCliente, Latitud =(decimal) ubicacion.UbicacionV.Latitude, Longitud = (decimal)ubicacion.UbicacionV.Longitude };
                Servicio.client.AgregarUbicaciones(miUbicacion.Latitud, miUbicacion.Longitud, miUbicacion.IdCreador, miUbicacion.Direccion);
                miUbicacion = Servicio.client.FindUbicacionByNombre("TepmX", recorrido.IdCliente.IdCliente);
                double distancia = 1000;
                while (distancia >= 0.05)
                {
                    if (e.Cancel)
                    {
                        return;
                    }
                    Thread.Sleep(1000);
                    await ubicacion.GetUbicacionGPS();
                    await Device.InvokeOnMainThreadAsync(() =>
                    {
                        mapaApp.Polylines.Clear();
                        mapaApp.Pins.Clear();
                    });
                    Polyline p = new Polyline();
                    p.StrokeColor = Color.ForestGreen;
                    Pin pin;
                    Pin pin1;
                    if (inicio)
                    {

                        distancia = Servicio.GetDistance((decimal)ubicacion.UbicacionV.Latitude, recorrido.LatitudOrigen, (decimal)ubicacion.UbicacionV.Longitude, recorrido.LongitudOrigen);
                        await Device.InvokeOnMainThreadAsync(() =>
                        {
                            mapaApp.MoveToRegion(MapSpan.FromCenterAndRadius(
                                            new Position((ubicacion.UbicacionV.Latitude + (double)recorrido.LatitudOrigen) / 2, (ubicacion.UbicacionV.Longitude + (double)recorrido.LongitudOrigen) / 2), Distance.FromKilometers(distancia / 2)));
                        });
                        pin = new Pin { Position = new Position(ubicacion.UbicacionV.Latitude, ubicacion.UbicacionV.Longitude), Label = "Mi ubicacion", Type = PinType.Place, Icon = BitmapDescriptorFactory.FromBundle("car.png") };
                        pin1 = new Pin { Position = new Position((double)recorrido.LatitudOrigen, (double)recorrido.LongitudOrigen), Label = recorrido.Origen, Type = PinType.Place, Icon = BitmapDescriptorFactory.FromBundle("source.png") };
                    }
                    else
                    {
                        distancia = Servicio.GetDistance((decimal)ubicacion.UbicacionV.Latitude, recorrido.LatitudOrigen, (decimal)ubicacion.UbicacionV.Longitude, recorrido.LongitudDestino);
                        await Device.InvokeOnMainThreadAsync(() =>
                        {
                            btnLlegue.IsVisible = true;
                            lblLlegue.IsVisible = true;
                            mapaApp.MoveToRegion(MapSpan.FromCenterAndRadius(
                                            new Position((ubicacion.UbicacionV.Latitude + (double)recorrido.LatitudDestino) / 2, (ubicacion.UbicacionV.Longitude + (double)recorrido.LongitudDestino) / 2), Distance.FromKilometers(distancia / 2)));
                        });
                        pin = new Pin { Position = new Position(ubicacion.UbicacionV.Latitude, ubicacion.UbicacionV.Longitude), Label = "Mi ubicacion", Type = PinType.Place, Icon = BitmapDescriptorFactory.FromBundle("car.png") };
                        pin1 = new Pin { Position = new Position((double)recorrido.LatitudDestino, (double)recorrido.LongitudDestino), Label = recorrido.Destino, Type = PinType.Place, Icon = BitmapDescriptorFactory.FromBundle("destination.png") };
                    }
                    p.Positions.Add(pin.Position); p.Positions.Add(pin1.Position);
                    miUbicacion.Latitud = (decimal)ubicacion.UbicacionV.Latitude;
                    miUbicacion.Longitud = (decimal)ubicacion.UbicacionV.Longitude;
                    Servicio.client.ActualizarUbicaciones(miUbicacion);
                    await Device.InvokeOnMainThreadAsync(() =>
                    {
                        lblDistancia.Text = distancia.ToString() + "Km";
                        mapaApp.Polylines.Add(p);
                        mapaApp.Pins.Add(pin);
                        mapaApp.Pins.Add(pin1);
                    });
                }
                NotificationRequest notificacion = new NotificationRequest();
                notificacion.ReturningData = "Dummy Data";
                notificacion.NotificationId = recorrido.IdRecorrido;
                notificacion.BadgeNumber = recorrido.IdRecorrido;
                if (inicio)
                {

                    
                    ServiceReferenceInterciti.Recorrido recorridoAux = Servicio.client.FindRecorridoById(recorrido.IdRecorrido);
                    recorridoAux.EstadoRecorrido = 4;
                    if (Servicio.client.ActualizarRecorrido((recorridoAux)) != 0)
                    {
                        await DisplayAlert("Error", "No se ha logrado contactar a este usuario", "OK");
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(async () => {
                            await DisplayAlert("Punto de partida", "Has llegado!", "OK");
                        });

                        notificacion.Title = "Llegaste al Punto de partida!";
                        notificacion.Description = $"{recorrido.IdCliente.Nombre}. Se ha notificado al cliente!";
                        await NotificationCenter.Current.Show(notificacion);
                        inicio = false;
                        return;
                    }
                    
                }
                else
                {
                    ServiceReferenceInterciti.Recorrido recorridoAux = Servicio.client.FindRecorridoById(recorrido.IdRecorrido);
                    recorridoAux.EstadoRecorrido = 6;
                    if (Servicio.client.ActualizarRecorrido((recorridoAux)) != 0)
                    {
                        Device.BeginInvokeOnMainThread(async () => {
                            await DisplayAlert("Error", "No se ha logrado contactar a este usuario", "OK");
                        });
                        
                    }
                    else
                    {
                        notificacion.Title = "Recorrido finalizado!";
                        notificacion.Description = $"{recorrido.IdCliente.Nombre}. Llegaste al destino";
                        Device.BeginInvokeOnMainThread(async () => {
                            await DisplayAlert("Fin", recorrido.IdCliente.Nombre + ". Ha llegado a su destino \nBuen trabajo! ", "OK");
                            layoutActivar.IsVisible = true;
                            lblDistancia.Text = "";
                            lblTiempo.IsVisible = true;
                            lblTiempo.Text = "0:00";
                            lblinfo.Text = "Esperar solicitudes";
                            btnLlegue.IsVisible = false;
                            lblLlegue.IsVisible = false;
                            switchEscucharSolicitudes.IsVisible = true;
                            switchEscucharSolicitudes.Toggled -= ActivarEscuchaSolicitudes;
                            switchEscucharSolicitudes.IsToggled = false;
                            switchEscucharSolicitudes.Toggled += ActivarEscuchaSolicitudes;
                            mapaApp.Pins.Clear();
                            mapaApp.Polylines.Clear();
                            

                        });
                        await NotificationCenter.Current.Show(notificacion);
                        threadTracking.WorkerSupportsCancellation = true;
                        threadTracking.CancelAsync();
                        threadTracking.Dispose();
                        return;
                        
                    }
                   
                }
            }
            catch (Exception a)
            {
                ServiceReferenceInterciti.Recorrido recorridoAux = Servicio.client.FindRecorridoById(recorrido.IdRecorrido);
                recorridoAux.EstadoRecorrido = -1;
                if (Servicio.client.ActualizarRecorrido((recorridoAux)) != 0)
                {
                    Device.BeginInvokeOnMainThread(async () => {
                        await DisplayAlert("Error", "No se ha logrado contactar a este usuario", "OK");
                    });
                 
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () => {
                        await DisplayAlert("Error!", "Error"+a.Message, "OK");
                    });
                    
                }
            }
            
            
            
            
            
        }

        private async void LlenarRecorridosRecibidos(object sender, DoWorkEventArgs e)
        {
            
            while (true)
            {
                if (thread.CancellationPending)
                {
                    return;
                }
                
                var a = await EscucharSolicitudes();
                Thread.Sleep(3000);
                await Device.InvokeOnMainThreadAsync( () => {
                        if (a!=null)
                        {
                            lstListaRecorrido.ItemsSource = a;
                        }
                    Thread.Sleep(3000);
                    //  await DisplayAlert("Error", "0", "OK");
                });
             //   Thread.Sleep(6000);
            }
            
        }

        private async void ConteoEnCero(object sender, ElapsedEventArgs e)
        {
            seg--;
            if (seg == 0) {
                min--;
                seg = 60;
            }
            await Device.InvokeOnMainThreadAsync(() => {
                lblTiempo.Text = String.Format(" {0}:{1:00}", min, seg);
            });
            if (min < 0)
            {
                min=4;
                seg = 60;
               // await DisplayAlert("Time out", "No se ha aceptado solicitudes", "Aceptar");
            }
        }

        private void NotificacionTapp(NotificationEventArgs e)
        {
           // this.Focus();
        }
 




        private async void RecocrridoSeleccionada(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Models.Recorrido recorrido = (Models.Recorrido)lstListaRecorrido.SelectedItem;
                switchEscucharSolicitudes.Toggled -= ActivarEscuchaSolicitudes;
                switchEscucharSolicitudes.IsToggled = false;
                switchEscucharSolicitudes.Toggled += ActivarEscuchaSolicitudes;
                NotificationCenter.Current.CancelAll();
                NotificationCenter.Current.ClearAll();
                timer.Stop();
                ServiceReferenceInterciti.Recorrido recorridoAux = Servicio.client.FindRecorridoById(recorrido.IdRecorrido);
                var aux = await DisplayPromptAsync("Confirmacion", "Desea aceptar el viaje de? Puede realizar una contra oferta: \n Si el precio le parece justo deje en blanco la casilla", "Aceptar", "Cancelar", recorrido.ValorRecorrido.ToString(), 3, Xamarin.Forms.Keyboard.Numeric, "");
                recorridoAux.IdConductor = Servicio.client.FindConductorByID(Servicio.usuarioConectado.IdConductor);
                recorridoAux.EstadoRecorrido = 2;
                if (aux != "")
                {
                    recorridoAux.ValorRecorrido = Convert.ToDecimal(aux);
                }
                if (Servicio.client.ActualizarRecorrido((recorridoAux)) != 0)
                {
                    await DisplayAlert("Error", "No se ha logrado contactar a este usuario", "OK");
                    return;
                }
                else
                {
                    start = false;
                    inicio = true;
                    Device.BeginInvokeOnMainThread(async () => {
                        layoutListaRecorrido.IsVisible = false;
                        switchEscucharSolicitudes.IsVisible = false;
                        lblinfo.Text = "Distancia:";
                        lblTiempo.IsVisible = false;
                        lblDistancia.Text = "Calculando...";
                        await Navigation.PushModalAsync(new LoadingPage());
                    });

                }
                lstListaRecorrido.SelectedItem = null;
            }
            

        }

        void MoveToActualUbicacion()
        {

            Device.BeginInvokeOnMainThread(async () => {
                await ubicacion.GetUbicacionGPS();
                mapaApp.MoveToRegion(MapSpan.FromCenterAndRadius(
                                        new Position(ubicacion.UbicacionV.Latitude, ubicacion.UbicacionV.Longitude), Distance.FromKilometers(1))
                    );
                
            });


        }
        private void MoveToActualUbicacion(object sender, MyLocationButtonClickedEventArgs e)
        {
            

                Device.BeginInvokeOnMainThread(async () => {

                        await ubicacion.GetUbicacionGPS();
                        mapaApp.MoveToRegion(MapSpan.FromCenterAndRadius(
                                                new Position(ubicacion.UbicacionV.Latitude, ubicacion.UbicacionV.Longitude), Distance.FromKilometers(0.5))
                            );
                });


        }
        private async Task< List<Models.Recorrido>> EscucharSolicitudes()
        {
            try
            {
                List<Models.Recorrido> recorridosAux = new List<Models.Recorrido>();
                List<Models.Recorrido> recorridos = null;
                if (start)
                {
                    recorridos = Servicio.WCFToAppList(Servicio.client.FindSolicitudRecorrido());
                }
                else
                {
                       recorridos = Servicio.WCFToAppList(Servicio.client.FindRecorridosByConductor(Servicio.usuarioConectado.IdConductor));
                }
                if (recorridos != null)
                {
                    foreach (var iter in recorridos)
                    {
                        NotificationRequest notificacion = new NotificationRequest();
                        notificacion.ReturningData = "Dummy Data";

                        switch (iter.IdEstadoRecorrido)
                        {
                            case 1:
                                if (!recorridosAux.Contains(iter))
                                {
                                    notificacion.Title = "Nuevo recorrido en espera!";
                                    notificacion.Description = $"{iter.IdCliente.Nombre}. Ha solicitado un viaje";
                                    notificacion.NotificationId = iter.IdRecorrido;
                                    notificacion.BadgeNumber = iter.IdRecorrido;
                                    await NotificationCenter.Current.Show(notificacion);
                                    recorridosAux.Add(iter);
                                }
                                break;
                            case 3:
                                var r = Servicio.client.FindRecorridoById(iter.IdRecorrido);
                                r.EstadoRecorrido = 10;
                                if (Servicio.client.ActualizarRecorrido((r)) != 0)
                                {
                                    await DisplayAlert("Error", "No se ha logrado contactar a este usuario", "OK");
                                }
                                notificacion.Title = "Recorrido inicio!";
                                notificacion.Description = $"{iter.IdCliente.Nombre}. Te esta esperando. Ve al punto de Partia";
                                notificacion.NotificationId = iter.IdRecorrido;
                                notificacion.BadgeNumber = iter.IdRecorrido;
                                await NotificationCenter.Current.Show(notificacion);
                                await Navigation.PopAsync();
                                this.recorrido = iter;
                                if (!threadTracking.IsBusy && inicio)
                                {
                                    threadTracking.RunWorkerAsync();
                                    return null;

                                }

                                break;
                            case 5:
                                r = Servicio.client.FindRecorridoById(iter.IdRecorrido);
                                r.EstadoRecorrido = 10;
                                if (Servicio.client.ActualizarRecorrido((r)) != 0)
                                {
                                    await DisplayAlert("Error", "No se ha logrado contactar a este usuario", "OK");
                                }
                                notificacion.Title = "Cliente Notificado!";
                                notificacion.Description = $"{iter.IdCliente.Nombre}. En camino a destino";
                                notificacion.NotificationId = iter.IdRecorrido;
                                notificacion.BadgeNumber = iter.IdRecorrido;
                                await NotificationCenter.Current.Show(notificacion);
                                this.recorrido = iter;
                                if (!threadTracking.IsBusy)
                                {
                                    threadTracking.RunWorkerAsync();
                                   return null;
                                }
                                break;
                            case -1:

                                notificacion.Title = "Se ha cancelado el Viaje!";
                                notificacion.Description = $"Recorrido no terminado!";
                                notificacion.NotificationId = iter.IdRecorrido;
                                notificacion.BadgeNumber = iter.IdRecorrido;
                                await NotificationCenter.Current.Show(notificacion);
                                this.recorrido = iter;
                                Device.BeginInvokeOnMainThread(async () => {
                                    await DisplayAlert("Fin", recorrido.IdCliente.Nombre + ". Ha llegado a su destino. \nBuen trabajo! ", "OK");
                                    layoutActivar.IsVisible = true;
                                    lblDistancia.Text = "";
                                    lblTiempo.IsVisible = true;
                                    lblTiempo.Text = "0:00";
                                    lblinfo.Text = "Esperar solicitudes";
                                    threadTracking.WorkerSupportsCancellation = true;
                                    btnLlegue.IsVisible = false;
                                    lblLlegue.IsVisible = false;
                                    switchEscucharSolicitudes.IsVisible = true;
                                    switchEscucharSolicitudes.Toggled -= ActivarEscuchaSolicitudes;
                                    switchEscucharSolicitudes.IsToggled = false;
                                    switchEscucharSolicitudes.Toggled += ActivarEscuchaSolicitudes;
                                    mapaApp.Pins.Clear();
                                    mapaApp.Polylines.Clear();
                                    threadTracking.WorkerSupportsCancellation = true;
                                    threadTracking.CancelAsync();
                                    threadTracking.Dispose();
                                    thread.WorkerSupportsCancellation = true;
                                    thread.CancelAsync();
                                    thread.Dispose();

                                    return;
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
                ServiceReferenceInterciti.Recorrido recorridoAux = Servicio.client.FindRecorridoById(recorrido.IdRecorrido);
                recorridoAux.EstadoRecorrido = -1;
                if (Servicio.client.ActualizarRecorrido((recorridoAux)) != 0)
                {
          //          await DisplayAlert("Error", "No se ha logrado contactar a este usuario", "OK");
                }
                else
                {
               //     await DisplayAlert("Finalizado!", "El viaje a finalizado con exito", "OK");
                }
            }
            return null;
        }

        private async void ActivarEscuchaSolicitudes(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                await Device.InvokeOnMainThreadAsync(async () => {
                });
                if (Servicio.usuarioConectado.Vehiculo.IdVehiculo>0)
                {
                    if (!thread.IsBusy)
                    {
                        start = true;
                        thread.RunWorkerAsync();
                        timer.Start();
                        lstListaRecorrido.IsVisible = true;
                        layoutListaRecorrido.IsVisible = true;  
                    }
                }
                else
                {
                   string aux= await DisplayActionSheet("Error!! \nNo tiene un vehículo seleccionado.", "Cancelar", "Seleccionar un vehículo");
                    if (aux == "Seleccionar un vehículo")
                    {
                        Page page = new InformacionGeneralPage();
                        await this.Navigation.PushAsync(page);
                        

                    }
                    else
                    {

                    }
                    switchEscucharSolicitudes.Toggled -= ActivarEscuchaSolicitudes;
                    switchEscucharSolicitudes.IsToggled = false;
                    switchEscucharSolicitudes.Toggled += ActivarEscuchaSolicitudes;
                }
            }
            else
            {
                layoutListaRecorrido.IsVisible = false;
                await DisplayAlert("Time out", "No se han recibido solicitudes", "OK");
                NotificationCenter.Current.CancelAll();
                NotificationCenter.Current.ClearAll();
                thread.WorkerSupportsCancellation = true;
                thread.CancelAsync();
                timer.Stop();
                min = 3;
                seg = 59;
            }
        }
    }
}