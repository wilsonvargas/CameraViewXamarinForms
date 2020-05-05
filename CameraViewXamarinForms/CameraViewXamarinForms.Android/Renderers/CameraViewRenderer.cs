using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CameraViewXamarinForms;
using CameraViewXamarinForms.Droid.Renderers;
using CameraViewXamarinForms.Droid.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CameraView), typeof(CameraViewRenderer))]
namespace CameraViewXamarinForms.Droid.Renderers
{
    public class CameraViewRenderer : ViewRenderer<CameraView, NativeCameraView>
    {
        NativeCameraView cameraPreview;

        public CameraViewRenderer(Context context) : base(context)
        {
        }

        protected override async void OnElementChanged(ElementChangedEventArgs<CameraView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                cameraPreview = new NativeCameraView(Context);
                SetNativeControl(cameraPreview);
            }

            if (e.NewElement != null)
            {

                try
                {
                    PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Camera>();
                    if (status != PermissionStatus.Granted)
                    {
                        status = await Permissions.RequestAsync<Permissions.Camera>();
                    }

                    if (status == PermissionStatus.Granted)
                    {
                        cameraPreview.OpenCamera(e.NewElement.Camera);
                        SetNativeControl(cameraPreview);
                    }
                    else if (status != PermissionStatus.Unknown)
                    {
                        //await DisplayAlert("Camera Denied", "Can not continue, try again.", "OK");
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}