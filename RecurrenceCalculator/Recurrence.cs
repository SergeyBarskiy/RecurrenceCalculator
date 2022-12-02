using System;

namespace RecurrenceCalculator
{
    /// <summary>
    /// Default implementation of <see cref="IWritableRecurrence"/> 
    /// Recurrence setup information, but with writable properties
    /// </summary>
    public class Recurrence : IWritableRecurrence
    {
        /// <summary>
        /// Gets the day of month.
        /// </summary>
        /// <value>The day of month.</value>
        public int DayOfMonth { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Sunday.
        /// </summary>
        /// <value><c>true</c> if event can occur on Sunday; otherwise, <c>false</c>.</value>
        public bool Sunday { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Monday.
        /// </summary>
        /// <value><c>true</c>  if event can occur on Monday; otherwise, <c>false</c>.</value>
        public bool Monday { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Tuesday.
        /// </summary>
        /// <value><c>true</c>  if event can occur on Tuesday; otherwise, <c>false</c>.</value>
        public bool Tuesday { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Wednesday.
        /// </summary>
        /// <value><c>true</c>  if event can occur on Wednesday; otherwise, <c>false</c>.</value>
        public bool Wednesday { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Thursday.
        /// </summary>
        /// <value><c>true</c>  if event can occur on Thursday; otherwise, <c>false</c>.</value>
        public bool Thursday { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Friday.
        /// </summary>
        /// <value><c>true</c>  if event can occur on Friday; otherwise, <c>false</c>.</value>
        public bool Friday { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Saturday.
        /// </summary>
        /// <value><c>true</c>  if event can occur on Saturday; otherwise, <c>false</c>.</value>
        public bool Saturday { get; set; }

        /// <summary>
        /// Gets the instance of the occurrence, such as 1st or 2nd.  Set to 5 for the last instance
        /// </summary>
        /// <value>The of the occurrence, such as 1st or 2nd.  Set to 5 for the last instance.</value>
        public int Instance { get; set; }
        /// <summary>
        /// Gets the interval, such as every 2 days or every 3 years.
        /// </summary>
        /// <value>The interval, such as every 2 days or every 3 years.</value>
        public int Interval { get; set; }

        /// <summary>
        /// Gets the month of year for yearly occurrences.
        /// </summary>
        /// <value>The month of year.</value>
        public int MonthOfYear { get; set; }

        /// <summary>
        /// Gets the total number of occurrences to generate
        /// </summary>
        /// <value>The total number of occurrences to generate.</value>
        public int Occurrences { get; set; }

        /// <summary>
        /// Gets the start date, including time which is appointment type.
        /// </summary>
        /// <value>The start date, including time which is appointment type.</value>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets the type of the recurrence.
        /// </summary>
        /// <value>The type of the recurrence.</value>
        public RecurrenceType RecurrenceType { get; set; }

        /// <summary>
        /// Gets the end date.  Can be the last date of the event.  
        /// AAlternative to number of occurrences.
        /// </summary>
        /// <value>The end date.  Can be the last date of the event.  
        /// AAlternative to number of occurrences..</value>
        public DateTime? EndDate { get; set; }

    }
}
