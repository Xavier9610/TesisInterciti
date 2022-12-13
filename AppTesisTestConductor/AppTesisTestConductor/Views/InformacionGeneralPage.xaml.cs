using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTesisTestConductor.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppTesisTestConductor.Models;
namespace AppTesisTestConductor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformacionGeneralPage : ContentPage
    {
        BackgroundWorker thread = new BackgroundWorker();
        public InformacionGeneralPage()
        {
            
            InitializeComponent();
            thread.DoWork += LlenarRecorridosRecibidos;
            btnVehiculos.Clicked += MostrarListaVehiculos;
            btnRecorridos.Clicked += MostrarListaRecorridos;
            //btnLugares.Clicked += MostrarListaLugares;
            btnFiltrar.Clicked += MostrarFiltros;
            lstRecorridos.ItemSelected += RecorridoGetInfo;
            lstVehiculos.ItemSelected += VehiculoGetInfo;
            lstUbicaciones.ItemSelected += UbicacionesGetInfo;
            //
            btnAddLugar.Clicked += AddLugar;
            btnAddViaje.Clicked += AddViaje;
            btnAddVehiculo.Clicked += AddVehiculo;

            layoutVehiculo.IsVisible = true;
            layoutLugares.IsVisible = false;
            layoutViajes.IsVisible = false;

            thread.RunWorkerAsync();
        }

        private void AddVehiculo(object sender, EventArgs e)
        {
            Page page = new CRUDPage((Vehiculo) new Vehiculo(), false);
            this.Navigation.PushAsync(page);
        }

        private void AddViaje(object sender, EventArgs e)
        {
            Page page = new CRUDPage((Recorrido)  new Recorrido(), false);
            this.Navigation.PushAsync(page);
        }

        private void AddLugar(object sender, EventArgs e)
        {
            Page page = new CRUDPage((MisUbicaciones) new MisUbicaciones(), false);
            this.Navigation.PushAsync(page);
        }

        private async void UbicacionesGetInfo(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                MisUbicaciones conductor = (MisUbicaciones)lstUbicaciones.SelectedItem;
                Page page = new CRUDPage(conductor, true);
                await this.Navigation.PushAsync(page);
                lstUbicaciones.SelectedItem = null;
            }
           
        }

        private async void VehiculoGetInfo(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Vehiculo conductor = (Vehiculo)lstVehiculos.SelectedItem;
                Page page = new CRUDPage(conductor, true);
                await this.Navigation.PushAsync(page);
                lstVehiculos.SelectedItem = null;
            }
            
        }
        
        private async void RecorridoGetInfo(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Recorrido conductor = (Recorrido)lstRecorridos.SelectedItem;
                Page page = new CRUDPage(conductor, true);
                await this.Navigation.PushAsync(page);
                lstRecorridos.SelectedItem = null;
            }
            
        }

        private void LlenarRecorridosRecibidos(object sender, DoWorkEventArgs e)
        {
            llenarListView();
        }

        private void MostrarFiltros(object sender, EventArgs e)
        {
            if (layoutVehiculo.IsVisible) {
            }
            else if (layoutViajes.IsVisible)
            {

            }
            else
            {

            }
        }   


        private void MostrarListaLugares(object sender, EventArgs e)
        {
            layoutVehiculo.IsVisible = false;
            layoutViajes.IsVisible = false;
            layoutLugares.IsVisible = true;
        }

        private void MostrarListaRecorridos(object sender, EventArgs e)
        {
            layoutVehiculo.IsVisible = false;
            layoutLugares.IsVisible = false;
            layoutViajes.IsVisible = true;
        }

        private void MostrarListaVehiculos(object sender, EventArgs e)
        {
            layoutVehiculo.IsVisible = true;
            layoutViajes.IsVisible = false;
            layoutLugares.IsVisible = false;
        }

        public async void llenarListView()
        {
            var x = Servicio.WCFToAppList(Servicio.client.ListarVehiculo());
            var y = Servicio.WCFToAppList(Servicio.client.FindRecorridosByConductor(Servicio.usuarioConectado.IdConductor));
            await Device.InvokeOnMainThreadAsync(() => {
                if (x!=null)
                {
                    lstVehiculos.ItemsSource = x;
                }
               if (y != null)
                {
                    lstRecorridos.ItemsSource = y;
                }
            });
           
        }
    }
}