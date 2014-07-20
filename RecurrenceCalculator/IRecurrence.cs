using System;

namespace RecurrenceCalculator
{
    /// <summary>
    /// Interface IRecurrence
    /// Recurrence setup information
    /// </summary>
    public interface IRecurrence
    {
        /// <summary>
        /// Gets the day of month.
        /// </summary>
        /// <value>The day of month.</value>
        int DayOfMonth { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Sunday.
        /// </summary>
        /// <value><c>true</c> if event can occur on Sunday; otherwise, <c>false</c>.</value>
        bool Sunday { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Monday.
        /// </summary>
        /// <value><c>true</c>  if event can occur on Monday; otherwise, <c>false</c>.</value>
        bool Monday { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Tuesday.
        /// </summary>
        /// <value><c>true</c>  if event can occur on Tuesday; otherwise, <c>false</c>.</value>
        bool Tuesday { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Wednesday.
        /// </summary>
        /// <value><c>true</c>  if event can occur on Wednesday; otherwise, <c>false</c>.</value>
        bool Wednesday { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Thursday.
        /// </summary>
        /// <value><c>true</c>  if event can occur on Thursday; otherwise, <c>false</c>.</value>
        bool Thursday { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Friday.
        /// </summary>
        /// <value><c>true</c>  if event can occur on Friday; otherwise, <c>false</c>.</value>
        bool Friday { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Saturday.
        /// </summary>
        /// <value><c>true</c>  if event can occur on Saturday; otherwise, <c>false</c>.</value>
        bool Saturday { get; }

        /// <summary>
        /// Gets the instance of the occurrence, such as 1st or 2nd.  Set to 5 for the last instance
        /// </summary>
        /// <value>The of the occurrence, such as 1st or 2nd.  Set to 5 for the last instance.</value>
        int Instance { get; }

        /// <summary>
        /// Gets the day of the month.
        /// </summary>
        /// <value>The day.</value>
        int Day { get; }

        /// <summary>
        /// Gets the interval, such as every 2 days or every 3 years.
        /// </summary>
        /// <value>The interval, such as every 2 days or every 3 years.</value>
        int Interval { get; }

        /// <summary>
        /// Gets the month of year for yearly occurrences.
        /// </summary>
        /// <value>The month of year.</value>
        int MonthOfYear { get; }

        /// <summary>
        /// Gets the total number of occurrences to generate
        /// </summary>
        /// <value>The total number of occurrences to generate.</value>
        int Occurrences { get; }

        /// <summary>
        /// Gets the start date, including time which is appointment type.
        /// </summary>
        /// <value>The start date, including time which is appointment type.</value>
        DateTime StartDate { get; }

        /// <summary>
        /// Gets the type of the recurrence.
        /// </summary>
        /// <value>The type of the recurrence.</value>
        RecurrenceType RecurrenceType { get; }

        /// <summary>
        /// Gets the end date.  Can be the last date of the event.  
        /// AAlternative to number of occurrences.
        /// </summary>
        /// <value>The end date.  Can be the last date of the event.  
        /// AAlternative to number of occurrences..</value>
        DateTime? EndDate { get; }

    }
}