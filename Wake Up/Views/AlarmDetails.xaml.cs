using System.Net.Http.Json;
using System.Text.Json;
using Wake_Up.Models;
using Wake_Up.Services;
using Wake_Up.ViewModels;

namespace Wake_Up.Views;

public partial class AlarmDetails : ContentPage
{
	AlarmService _alarmService;
	public AlarmDetails(AlarmService alarmService, AlarmViewModel alarmView)
	{
		InitializeComponent();
		_alarmService = alarmService;
		if (alarmView.Alarm == null)
		{
			alarmView.Alarm = new Alarm()
			{
				Title = "",
				Time = DateTime.Now.TimeOfDay,
				Vibrate = true,
				YoutubeUrl = "",
				Repeat = new Enums.Day[] { }
			};
		}
		BindingContext = alarmView;
	}

	public async void Add_Clicked(object sender, EventArgs e)
	{
		if (BindingContext is AlarmViewModel alarmView)
		{
			var storedAlarm = _alarmService.GetAlarmById(alarmView.Alarm.Id);
			if (storedAlarm == null)
			{
				_alarmService.AddAlarm(alarmView.Alarm);
			}
			else
			{
				_alarmService.EditAlarmById(alarmView.Alarm.Id, alarmView.Alarm);
			}
			_alarmService.SaveChanges();
			await Shell.Current.GoToAsync("///MainPage");
        }
	}
}