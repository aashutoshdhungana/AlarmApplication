using System.Text.Json;
using Wake_Up.Models;
using Wake_Up.ViewModels;

namespace Wake_Up.Views;

// Reload the collection on page visit
public partial class MainPage : ContentPage
{
	public MainPage(AlarmListViewModel alarms)
	{
		InitializeComponent();
		alarms.GetAlarms();
		BindingContext = alarms;
    }

	protected override void OnAppearing()
	{
		((AlarmListViewModel) BindingContext).GetAlarms();
	}
	public async void AddNew_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("AddAlarm");
	}
}

