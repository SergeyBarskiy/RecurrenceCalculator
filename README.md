Recurrence Calculator
====================
Library written for .NET that perform Outlook style recurrence calculations.
The key to usage is the IRecurrence interface that allows you to specify the recurrence pattern.

I have used for the most part the interface that Outlook supports.  You can find the details on MSDN site: http://msdn.microsoft.com/en-us/library/microsoft.office.interop.outlook.recurrencepattern(v=office.15).aspx
I made one change - I changed the DayOfWeekMask from flags based enumeration to just 7 flags - one for each day of the week.  This will allow you to easily expose the same class at the user interface to allow the user to set flags for the days of the week.  In order to suport things like day, week day and weekend, you just set appropriate days flags. For example, set all the flags for the "day", Sunday and Saturday for the "weekend".  I also decided not to support "no end date", so date is required or number of occurrences.


