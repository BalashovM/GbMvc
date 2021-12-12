namespace WebMVC.Models
{
    public class WorkTimeViewModel
    {
        public string StartWorkTime { get; set; }
        public string EndWorkTime { get; set; }
        public string StartLunchTime { get; set; }
        public string EndLunchTime { get; set; }

        public WorkTimeViewModel()
        {
            StartWorkTime = "8:00";
            EndWorkTime = "20:00";
            StartLunchTime = "13:00";
            EndLunchTime = "14:00";
        }
    }
}
