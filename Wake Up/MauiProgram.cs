using Android;
using Android.Content;
using AndroidX.Core.Content;
using Microsoft.Maui.LifecycleEvents;
using Wake_Up.Models;
using Wake_Up.Services;
using Wake_Up.ViewModels;
using Wake_Up.Views;

namespace Wake_Up;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.ConfigureLifecycleEvents(events =>
		{
#if ANDROID
			events.AddAndroid(andriod =>
			{
				andriod.OnCreate((activity, bundle) => 
				{
                    if (ContextCompat.CheckSelfPermission(activity, Manifest.Permission.ScheduleExactAlarm)
						!= Android.Content.PM.Permission.Granted)
                    {
                        Android.Net.Uri uri = Android.Net.Uri.Parse("package:" + Android.App.Application.Context.ApplicationInfo.PackageName);
                        Intent intent = new Intent(Android.Provider.Settings.ActionRequestScheduleExactAlarm, uri);
                        activity.StartActivity(intent);
                    }
                });
			});
#endif
		});
		builder.Services.AddSingleton<AlarmService>();
		builder.Services.AddSingleton<AlarmListViewModel>();
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<AlarmDetails>();
		builder.Services.AddTransient<AlarmViewModel>();
		return builder.Build();
	}
}
