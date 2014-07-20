namespace RecurrenceCalculator
{
    /// <summary>
    /// Enum RecurrenceType
    /// Types of recurrence supported by the calculator
    /// </summary>
    public enum RecurrenceType
    {
        /// <summary>
        /// The daily
        /// </summary>
        Daily = 1,
        /// <summary>
        /// The weekly
        /// </summary>
        Weekly = 2,
        /// <summary>
        /// The monthly
        /// </summary>
        Monthly = 3,
        /// <summary>
        /// The N-th day of the month
        /// </summary>
        MonthNth = 4,
        /// <summary>
        /// The yearly
        /// </summary>
        Yearly = 5,
        /// <summary>
        /// The N-th day of the month of the year
        /// </summary>
        YearNth = 6
    }
}
