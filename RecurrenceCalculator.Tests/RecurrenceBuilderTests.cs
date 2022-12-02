using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace RecurrenceCalculator.Tests
{
    [TestClass]
    public class RecurrenceBuilderTests
    {
        private readonly DateTime _startDate = new DateTime(2014, 1, 31, 16, 0, 0);

        [TestMethod]
        public void Should_Build_Recurrence()
        {
            var builder = new RecurrenceBuilder<Recurrence>();
            var final = builder
                .Occurrences(1)
                .RecurrenceType(RecurrenceType.Daily)
                .Saturday()
                .Sunday()
                .Monday()
                .Tuesday()
                .Wednesday()
                .Thursday()
                .Friday()
                .Interval(2)
                .DayOfMonth(3)
                .MonthOfYear(4)
                .Instance(5)
                .StartDate(DateTime.Today)
                .EndDate(DateTime.Today.AddYears(1))
                .Build();

            Assert.IsTrue(final.Sunday, "Should set Sunday");
            Assert.IsTrue(final.Monday, "Should set Monday");
            Assert.IsTrue(final.Tuesday, "Should set Tuesday");
            Assert.IsTrue(final.Wednesday, "Should set Wednesday");
            Assert.IsTrue(final.Thursday, "Should set Thursday");
            Assert.IsTrue(final.Friday, "Should set Friday");
            Assert.IsTrue(final.Saturday, "Should set Saturday");
            Assert.AreEqual(RecurrenceType.Daily, final.RecurrenceType, "Should set RecurrenceType");
            Assert.AreEqual(1, final.Occurrences, "Should set Occurrences");
            Assert.AreEqual(3, final.DayOfMonth, "Should set DayOfMonth");
            Assert.AreEqual(4, final.MonthOfYear, "Should set MonthOfYear");
            Assert.AreEqual(5, final.Instance, "Should set Instance");
            Assert.AreEqual(DateTime.Today, final.StartDate, "Should set StartDate");
            Assert.AreEqual(DateTime.Today.AddYears(1), final.EndDate, "Should set EndDate");
            Assert.AreEqual(2, final.Interval, "Should set Interval");
        }

        [TestMethod]
        public void Should_Generate_Daily_Recurrences_With_End_Date()
        {
            var builder = new RecurrenceBuilder<Recurrence>();
            var recurrence = builder
                .Occurrences(0)
                .RecurrenceType(RecurrenceType.Daily)
                .Saturday()
                .Sunday()
                .Monday()
                .Tuesday()
                .Wednesday()
                .Thursday()
                .Friday()
                .Interval(2)
                .StartDate(_startDate)
                .EndDate(new DateTime(2014, 2, 19))
                .Build();
            var occurrences = new Calculator().CalculateOccurrences(recurrence).ToList();
            Assert.AreEqual(10, occurrences.Count, "Should create 10 occurrences");
            for (int i = 0; i < occurrences.Count - 1; i++)
            {
                Assert.AreEqual(_startDate.AddDays(i * recurrence.Interval), occurrences[i], "Should have correct date");
            }
        }
    }
}
