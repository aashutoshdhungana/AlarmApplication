using System.Text.Json;
using Wake_Up.Models;

namespace Wake_Up.Services
{
    public class AlarmService
    {
        private List<Alarm> alarms;

        public AlarmService()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "alarms.json");
            if (File.Exists(path))
            {
                string jsonData = File.ReadAllText(path);
                alarms = JsonSerializer.Deserialize<List<Alarm>>(jsonData);
            }
            else
            {
                alarms = new List<Alarm>();
            }
        }
        public List<Alarm> GetAlarms()
        {
            return alarms;
        }

        public Alarm GetAlarmById(Guid Id)
        {
            var alarm = alarms.Where(x => x.Id == Id)
                        .FirstOrDefault();
            return alarm;
        }

        public void DeleteAlarmById(Guid Id)
        {
            var alarm = alarms.Where(x => x.Id == Id)
                        .FirstOrDefault();
            alarms.Remove(alarm);
        }

        public void EditAlarmById(Guid Id, Alarm alarm)
        {
            int index = alarms.FindIndex(x => x.Id == Id);
            alarms[index].Title = alarm.Title;
            alarms[index].Time = alarm.Time;
            alarms[index].YoutubeUrl = alarm.YoutubeUrl;
            alarms[index].Repeat = alarm.Repeat;
            alarms[index].Vibrate = alarm.Vibrate;
        }

        public void AddAlarm(Alarm alarm)
        {
            alarm.Id = Guid.NewGuid();
            alarms.Add(alarm);
            var service = new SetAlarmService();
            service.ScheduleAlarm();
        }

        public void SaveChanges()
        {
            string finalReult = JsonSerializer.Serialize(alarms);
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "alarms.json");
            File.WriteAllText(path, finalReult);
        }
    }
}
