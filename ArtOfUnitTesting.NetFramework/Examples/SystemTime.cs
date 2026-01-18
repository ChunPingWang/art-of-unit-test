using System;

public static class SystemTime
{
    private static DateTime _date;

    public static void Set(DateTime custom)
    {
        _date = custom;
    }

    public static void Reset()
    {
        _date = DateTime.MinValue;
    }

    public static DateTime Now
    {
        get
        {
            if (_date != DateTime.MinValue)
            {
                return _date;
            }
            return DateTime.Now;
        }
    }
}

public static class TimeLogger
{
    public static string CreateMessage(string message)
    {
        return $"{SystemTime.Now}: {message}";
    }
}
