using System;


namespace RecurrenceCalculator.Tests
{
    public class AppointmentRecurrence : IRecurrence
    {
        public int DayOfMonth { get; set; }
        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public int Instance { get; set; }
        public int Day { get; set; }
        public int Interval { get; set; }
        public int MonthOfYear { get; set; }
        public int Occurrences { get; set; }
        public DateTime StartDate { get; set; }
        public RecurrenceType RecurrenceType { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
