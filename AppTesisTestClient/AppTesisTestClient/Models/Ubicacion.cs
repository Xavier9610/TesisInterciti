using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppTesisTestClient
{
    class Ubicacion
    {
        private Location ubicacionV;

        public Location UbicacionV { get => ubicacionV; set => ubicacionV = value; }

        public async Task GetUbicacionGPS()
        {
            try
            {
                var request = new GeolocationRequest(Xamarin.Essentials.GeolocationAccuracy.Medium);
                var ubicacion = await Geolocation.GetLocationAsync(request);
                if (ubicacion != null)
                {
                    this.ubicacionV = ubicacion;
                }
                else
                {
                    var ubicacionF = await Geolocation.GetLastKnownLocationAsync();
                    this.ubicacionV = ubicacionF;
                }

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await GetUbicacionGPS();
            }
            catch (FeatureNotEnabledException fneEx)
            {
                await GetUbicacionGPS();
            }
            catch (PermissionException pEx)
            {
                await GetUbicacionGPS();
            }
            catch (Exception ex)
            {
               await GetUbicacionGPS();
            }

        }
    }
}
