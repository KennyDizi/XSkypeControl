using Android.App;
using Android.Content.PM;
using Android.OS;
using NControl.Droid;

namespace XNControls.Droid
{
    [Activity(Label = "XNControls", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            NControlViewRenderer.Init();
            LoadApplication(new App());
        }
    }
}

