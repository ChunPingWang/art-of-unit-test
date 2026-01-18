namespace Chapter5.LogAn;

public class LogAnalyzer
{
    private readonly ILogger _logger;

    public LogAnalyzer(ILogger logger)
    {
        _logger = logger;
    }

    public int MinNameLength { get; set; }

    public void Analyze(string filename)
    {
        if (filename.Length < MinNameLength)
        {
            _logger.LogError($"Filename too short: {filename}");
        }
    }
}

public class LogAnalyzer2
{
    private readonly ILogger _logger;
    private readonly IWebService _webService;

    public LogAnalyzer2(ILogger logger, IWebService webService)
    {
        _logger = logger;
        _webService = webService;
    }

    public int MinNameLength { get; set; }

    public void Analyze(string filename)
    {
        if (filename.Length < MinNameLength)
        {
            try
            {
                _logger.LogError($"Filename too short: {filename}");
            }
            catch (Exception e)
            {
                _webService.Write("Error From Logger: " + e);
            }
        }
    }
}

public class LogAnalyzer3
{
    private readonly ILogger _logger;
    private readonly IWebService _webService;

    public LogAnalyzer3(ILogger logger, IWebService webService)
    {
        _logger = logger;
        _webService = webService;
    }

    public int MinNameLength { get; set; }

    public void Analyze(string filename)
    {
        if (filename.Length < MinNameLength)
        {
            try
            {
                _logger.LogError($"Filename too short: {filename}");
            }
            catch (Exception e)
            {
                _webService.Write(new ErrorInfo(1000, e.Message));
            }
        }
    }
}

public class ErrorInfo : IEquatable<ErrorInfo>
{
    public int Severity { get; }
    public string Message { get; }

    public ErrorInfo(int severity, string message)
    {
        Severity = severity;
        Message = message;
    }

    public bool Equals(ErrorInfo? other)
    {
        if (other is null) return false;
        return Severity == other.Severity && Message == other.Message;
    }

    public override bool Equals(object? obj) => Equals(obj as ErrorInfo);

    public override int GetHashCode() => HashCode.Combine(Severity, Message);
}

public interface IWebService
{
    void Write(string message);
    void Write(ErrorInfo message);
}
