// https://twitter.com/okyrylchuk/status/1441749328943411202

// public DateOnly(int year, int month, int day)
// public DateOnly(int year, int month, int day, Calendar calendar)
DateOnly dateOnly = new(2021, 9, 25);
Console.WriteLine(dateOnly);
// Output: 25-Sep-21

// public TimeOnly(int hour, int minute)
// public TimeOnly(int hour, int minute, int second)
// public TimeOnly(int hour, int minute, int second, int millisecond)
// public TimeOnly(long ticks)
TimeOnly timeOnly = new(19, 0, 0);
Console.WriteLine(timeOnly);
// Output: 19:00 PM

DateOnly dateOnlyFromDate = DateOnly.FromDateTime(DateTime.Now);
Console.WriteLine(dateOnlyFromDate);
// Output: 23-Sep-21

TimeOnly timeOnlyFromDate = TimeOnly.FromDateTime(DateTime.Now);
Console.WriteLine(timeOnlyFromDate);
// Output: 21:03 PM

