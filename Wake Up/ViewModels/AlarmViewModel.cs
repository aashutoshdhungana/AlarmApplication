using CommunityToolkit.Mvvm.ComponentModel;
using Wake_Up.Models;

namespace Wake_Up.ViewModels
{
    [QueryProperty(nameof(Alarm), "Alarm")]
    public partial class AlarmViewModel: BaseViewModel
    {
        [ObservableProperty]
        Alarm alarm;
    }
}
