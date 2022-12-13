using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppTesisTestConductor
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
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

        }
    }
}
