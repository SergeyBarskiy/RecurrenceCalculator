using System;
using System.Collections.Generic;
using System.Text;

namespace RecurrenceCalculator
{
    public class Recurrence : IRecurrence
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

        public int Interval { get; set; }

        public int MonthOfYear { get; set; }

        public int Occurrences { get; set; }

        public DateTime StartDate { get; set; }

        public RecurrenceType RecurrenceType { get; set; }

        public DateTime? EndDate { get; set; }
    }
    public class RecurrenceBuilder
    {
        private readonly Recurrence recurrence = new Recurrence();

        public RecurrenceBuilder DayOfMonth(int DayOfMonth)
        {
            recurrence.DayOfMonth = DayOfMonth;
            return this;
        }

        public RecurrenceBuilder Sunday(bool Sunday = true)
        {
            recurrence.Sunday = Sunday;
            return this;
        }

        public RecurrenceBuilder Monday(bool Monday = true)
        {
            recurrence.Monday = Monday;
            return this;
        }
        public RecurrenceBuilder Tuesday(bool Tuesday = true)
        {
            recurrence.Tuesday = Tuesday;
            return this;
        }
        public RecurrenceBuilder Wednesday(bool Wednesday = true)
        {
            recurrence.Wednesday = Wednesday;
            return this;
        }
        public RecurrenceBuilder Thursday(bool Thursday = true)
        {
            recurrence.Thursday = Thursday;
            return this;
        }
        public RecurrenceBuilder Friday(bool Friday = true)
        {
            recurrence.Friday = Friday;
            return this;
        }
        public RecurrenceBuilder Saturday(bool Saturday = true)
        {
            recurrence.Saturday = Saturday;
            return this;
        }
        public RecurrenceBuilder Instance(int Instance)
        {
            recurrence.Instance = Instance;
            return this;
        }
        public RecurrenceBuilder Interval(int Interval)
        {
            recurrence.Interval = Interval;
            return this;
        }
        public RecurrenceBuilder MonthOfYear(int MonthOfYear)
        {
            recurrence.MonthOfYear = MonthOfYear;
            return this;
        }
        public RecurrenceBuilder Occurrences(int Occurrences)
        {
            recurrence.Occurrences = Occurrences;
            return this;
        }
        public RecurrenceBuilder StartDate(DateTime StartDate)
        {
            recurrence.StartDate = StartDate;
            return this;
        }
        public RecurrenceBuilder RecurrenceType(RecurrenceType RecurrenceType)
        {
            recurrence.RecurrenceType = RecurrenceType;
            return this;
        }
        public RecurrenceBuilder EndDate(DateTime EndDate)
        {
            recurrence.EndDate = EndDate;
            return this;
        }

        public Recurrence Build()
        {
            return recurrence;
        }
    }
}
