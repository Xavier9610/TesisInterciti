using AppTesisTestClient.Models;
using AppTesisTestClient.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTesisTestClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformacionGeneralPage : ContentPage
    {
        BackgroundWorker thread = new BackgroundWorker();
        public InformacionGeneralPage()
        {
            InitializeComponent();
            this.Focused += UpdateDatos;
            this.Unfocused += UpdateDatos;
            thread.DoWork += LlenarRecorridosRecibidos;
            btnRecorridos.Clicked += MostrarListaRecorridos;
            btnLugares.Clicked += MostrarListaLugares;
         //   btnFiltrar.Clicked += MostrarFiltros;
            lstRecorridos.ItemSelected += RecorridoGetInfo;
            lstUbicaciones.ItemSelected += UbicacionesGetInfo;
            btnAddLugar.Clicked += AddLugar;
            btnAddViaje.Clicked += AddViaje;
            layoutLugares.IsVisible = true;
            layoutViajes.IsVisible = false;
            thread.RunWorkerAsync();
        }

        private void UpdateDatos(object sender, FocusEventArgs e)
        {
            thread.RunWorkerAsync();
        }

        private void AddViaje(object sender, EventArgs e)
        {
            App.Current.MainPage = new AppShell();
        }

        private void AddLugar(object sender, EventArgs e)
        {
            Page page = new CRUDPage((MisUbicaciones)null, false);
            this.Navigation.PushAsync(page);
        }

        private async void UbicacionesGetInfo(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem !=null)
            {
                MisUbicaciones conductor = (MisUbicaciones)lstUbicaciones.SelectedItem;
                Page page = new CRUDPage(conductor, true);
                await this.Navigation.PushAsync(page);
                lstUbicaciones.SelectedItem = null;
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

    

        private void MostrarListaLugares(object sender, EventArgs e)
        {
           layoutViajes.IsVisible = false;
            layoutLugares.IsVisible = true;
        }

        private void MostrarListaRecorridos(object sender, EventArgs e)
        {
   
            layoutLugares.IsVisible = false;
            layoutViajes.IsVisible = true;
        }

        private void MostrarListaVehiculos(object sender, EventArgs e)
        {
            layoutViajes.IsVisible = false;
            layoutLugares.IsVisible = false;
        }

        public async void llenarListView()
        {
            var x = Servicio.WCFToAppList(Servicio.client.ListarUbicaciones(Servicio.usuarioConectado.IdCliente));
            var y = Servicio.WCFToAppList(Servicio.client.FindRecorridosByCliente(Servicio.usuarioConectado.IdCliente));
            await Device.InvokeOnMainThreadAsync(() => {
                if (x != null)
                {
                    lstUbicaciones.ItemsSource = x;
                }
                if (y != null)
                {
                    lstRecorridos.ItemsSource = y;
                }
            });

        }
    }
}