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

namespace CameraViewXamarinForms.Droid.Listeners
{
	public class CameraCaptureStateListener : CameraCaptureSession.StateCallback
	{
		public Action<CameraCaptureSession> OnConfigureFailedAction;

		public Action<CameraCaptureSession> OnConfiguredAction;

		public override void OnConfigureFailed(CameraCaptureSession session)
		{
			OnConfigureFailedAction?.Invoke(session);
		}

		public override void OnConfigured(CameraCaptureSession session)
		{
			OnConfiguredAction?.Invoke(session);
		}
	}
}