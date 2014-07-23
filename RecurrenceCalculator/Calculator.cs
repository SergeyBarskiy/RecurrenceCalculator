using System;
using System.Collections.Generic;

namespace RecurrenceCalculator
{

    /// <summary>
    /// Class Calculator.
    /// Performs occurrence calculations based on recurrence pattern
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Calculates the occurrences.
        /// </summary>
        /// <param name="recurrence">The recurrence pattern.</param>
        /// <returns>The dates for occurrences.</returns>
        /// <exception cref="System.ArgumentException">Occurs when recurrence patter is invalid</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when type of recurrence is invalid</exception>
        public IEnumerable<DateTime> CalculateOccurrences(IRecurrence recurrence)
        {
            var validationResult = ValidateRecurrence(recurrence);
            if (!string.IsNullOrEmpty(validationResult))
            {
                throw new ArgumentException(validationResult);
            }
            switch (recurrence.RecurrenceType)
            {
                case RecurrenceType.Daily:
                    return GetDailyRecurrenceOccurrences(recurrence);
                case RecurrenceType.Weekly:
                    return GetWeeklyRecurrenceOccurrences(recurrence);
                case RecurrenceType.Monthly:
                    return GetMonthlyRecurrenceOccurrences(recurrence);
                case RecurrenceType.MonthNth:
                    return GetMonthNthRecurrenceOccurrences(recurrence);
                case RecurrenceType.Yearly:
                    return GetYearlyRecurrenceOccurrences(recurrence);
                case RecurrenceType.YearNth:
                    return GetYearNthRecurrenceOccurrences(recurrence);
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }


        /// <summary>
        /// Gets the daily recurrence occurrences.
        /// </summary>
        /// <param name="recurrence">The recurrence pattern.</param>
        /// <returns>The dates for occurrences.</returns>
        private IEnumerable<DateTime> GetDailyRecurrenceOccurrences(IRecurrence recurrence)
        {
            var returnValue = new List<DateTime>();

            DateTime date = recurrence.StartDate.Date;
            while (!IsDayOfTheWeekMatched(date, recurrence))
            {
                date = date.AddDays(1);
            }

            bool keepLooping = true;

            do
            {
                if (GeneratedEnoughOccurrences(returnValue.Count, date, recurrence))
                {
                    keepLooping = false;
                }
                else
                {
                    returnValue.Add(date.Add(recurrence.StartDate.TimeOfDay));
                    date = IsWeekdaySet(recurrence) ? (date.AddDays((date.DayOfWeek == DayOfWeek.Friday) ? 3 : 1)) : date.AddDays(recurrence.Interval);

                }
            }
            while (keepLooping);

            return returnValue;
        }

        /// <summary>
        /// Gets the weekly recurrence occurrences.
        /// </summary>
        /// <param name="recurrence">The recurrence pattern.</param>
        /// <returns>The dates for occurrences.</returns>
        private IEnumerable<DateTime> GetWeeklyRecurrenceOccurrences(IRecurrence recurrence)
        {
            var returnValue = new List<DateTime>();

            DateTime date = recurrence.StartDate.Date;
            // find sunday before - start of first week
            while (date.DayOfWeek != DayOfWeek.Sunday)
            {
                date = date.AddDays(-1);
            }

            bool keepLooping = true;

            do
            {
                if (GeneratedEnoughOccurrences(returnValue.Count, date, recurrence))
                {
                    keepLooping = false;
                }
                else
                {
                    // run through this week
                    for (int day = 0; day < 7; day++)
                    {

                        var tempDate = date.AddDays(day);
                        if (GeneratedEnoughOccurrences(returnValue.Count, tempDate, recurrence))
                        {
                            keepLooping = false;
                            break;
                        }

                        if (tempDate >= recurrence.StartDate.Date && IsDayOfTheWeekMatched(tempDate, recurrence))
                        {
                            returnValue.Add(tempDate.Add(recurrence.StartDate.TimeOfDay));
                        }
                    }
                    // advance to the next week based on number of weeks to skip 
                    date = date.AddDays(7 * recurrence.Interval);
                }
            }
            while (keepLooping);

            return returnValue;
        }

        /// <summary>
        /// Gets the monthly recurrence occurrences.
        /// </summary>
        /// <param name="recurrence">The recurrence pattern.</param>
        /// <returns>The dates for occurrences.</returns>
        private IEnumerable<DateTime> GetMonthlyRecurrenceOccurrences(IRecurrence recurrence)
        {
            var returnValue = new List<DateTime>();
            DateTime date = recurrence.StartDate.Date;
            bool keepLooping = true;
            if (date.Day > recurrence.DayOfMonth)
            {
                date = date.AddMonths(recurrence.Interval).AddDays(-1 * (date.Day - 1));
            }
            do
            {
                if (GeneratedEnoughOccurrences(returnValue.Count, date, recurrence))
                {
                    keepLooping = false;
                }
                else
                {
                    if (date.Day < recurrence.DayOfMonth)
                        date = date.AddDays(((recurrence.DayOfMonth > DateTime.DaysInMonth(date.Year, date.Month)) ? DateTime.DaysInMonth(date.Year, date.Month) : recurrence.DayOfMonth) - date.Day);


                    returnValue.Add(date.Add(recurrence.StartDate.TimeOfDay));
                    date = date.AddMonths(recurrence.Interval);
                }
            }
            while (keepLooping);

            return returnValue;
        }


        /// <summary>
        /// Gets the month NTH recurrence occurrences.
        /// </summary>
        /// <param name="recurrence">The recurrence pattern.</param>
        /// <returns>The dates for occurrences.</returns>
        private IEnumerable<DateTime> GetMonthNthRecurrenceOccurrences(IRecurrence recurrence)
        {
            var returnValue = new List<DateTime>();
            var date = GetMonthNthDate(recurrence, new DateTime(recurrence.StartDate.Year, recurrence.StartDate.Month, 1));
            if (date < recurrence.StartDate.Date)
            {
                date = GetMonthNthDate(recurrence,
                    new DateTime(recurrence.StartDate.Year, recurrence.StartDate.Month, 1).AddMonths(recurrence.Interval));
            }
            bool keepLooping = true;

            do
            {

                if (GeneratedEnoughOccurrences(returnValue.Count, date, recurrence))
                {
                    keepLooping = false;
                }
                else
                {
                    returnValue.Add(date.Add(recurrence.StartDate.TimeOfDay));
                    date = GetMonthNthDate(recurrence, new DateTime(date.Year, date.Month, 1).AddMonths(recurrence.Interval));
                }
            }
            while (keepLooping);

            return returnValue;
        }


        /// <summary>
        /// Gets the yearly recurrence occurrences.
        /// </summary>
        /// <param name="recurrence">The recurrence pattern.</param>
        /// <returns>The dates for occurrences.</returns>
        private IEnumerable<DateTime> GetYearlyRecurrenceOccurrences(IRecurrence recurrence)
        {
            var returnValue = new List<DateTime>();
            var lastDayOfMonth = DateTime.DaysInMonth(recurrence.StartDate.Year, recurrence.MonthOfYear);
            var date = new DateTime(recurrence.StartDate.Year, recurrence.MonthOfYear,
                lastDayOfMonth > recurrence.DayOfMonth ? recurrence.DayOfMonth : lastDayOfMonth);
            if (date < recurrence.StartDate)
            {
                lastDayOfMonth = DateTime.DaysInMonth(recurrence.StartDate.Year + recurrence.Interval, recurrence.MonthOfYear);
                date = new DateTime(recurrence.StartDate.Year + recurrence.Interval, recurrence.MonthOfYear,
                    lastDayOfMonth > recurrence.DayOfMonth ? recurrence.DayOfMonth : lastDayOfMonth);
            }
            bool keepLooping = true;


            do
            {
                if (GeneratedEnoughOccurrences(returnValue.Count, date, recurrence))
                {
                    keepLooping = false;
                }
                else
                {
                    returnValue.Add(date.Add(recurrence.StartDate.TimeOfDay));
                    lastDayOfMonth = DateTime.DaysInMonth(date.Year + recurrence.Interval, recurrence.MonthOfYear);
                    date = new DateTime(date.Year + recurrence.Interval, recurrence.MonthOfYear,
                        lastDayOfMonth > recurrence.DayOfMonth ? recurrence.DayOfMonth : lastDayOfMonth);
                }
            }
            while (keepLooping);

            return returnValue;
        }



        /// <summary>
        /// Gets the year NTH recurrence occurrences.
        /// </summary>
        /// <param name="recurrence">The recurrence pattern.</param>
        /// <returns>The dates for occurrences.</returns>
        private IEnumerable<DateTime> GetYearNthRecurrenceOccurrences(IRecurrence recurrence)
        {
            var returnValue = new List<DateTime>();
            var date = GetMonthNthDate(recurrence, new DateTime(recurrence.StartDate.Year, recurrence.MonthOfYear, 1));
            if (date < recurrence.StartDate.Date)
            {
                date = GetMonthNthDate(recurrence, new DateTime(recurrence.StartDate.Year + recurrence.Interval, recurrence.MonthOfYear, 1));
            }
            bool keepLooping = true;

            do
            {

                if (GeneratedEnoughOccurrences(returnValue.Count, date, recurrence))
                {
                    keepLooping = false;
                }
                else
                {
                    returnValue.Add(date.Add(recurrence.StartDate.TimeOfDay));
                    date = GetMonthNthDate(recurrence, new DateTime(date.Year + recurrence.Interval, recurrence.MonthOfYear, 1));
                }
            }
            while (keepLooping);

            return returnValue;
        }

        #region Helper Methods



        /// <summary>
        /// Determines whether [is at least one day checked] [the specified recurrence].
        /// </summary>
        /// <param name="recurrence">The recurrence pattern.</param>
        /// <returns><c>true</c> if [is at least one day checked] [the specified recurrence]; otherwise, <c>false</c>.</returns>
        private bool IsAtLeastOneDayChecked(IRecurrence recurrence)
        {
            return recurrence.Sunday ||
                   recurrence.Monday ||
                   recurrence.Tuesday ||
                   recurrence.Wednesday ||
                   recurrence.Thursday ||
                   recurrence.Friday ||
                   recurrence.Saturday;
        }

        /// <summary>
        /// Determines whether [is weekday set] [the specified recurrence].
        /// </summary>
        /// <param name="recurrence">The recurrence pattern.</param>
        /// <returns><c>true</c> if [is weekday set] [the specified recurrence]; otherwise, <c>false</c>.</returns>
        private bool IsWeekdaySet(IRecurrence recurrence)
        {
            return !recurrence.Sunday &&
                   recurrence.Monday &&
                   recurrence.Tuesday &&
                   recurrence.Wednesday &&
                   recurrence.Thursday &&
                   recurrence.Friday &&
                   !recurrence.Saturday;
        }

        /// <summary>
        /// Determines whether [is weekend set] [the specified recurrence].
        /// </summary>
        /// <param name="recurrence">The recurrence pattern.</param>
        /// <returns><c>true</c> if [is weekend set] [the specified recurrence]; otherwise, <c>false</c>.</returns>
        private bool IsWeekendSet(IRecurrence recurrence)
        {
            return recurrence.Sunday &&
                   !recurrence.Monday &&
                   !recurrence.Tuesday &&
                   !recurrence.Wednesday &&
                   !recurrence.Thursday &&
                   !recurrence.Friday &&
                   recurrence.Saturday;
        }


        /// <summary>
        /// Determines whether [is date matching recurrence day of week] [the specified recurrence].
        /// </summary>
        /// <param name="recurrence">The recurrence pattern.</param>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if [is date matching recurrence day of week] [the specified recurrence]; otherwise, <c>false</c>.</returns>
        private bool IsDateMatchingRecurrenceDayOfWeek(IRecurrence recurrence, DateTime date)
        {
            return
                (IsWeekend(date) && IsWeekendSet(recurrence)) ||
                (!IsWeekend(date) && IsWeekdaySet(recurrence)) ||
                (!IsWeekdaySet(recurrence) && !IsWeekendSet(recurrence) && IsDayOfTheWeekMatched(date, recurrence));

        }

        /// <summary>
        /// Generateds the enough occurrences.
        /// </summary>
        /// <param name="currentCount">The current count.</param>
        /// <param name="currentDate">The current date.</param>
        /// <param name="recurrence">The recurrence pattern.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool GeneratedEnoughOccurrences(int currentCount, DateTime currentDate, IRecurrence recurrence)
        {
            return
                (!recurrence.EndDate.HasValue && currentCount >= recurrence.Occurrences) ||
                (recurrence.EndDate.HasValue && currentDate.Date > recurrence.EndDate.Value.Date);

        }

        /// <summary>
        /// Determines whether [is day of the week matched] [the specified date].
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="recurrence">The recurrence pattern.</param>
        /// <returns><c>true</c> if [is day of the week matched] [the specified date]; otherwise, <c>false</c>.</returns>
        private bool IsDayOfTheWeekMatched(DateTime date, IRecurrence recurrence)
        {
            return
                (date.DayOfWeek == DayOfWeek.Sunday && recurrence.Sunday) ||
                (date.DayOfWeek == DayOfWeek.Monday && recurrence.Monday) ||
                (date.DayOfWeek == DayOfWeek.Tuesday && recurrence.Tuesday) ||
                (date.DayOfWeek == DayOfWeek.Wednesday && recurrence.Wednesday) ||
                (date.DayOfWeek == DayOfWeek.Thursday && recurrence.Thursday) ||
                (date.DayOfWeek == DayOfWeek.Friday && recurrence.Friday) ||
                (date.DayOfWeek == DayOfWeek.Saturday && recurrence.Saturday);
        }

        /// <summary>
        /// Determines whether the specified date is weekend.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if the specified date is weekend; otherwise, <c>false</c>.</returns>
        private bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday;
        }


