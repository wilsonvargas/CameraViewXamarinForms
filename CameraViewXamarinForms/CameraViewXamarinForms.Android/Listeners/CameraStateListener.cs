using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Hardware.Camera2;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CameraViewXamarinForms.Droid.Views;

namespace CameraViewXamarinForms.Droid.Listeners
{
	public class CameraStateListener : CameraDevice.StateCallback
	{
		public NativeCameraView Camera;

		public override void OnOpened(CameraDevice camera)
		{
			if (Camera == null) return;

			Camera.CameraDevice = camera;
			Camera.StartPreview();
			Camera.OpeningCamera = false;
		}

		public override void OnDisconnected(CameraDevice camera)
		{
			if (Camera == null) return;

			camera.Close();
			Camera.CameraDevice = null;
			Camera.OpeningCamera = false;
		}

		public override void OnError(CameraDevice camera, CameraError error)
		{
			camera.Close();

			if (Camera == null) return;

			Camera.CameraDevice = null;
			Camera.OpeningCamera = false;
		}
	}
}