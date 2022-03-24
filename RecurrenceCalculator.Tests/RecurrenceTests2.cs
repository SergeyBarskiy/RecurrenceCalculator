using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecurrenceCalculator.Tests
{

    [TestClass]
    public class RecurrenceTests2
    {
        private Calculator _calendarUtility;
        private readonly DateTime _startDate = new DateTime(2014, 1, 31, 16, 0, 0);

        [TestInitialize]
        public void Setup()
        {
            _calendarUtility = new Calculator();
        }

        [TestMethod]
        public void Should_Generate_Daily_Recurrences_Without_End_Date()
        {
            var recurrence = CreateDailyRecurrence();
            var occurrences = _calendarUtility.CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(10, occurrences.Count, "Should create 10 occurrences");
            for (int i = 0; i < occurrences.Count - 1; i++)
            {
                Assert.AreEqual(_startDate.AddDays(i * recurrence.Interval), occurrences[i], "Should have correct date");
            }
        }

        [TestMethod]
        public void Should_Generate_Daily_Recurrences_With_End_Date()
        {
            var recurrence = CreateDailyRecurrence();
            recurrence.Occurrences = 0;
            recurrence.EndDate = new DateTime(2014, 2, 19);
            var occurrences = _calendarUtility.CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(10, occurrences.Count, "Should create 10 occurrences");
            for (int i = 0; i < occurrences.Count - 1; i++)
            {
                Assert.AreEqual(_startDate.AddDays(i * recurrence.Interval), occurrences[i], "Should have correct date");
            }
        }

        [TestMethod]
        public void Should_Generate_Daily_Weekday_Recurrences_Without_End_Date()
        {
            var recurrence = CreateDailyWeekdayRecurrence();
            var occurrences = _calendarUtility.CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(3, occurrences.Count, "Should create 10 occurrences");
            Assert.AreEqual(new DateTime(2014, 1, 31).Add(_startDate.TimeOfDay), occurrences[0], "First date should be correct");
            Assert.AreEqual(new DateTime(2014, 2, 3).Add(_startDate.TimeOfDay), occurrences[1], "Second date should be correct");
            Assert.AreEqual(new DateTime(2014, 2, 4).Add(_startDate.TimeOfDay), occurrences[2], "Third date should be correct");
        }

        [TestMethod]
        public void Should_Generate_Daily_Weekday_Recurrences_With_End_Date()
        {
            var recurrence = CreateDailyWeekdayRecurrence();
            recurrence.Occurrences = 0;
            recurrence.EndDate = new DateTime(2014, 2, 10);
            var occurrences = _calendarUtility.CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(7, occurrences.Count, "Should create 7 occurrences");
            Assert.AreEqual(new DateTime(2014, 1, 31).Add(_startDate.TimeOfDay), occurrences[0], "Date 1 should be correct");
            Assert.AreEqual(new DateTime(2014, 2, 3).Add(_startDate.TimeOfDay), occurrences[1], "Date 2 should be correct");
            Assert.AreEqual(new DateTime(2014, 2, 4).Add(_startDate.TimeOfDay), occurrences[2], "Date 3 should be correct");
            Assert.AreEqual(new DateTime(2014, 2, 5).Add(_startDate.TimeOfDay), occurrences[3], "Date 4 should be correct");
            Assert.AreEqual(new DateTime(2014, 2, 6).Add(_startDate.TimeOfDay), occurrences[4], "Date 5 should be correct");
            Assert.AreEqual(new DateTime(2014, 2, 7).Add(_startDate.TimeOfDay), occurrences[5], "Date 6 should be correct");
            Assert.AreEqual(new DateTime(2014, 2, 10).Add(_startDate.TimeOfDay), occurrences[6], "Date 7 should be correct");
        }

        [TestMethod]
        public void Should_Generate_Weekly_Recurrences_Without_End_Date()
        {
            var recurrence = CreateWeeklyRecurrence();
            var occurrences = _calendarUtility.CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(5, occurrences.Count, "Should create 5 occurrences");
            Assert.AreEqual(new DateTime(2014, 2, 11).Add(_startDate.TimeOfDay), occurrences[0], "Date 1 should be correct");
            Assert.AreEqual(new DateTime(2014, 2, 13).Add(_startDate.TimeOfDay), occurrences[1], "Date 2 should be correct");
            Assert.AreEqual(new DateTime(2014, 2, 25).Add(_startDate.TimeOfDay), occurrences[2], "Date 3 should be correct");
            Assert.AreEqual(new DateTime(2014, 2, 27).Add(_startDate.TimeOfDay), occurrences[3], "Date 4 should be correct");
            Assert.AreEqual(new DateTime(2014, 3, 11).Add(_startDate.TimeOfDay), occurrences[4], "Date 5 should be correct");
        }

        [TestMethod]
        public void Should_Generate_Weekly_Recurrences_With_End_Date()
        {
            var recurrence = CreateWeeklyRecurrence();
            recurrence.Occurrences = 0;
            recurrence.EndDate = new DateTime(2014, 3, 11);
            var occurrences = _calendarUtility.CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(5, occurrences.Count, "Should create 5 occurrences");
            Assert.AreEqual(new DateTime(2014, 2, 11).Add(_startDate.TimeOfDay), occurrences[0], "Date 1 should be correct");
            Assert.AreEqual(new DateTime(2014, 2, 13).Add(_startDate.TimeOfDay), occurrences[1], "Date 2 should be correct");
            Assert.AreEqual(new DateTime(2014, 2, 25).Add(_startDate.TimeOfDay), occurrences[2], "Date 3 should be correct");
            Assert.AreEqual(new DateTime(2014, 2, 27).Add(_startDate.TimeOfDay), occurrences[3], "Date 4 should be correct");
            Assert.AreEqual(new DateTime(2014, 3, 11).Add(_startDate.TimeOfDay), occurrences[4], "Date 5 should be correct");
        }


        [TestMethod]
        public void Should_Generate_Monthly_Recurrences_Without_End_Date()
        {
            var recurrence = CreateMonthlyRecurrence();
            var occurrences = _calendarUtility.CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(3, occurrences.Count, "Should create 3 occurrences");
            Assert.AreEqual(new DateTime(2014, 1, 31).Add(_startDate.TimeOfDay), occurrences[0], "Date 1 should be correct");
            Assert.AreEqual(new DateTime(2014, 4, 30).Add(_startDate.TimeOfDay), occurrences[1], "Date 2 should be correct");
            Assert.AreEqual(new DateTime(2014, 7, 31).Add(_startDate.TimeOfDay), occurrences[2], "Date 3 should be correct");
        }

        [TestMethod]
        public void Should_Generate_Monthly_Recurrences_With_End_Date()
        {
            var recurrence = CreateMonthlyRecurrence();
            recurrence.Occurrences = 0;
            recurrence.EndDate = new DateTime(2014, 11, 11);
            var occurrences = _calendarUtility.CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(4, occurrences.Count, "Should create 4 occurrences");
            Assert.AreEqual(new DateTime(2014, 1, 31).Add(_startDate.TimeOfDay), occurrences[0], "Date 1 should be correct");
            Assert.AreEqual(new DateTime(2014, 4, 30).Add(_startDate.TimeOfDay), occurrences[1], "Date 2 should be correct");
            Assert.AreEqual(new DateTime(2014, 7, 31).Add(_startDate.TimeOfDay), occurrences[2], "Date 3 should be correct");
            Assert.AreEqual(new DateTime(2014, 10, 31).Add(_startDate.TimeOfDay), occurrences[3], "Date 4 should be correct");
        }

        [TestMethod]
        public void Should_Generate_MonthNth_Recurrences_Without_End_Date()
        {
            var recurrence = CreateMonthNthRecurrence();
            recurrence.Instance = 3;
            var occurrences = _calendarUtility.CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(3, occurrences.Count, "Should create 3 occurrences");
            Assert.AreEqual(new DateTime(2014, 3, 18).Add(_startDate.TimeOfDay), occurrences[0], "Date 1 should be correct");
            Assert.AreEqual(new DateTime(2014, 5, 20).Add(_startDate.TimeOfDay), occurrences[1], "Date 2 should be correct");
            Assert.AreEqual(new DateTime(2014, 7, 15).Add(_startDate.TimeOfDay), occurrences[2], "Date 3 should be correct");
        }

        [TestMethod]
        public void Should_Generate_MonthNth_Recurrences_Last_Instance_Without_End_Date()
        {
            var recurrence = CreateMonthNthRecurrence();
            recurrence.Instance = 5;
            var occurrences = _calendarUtility.CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(3, occurrences.Count, "Should create 3 occurrences");
            Assert.AreEqual(new DateTime(2014, 3, 25).Add(_startDate.TimeOfDay), occurrences[0], "Date 1 should be correct");
            Assert.AreEqual(new DateTime(2014, 5, 27).Add(_startDate.TimeOfDay), occurrences[1], "Date 2 should be correct");
            Assert.AreEqual(new DateTime(2014, 7, 29).Add(_startDate.TimeOfDay), occurrences[2], "Date 3 should be correct");
        }

        [TestMethod]
        public void Should_Generate_MonthNth_Recurrences_Last_Weekend_Without_End_Date()
        {
            var recurrence = CreateMonthNthRecurrence();
            recurrence.Tuesday = false;
            recurrence.Sunday = true;
            recurrence.Saturday = true;
            recurrence.Instance = 5;
            var occurrences = _calendarUtility.CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(3, occurrences.Count, "Should create 3 occurrences");
            Assert.AreEqual(new DateTime(2014, 3, 30).Add(_startDate.TimeOfDay), occurrences[0], "Date 1 should be correct");
            Assert.AreEqual(new DateTime(2014, 5, 31).Add(_startDate.TimeOfDay), occurrences[1], "Date 2 should be correct");
            Assert.AreEqual(new DateTime(2014, 7, 27).Add(_startDate.TimeOfDay), occurrences[2], "Date 3 should be correct");
        }

        [TestMethod]
        public void Should_Generate_MonthNth_Recurrences_Last_Weekday_Without_End_Date()
        {
            var recurrence = CreateMonthNthRecurrence();
            recurrence.Monday = true;
            recurrence.Wednesday = true;
            recurrence.Thursday = true;
            recurrence.Friday = true;
            recurrence.Instance = 5;
            var occurrences = _calendarUtility.CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(3, occurrences.Count, "Should create 3 occurrences");
            Assert.AreEqual(new DateTime(2014, 1, 31).Add(_startDate.TimeOfDay), occurrences[0], "Date 1 should be correct");
            Assert.AreEqual(new DateTime(2014, 3, 31).Add(_startDate.TimeOfDay), occurrences[1], "Date 2 should be correct");
            Assert.AreEqual(new DateTime(2014, 5, 30).Add(_startDate.TimeOfDay), occurrences[2], "Date 3 should be correct");
        }

        [TestMethod]
        public void Should_Generate_Yearly_Recurrences_With_End_Date()
        {
            var recurrence = CreateYearlyRecurrence();
            recurrence.Occurrences = 0;
            recurrence.EndDate = new DateTime(2020, 11, 11);
            var occurrences = _calendarUtility.CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(3, occurrences.Count, "Should create 3 occurrences");
            Assert.AreEqual(new DateTime(2014, 2, 28).Add(_startDate.TimeOfDay), occurrences[0], "Date 1 should be correct");
            Assert.AreEqual(new DateTime(2017, 2, 28).Add(_startDate.TimeOfDay), occurrences[1], "Date 2 should be correct");
            Assert.AreEqual(new DateTime(2020, 2, 29).Add(_startDate.TimeOfDay), occurrences[2], "Date 3 should be correct");
        }

        [TestMethod]
        public void Should_Generate_Yearly_Recurrences_With_End_Date_Same_Start_Date()
        {
            var recurrence = new RecurrenceBuilder().RecurrenceType(RecurrenceType.Yearly)
                .Interval(1)
                .DayOfMonth(31)
                .MonthOfYear(12)
                .Sunday()
                .Monday()
                .Tuesday()
                .Wednesday()
                .Thursday()
                .Friday()
                .Saturday()
                .StartDate(new DateTime(2019, 12, 31, 16, 0, 0))
                .Occurrences(3)
                .Build();

            var occurrences = _calendarUtility.CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(3, occurrences.Count, "Should create 3 occurrences");
            Assert.AreEqual(new DateTime(2019, 12, 31, 16, 0, 0), occurrences[0], "Date 1 should be correct");
            Assert.AreEqual(new DateTime(2020, 12, 31, 16, 0, 0), occurrences[1], "Date 2 should be correct");
            Assert.AreEqual(new DateTime(2021, 12, 31, 16, 0, 0), occurrences[2], "Date 3 should be correct");
        }

        [TestMethod]
        public void Should_Generate_Yearly_Recurrences_Without_End_Date()
        {
            var recurrence = CreateYearlyRecurrence();
            recurrence.Occurrences = 3;
            var occurrences = _calendarUtility.CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(3, occurrences.Count, "Should create 3 occurrences");
            Assert.AreEqual(new DateTime(2014, 2, 28).Add(_startDate.TimeOfDay), occurrences[0], "Date 1 should be correct");
            Assert.AreEqual(new DateTime(2017, 2, 28).Add(_startDate.TimeOfDay), occurrences[1], "Date 2 should be correct");
            Assert.AreEqual(new DateTime(2020, 2, 29).Add(_startDate.TimeOfDay), occurrences[2], "Date 3 should be correct");
        }

        [TestMethod]
        public void Should_Generate_YearNth_Recurrences_Without_End_Date()
        {
            var recurrence = CreateYearNthRecurrence();
            recurrence.Occurrences = 3;
            var occurrences = _calendarUtility.CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(3, occurrences.Count, "Should create 3 occurrences");
            Assert.AreEqual(new DateTime(2014, 2, 18).Add(_startDate.TimeOfDay), occurrences[0], "Date 1 should be correct");
            Assert.AreEqual(new DateTime(2017, 2, 21).Add(_startDate.TimeOfDay), occurrences[1], "Date 2 should be correct");
            Assert.AreEqual(new DateTime(2020, 2, 18).Add(_startDate.TimeOfDay), occurrences[2], "Date 3 should be correct");
        }
        private Recurrence CreateWeeklyRecurrence()
        {
            return new RecurrenceBuilder().RecurrenceType(RecurrenceType.Weekly)
                .Interval(2)
                .DayOfMonth(31)
                .Tuesday()
                .Thursday()
                .StartDate(_startDate)
                .Occurrences(5)
                .Build();
        }

        private Recurrence CreateMonthlyRecurrence()
        {
            return new RecurrenceBuilder().RecurrenceType(RecurrenceType.Monthly)
                .Interval(3)
                .DayOfMonth(31)
                .Tuesday()
                .StartDate(_startDate)
                .Occurrences(3)
                .Build();
        }



        private Recurrence CreateMonthNthRecurrence()
        {
            return new RecurrenceBuilder().RecurrenceType(RecurrenceType.MonthNth)
                .Interval(2)
                .Instance(3)
                .Tuesday()
                .StartDate(_startDate)
                .Occurrences(3)
                .Build();
        }

        private Recurrence CreateYearlyRecurrence()
        {
            return new RecurrenceBuilder().RecurrenceType(RecurrenceType.Yearly)
                .Interval(3)
                .DayOfMonth(31)
                .MonthOfYear(2)
                .Tuesday()
                .StartDate(_startDate)
                .Occurrences(3)
                .Build();
        }

        private Recurrence CreateYearNthRecurrence()
        {
            return new RecurrenceBuilder().RecurrenceType(RecurrenceType.YearNth)
                .Interval(3)
                .Instance(3)
                .MonthOfYear(2)
                .Tuesday()
                .StartDate(_startDate)
                .Occurrences(3)
                .Build();
        }


        private Recurrence CreateDailyWeekdayRecurrence()
        {
            var recurrence = CreateDailyRecurrence();
            recurrence.Sunday = false;
            recurrence.Saturday = false;
            recurrence.Occurrences = 3;
            return recurrence;
        }
        private Recurrence CreateDailyRecurrence()
        {
            return new RecurrenceBuilder().RecurrenceType(RecurrenceType.Daily)
                .Interval(2)
                .Sunday()
                .Monday()
                .Tuesday()
                .Wednesday()
                .Thursday()
                .Wednesday()
                .Thursday()
                .Friday()
                .Saturday()
                .StartDate(_startDate)
                .Occurrences(10)
                .Build();

        }
    }
}
