using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CameraViewXamarinForms
{
    public enum CameraOptions
    {
        Rear,
        Front
    }

    public class CameraView : View
    {
        public static readonly BindableProperty CameraProperty = BindableProperty.Create(nameof(Camera), typeof(CameraOptions), typeof(CameraView), CameraOptions.Rear);

        public CameraOptions Camera
        {
            get { return (CameraOptions)GetValue(CameraProperty); }
            set { SetValue(CameraProperty, value); }
        }
    }
}
