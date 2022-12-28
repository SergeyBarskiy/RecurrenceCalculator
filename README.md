Recurrence Calculator
====================
Library written for .NET that perform Outlook style recurrence calculations.
The key to usage is the `IRecurrence` interface that allows you to specify the recurrence pattern.

I have used for the most part the interface that Outlook supports.  You can find the details on MSDN site: http://msdn.microsoft.com/en-us/library/microsoft.office.interop.outlook.recurrencepattern(v=office.15).aspx
I made one change - I changed the DayOfWeekMask from flags based enumeration to just 7 flags - one for each day of the week.  This will allow you to easily expose the same class at the user interface to allow the user to set flags for the days of the week.  In order to support things like day, week day and weekend, you just set appropriate days flags. For example, set all the flags for the "day", Sunday and Saturday for the "weekend".  I also decided not to support "no end date", so date is required or number of occurrences.

It is very easy to use.  Implement `IRecurrence` in any of your class, create an instance of the calculator, and call `Calculate` method.  An exception will be thrown if your pattern is invalid.  You can also call `Validate` manually.  If you get an empty string, you are valid.  Otherwise you will get the message telling you what is wrong with your pattern.

The project includes tests that will tell you how to use the calculator.
There is now support for default recurrence class and recurrence fluent API builder

```csharp
private Calculator calendarUtility;
private readonly DateTime startDate = new DateTime(2014, 1, 31, 16, 0, 0);

[TestInitialize]
public void Setup()
{
    calendarUtility = new Calculator();
}

private AppointmentRecurrence CreateWeeklyRecurrence()
{
    return new AppointmentRecurrence
    {
        RecurrenceType = RecurrenceType.Weekly,
        Interval = 2,
        Sunday = false,
        Monday = false,
        Tuesday = true,
        Wednesday = false,
        Thursday = true,
        Friday = false,
        Saturday = false,
        StartDate = startDate,
        Occurrences = 5
    };
}

[TestMethod]
public void Should_Generate_Weekly_Recurrences_Without_End_Date()
{
    var recurrence = CreateWeeklyRecurrence();
    var occurrences = calendarUtility.CalculateOccurrences(recurrence).ToList();
    Assert.AreEqual(5, occurrences.Count, "Should create 5 occurrences");
    Assert.AreEqual(new DateTime(2014, 2, 11).Add(startDate.TimeOfDay), occurrences[0], "Date 1 should be correct");
    Assert.AreEqual(new DateTime(2014, 2, 13).Add(startDate.TimeOfDay), occurrences[1], "Date 2 should be correct");
    Assert.AreEqual(new DateTime(2014, 2, 25).Add(startDate.TimeOfDay), occurrences[2], "Date 3 should be correct");
    Assert.AreEqual(new DateTime(2014, 2, 27).Add(startDate.TimeOfDay), occurrences[3], "Date 4 should be correct");
    Assert.AreEqual(new DateTime(2014, 3, 11).Add(startDate.TimeOfDay), occurrences[4], "Date 5 should be correct");
}
```

You can also use NuGet to install the package: https://www.nuget.org/packages/RecurrenceCalculator/
Just type Install-Package RecurrenceCalculator in package manager console window.
