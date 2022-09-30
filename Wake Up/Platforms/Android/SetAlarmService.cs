using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.Net.Wifi.P2p.Nsd;
using AndroidX.Activity.Result;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Microsoft.Maui.Platform;
using System.CodeDom.Compiler;

namespace Wake_Up.Services
{
    public partial class SetAlarmService
    {
        public SetAlarmService()
        {
        }
        public void ScheduleAlarm()
        {
;           DateTimeOffset now = DateTimeOffset.UtcNow.AddMinutes(2);
            long alarmTime = now.ToUnixTimeMilliseconds();
            string youtubeLink = "https://www.youtube.com/watch?v=7iUgCFhj8yk";
            var alarmManager = (AlarmManager) Android.App.Application.Context.GetSystemService(Context.AlarmService);
            Intent youtubeIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse(youtubeLink));
            PendingIntent pendignIntent = PendingIntent.GetActivity(Android.App.Application.Context, 0, youtubeIntent, PendingIntentFlags.Immutable);
            var info = new AlarmManager.AlarmClockInfo(alarmTime, pendignIntent);
            alarmManager.SetAlarmClock(info, pendignIntent);
        }

        public void RunAlarm()
        {
        }
    }
}
