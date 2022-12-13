using Android.App;
using Android.Content;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.GoogleMaps.Android.Factories;
using AndroidBitmapDescriptor = Android.Gms.Maps.Model.BitmapDescriptor;
using AndroidBitmapDescriptorFactory = Android.Gms.Maps.Model.BitmapDescriptorFactory;

namespace AppTesisTestConductor.Droid
{
    public sealed class BitmapConfig //: IBitmapDescriptorFactory
    {

       /* public AndroidBitmapDescriptor ToNative(Xamarin.Forms.GoogleMaps.BitmapDescriptor descriptor)
        {
            int iconId = 0;
            switch (descriptor.Id)
            {
                case "car":
                    iconId = Resource.Mipmap.i;
                    break;
                case "user":
                    iconId = Resource.Drawable.user;
                    break;
            }
            return AndroidBitmapDescriptorFactory.FromResource(iconId);
        }*/
    }
}