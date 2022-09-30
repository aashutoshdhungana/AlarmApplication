namespace Wake_Up;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("AddAlarm", typeof(Views.AlarmDetails));
	}
}