        /// <summary>
        /// Gets the month NTH date.
        /// </summary>
        /// <param name="recurrence">The recurrence pattern.</param>
        /// <param name="startDate">The start date.</param>
        /// <returns>DateTime.</returns>
        private DateTime GetMonthNthDate(IRecurrence recurrence, DateTime startDate)
        {
            var date = new DateTime(startDate.Year, startDate.Month, 1);
            var instance = 1;
            if (recurrence.Instance > 4)
            {
                //last 
                for (int day = DateTime.DaysInMonth(date.Year, date.Month); day >= 1; day--)
                {
                    date = new DateTime(date.Year, date.Month, day);
                    if (IsDateMatchingRecurrenceDayOfWeek(recurrence, date))
                    {
                        break;
                    }
                }

            }
            else
            {
                //specific
                for (int day = 1; day <= DateTime.DaysInMonth(date.Year, date.Month); day++)
                {
                    date = new DateTime(date.Year, date.Month, day);
                    if (IsDateMatchingRecurrenceDayOfWeek(recurrence, date))
                    {
                        if (instance == recurrence.Instance)
                        {
                            break;
                        }
                        instance++;
                    }
                }
            }


            return date;

        }



        #endregion

        /// <summary>
        /// Validates The recurrence pattern.
        /// </summary>
        /// <param name="recurrence">The recurrence pattern.</param>
        /// <returns>System.String.</returns>
        public string ValidateRecurrence(IRecurrence recurrence)
        {
            if (recurrence.Occurrences < 1 && recurrence.EndDate == null)
            {
                return "Number of occurrences or end date is required.";
            }
            if (recurrence.Occurrences > 0 && recurrence.EndDate.HasValue)
            {
                return "Cannot set both number of occurrences and end date.";
            }
            if (recurrence.EndDate.HasValue && recurrence.StartDate.Date > recurrence.EndDate.Value.Date)
            {
                return "Start date must be before end date.";
            }

            if (recurrence.RecurrenceType == RecurrenceType.Daily)
            {
                if (recurrence.Interval == 0 && !IsAtLeastOneDayChecked(recurrence))
                {
                    return "Daily recurrence requires a day to occur on";
                }
            }
            else if (recurrence.RecurrenceType == RecurrenceType.Weekly)
            {
                if (recurrence.Interval < 1 || !IsAtLeastOneDayChecked(recurrence))
                {
                    return "Weekly recurrence required an interval and day to occur on.";
                }
            }
            else if (recurrence.RecurrenceType == RecurrenceType.Monthly)
            {
                if (recurrence.Interval < 1 || recurrence.DayOfMonth < 1)
                {
                    return "Monthly recurrence requires an interval and day of the month.";
                }
            }
            else if (recurrence.RecurrenceType == RecurrenceType.MonthNth)
            {
                if (recurrence.Interval < 1 || recurrence.Instance < 1 || recurrence.Instance > 5 || !IsAtLeastOneDayChecked(recurrence))
                {
                    return "Monthly recurrence required an interval, instance and day of the week.";
                }
            }
            else if (recurrence.RecurrenceType == RecurrenceType.Yearly)
            {
                if (recurrence.Interval < 1 || recurrence.DayOfMonth < 1 || recurrence.MonthOfYear < 1 || recurrence.MonthOfYear > 12)
                {
                    return "Yearly recurrence required an interval, day of the month and month of the year.";
                }
            }
            else if (recurrence.RecurrenceType == RecurrenceType.YearNth)
            {
                if (recurrence.Interval < 0 || recurrence.Instance < 1 || recurrence.MonthOfYear < 1 ||
                    !IsAtLeastOneDayChecked(recurrence))
                {
                    return "Yearly recurrence required an interval, instance, day of the week and month of the year.";
                }
            }
            return string.Empty;
        }
    }
}
