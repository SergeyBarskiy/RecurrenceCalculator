using System;

namespace RecurrenceCalculator
{
    /// <summary>
    /// RecurrenceBuilder
    /// Allows to build recurrance configuration in a fluent API
    /// </summary>
    public class RecurrenceBuilder<T>
        where T: IWritableRecurrence, new()
    {
        private readonly T _recurrence;

        /// <summary>
        /// New instance of <see cref="RecurrenceBuilder{T}"/>
        /// </summary>
        public RecurrenceBuilder()
        {
            _recurrence = new T();
        }

        /// <summary>
        /// <see cref="IRecurrence.DayOfMonth"/>
        /// </summary>
        /// <param name="dayOfMonth">Day of the month</param>
        /// <returns><see cref="RecurrenceBuilder{T}"/></returns>
        public RecurrenceBuilder<T> DayOfMonth(int dayOfMonth)
        {
            _recurrence.DayOfMonth = dayOfMonth;
            return this;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Sunday.
        /// </summary>
        /// <param name="sunday">True, if occurs on Sundays</param>
        /// <returns><see cref="RecurrenceBuilder{T}"/></returns>
        public RecurrenceBuilder<T> Sunday(bool sunday = true)
        {
            _recurrence.Sunday = sunday;
            return this;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Monday.
        /// </summary>
        /// <param name="monday">True, if occurs on Mondays</param>
        /// <returns><see cref="RecurrenceBuilder{T}"/></returns>
        public RecurrenceBuilder<T> Monday(bool monday = true)
        {
            _recurrence.Monday = monday;
            return this;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Tuesday.
        /// </summary>
        /// <param name="tuesday">True, if occurs on Tuesday</param>
        /// <returns><see cref="RecurrenceBuilder{T}"/></returns>
        public RecurrenceBuilder<T> Tuesday(bool tuesday = true)
        {
            _recurrence.Tuesday = tuesday;
            return this;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Wednesday.
        /// </summary>
        /// <param name="wednesday">True, if occurs on Wednesday</param>
        /// <returns><see cref="RecurrenceBuilder{T}"/></returns>
        public RecurrenceBuilder<T> Wednesday(bool wednesday = true)
        {
            _recurrence.Wednesday = wednesday;
            return this;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Thursday.
        /// </summary>
        /// <param name="thursday">True, if occurs on Thursday</param>
        /// <returns><see cref="RecurrenceBuilder{T}"/></returns>
        public RecurrenceBuilder<T> Thursday(bool thursday = true)
        {
            _recurrence.Thursday = thursday;
            return this;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Friday.
        /// </summary>
        /// <param name="friday">True, if occurs on Friday</param>
        /// <returns><see cref="RecurrenceBuilder{T}"/></returns>
        public RecurrenceBuilder<T> Friday(bool friday = true)
        {
            _recurrence.Friday = friday;
            return this;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRecurrence"/> event can occur on Saturday.
        /// </summary>
        /// <param name="saturday">True, if occurs on Saturday</param>
        /// <returns><see cref="RecurrenceBuilder{T}"/></returns>
        public RecurrenceBuilder<T> Saturday(bool saturday = true)
        {
            _recurrence.Saturday = saturday;
            return this;
        }

        /// <summary>
        /// The instance of the occurrence, such as 1st or 2nd.  Set to 5 for the last instance
        /// </summary>
        /// <param name="instance">The instance of the occurrence, such as 1st or 2nd.  Set to 5 for the last instance</param>
        /// <returns><see cref="RecurrenceBuilder{T}"/></returns>
        public RecurrenceBuilder<T> Instance(int instance)
        {
            _recurrence.Instance = instance;
            return this;
        }

        /// <summary>
        /// The interval, such as every 2 days or every 3 years.
        /// </summary>
        /// <param name="interval">The interval, such as every 2 days or every 3 years.</param>
        /// <returns><see cref="RecurrenceBuilder{T}"/></returns>
        public RecurrenceBuilder<T> Interval(int interval)
        {
            _recurrence.Interval = interval;
            return this;
        }

        /// <summary>
        /// The month of year for yearly occurrences.
        /// </summary>
        /// <param name="monthOfYear">The month of year for yearly occurrences.</param>
        /// <returns><see cref="RecurrenceBuilder{T}"/></returns>
        public RecurrenceBuilder<T> MonthOfYear(int monthOfYear)
        {
            _recurrence.MonthOfYear = monthOfYear;
            return this;
        }

        /// <summary>
        /// The total number of occurrences to generate
        /// </summary>
        /// <param name="occurrences">The total number of occurrences to generate</param>
        /// <returns><see cref="RecurrenceBuilder{T}"/></returns>
        public RecurrenceBuilder<T> Occurrences(int occurrences)
        {
            _recurrence.Occurrences = occurrences;
            return this;
        }

        /// <summary>
        /// The start date, including time which is appointment type.
        /// </summary>
        /// <param name="startDate">The start date, including time which is appointment type.</param>
        /// <returns><see cref="RecurrenceBuilder{T}"/></returns>
        public RecurrenceBuilder<T> StartDate(DateTime startDate)
        {
            _recurrence.StartDate = startDate;
            return this;
        }

        /// <summary>
        /// The type of the recurrence. <see cref="IRecurrence.RecurrenceType"/>
        /// </summary>
        /// <param name="recurrenceType">Rhe type of the recurrence.</param>
        /// <returns><see cref="RecurrenceBuilder{T}"/></returns>
        public RecurrenceBuilder<T> RecurrenceType(RecurrenceType recurrenceType)
        {
            _recurrence.RecurrenceType = recurrenceType;
            return this;
        }

        /// <summary>
        /// The end date.  Can be the last date of the event.  
        /// Alternative to number of occurrences.
        /// </summary>
        /// <param name="endDate">The end date.  Can be the last date of the event. Alternative to number of occurrences.</param>
        /// <returns><see cref="RecurrenceBuilder{T}"/></returns>
        public RecurrenceBuilder<T> EndDate(DateTime endDate)
        {
            _recurrence.EndDate = endDate;
            return this;
        }

        /// <summary>
        /// Build and return the final recurrance instance
        /// </summary>
        /// <returns>Recurrance</returns>
        public T Build()
        {
            return _recurrence;
        }
    }
}
