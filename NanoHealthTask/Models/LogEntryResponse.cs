﻿namespace NanoHealthTask.Models
{
    public class LogEntryResponse
    {
        public int Id { get; set; }
        public string Service { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
