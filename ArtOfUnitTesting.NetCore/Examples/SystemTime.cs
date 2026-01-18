namespace Examples;

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

    public static DateTime Now => _date != DateTime.MinValue ? _date : DateTime.Now;
}

public static class TimeLogger
{
    public static string CreateMessage(string message) => $"{SystemTime.Now}: {message}";
}
