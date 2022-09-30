using Wake_Up.Enums;

namespace Wake_Up.Models
{
    public class Alarm
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Time { get; set; }
        public Day[] Repeat { get; set; }
        public string YoutubeUrl { get; set; }
        public bool Vibrate { get; set; }
    }
}
