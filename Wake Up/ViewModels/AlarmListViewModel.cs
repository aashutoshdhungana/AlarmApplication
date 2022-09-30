using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wake_Up.Models;
using Wake_Up.Services;
using Wake_Up.Views;

namespace Wake_Up.ViewModels
{
    public partial class AlarmListViewModel: BaseViewModel
    {
        AlarmService _alarmService;
        public ObservableCollection<Alarm> Alarms { get; } = new();

        public AlarmListViewModel(AlarmService alarmService)
        {
            Title = "Alarms"; 
            _alarmService = alarmService;
        }

        public async void GetAlarms()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                Alarms.Clear();
                var alarms = _alarmService.GetAlarms();
                foreach (var alarm in alarms)
                {
                    Alarms.Add(alarm);
                }
            }
            catch(Exception e)
            {
                await Shell.Current.DisplayAlert("Error!", e.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async void GotoAlarmDetails(Alarm alarm)
        {
            await Shell.Current.GoToAsync("AddAlarm", true,
                new Dictionary<string, object>
                {
                    { "Alarm", alarm }
                });
        }
    }
}
