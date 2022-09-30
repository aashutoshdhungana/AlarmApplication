using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Java.Lang;
using Microsoft.Maui.Platform;
using Wake_Up.Services;

namespace Wake_Up;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
    {
        base.OnCreate(savedInstanceState, persistentState);
        if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ScheduleExactAlarm)
                != Android.Content.PM.Permission.Granted)
        {
            Android.Net.Uri uri = Android.Net.Uri.Parse("package:" + Android.App.Application.Context.ApplicationInfo.PackageName);
            Intent intent = new Intent(Android.Provider.Settings.ActionRequestScheduleExactAlarm, uri);
            StartActivity(intent);
        }
    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
    {
        if (requestCode == 1)
        {
            if (grantResults.Length > 0 && grantResults[0] == Android.Content.PM.Permission.Granted)
            {
                Console.Write("Granted");
            }
        }
    }
}
