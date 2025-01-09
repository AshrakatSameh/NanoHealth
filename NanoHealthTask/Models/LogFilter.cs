namespace NanoHealthTask.Models
{
    public class LogFilter
    {
        public int Id { get; set; }
        public string? Service { get; set; }
        public string? Level { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
