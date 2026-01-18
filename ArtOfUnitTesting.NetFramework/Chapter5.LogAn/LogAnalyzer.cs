using System;

namespace Chapter5.LogAn
{
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
                _logger.LogError(string.Format("Filename too short: {0}", filename));
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
                    _logger.LogError(string.Format("Filename too short: {0}", filename));
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
                    _logger.LogError(string.Format("Filename too short: {0}", filename));
                }
                catch (Exception e)
                {
                    _webService.Write(new ErrorInfo(1000, e.Message));
                }
            }
        }
    }

    public class ErrorInfo
    {
        private readonly int _severity;
        private readonly string _message;

        public ErrorInfo(int severity, string message)
        {
            _severity = severity;
            _message = message;
        }

        public int Severity => _severity;

        public string Message => _message;

        protected bool Equals(ErrorInfo other)
        {
            return _severity == other._severity && string.Equals(_message, other._message);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ErrorInfo)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_severity * 397) ^ (_message?.GetHashCode() ?? 0);
            }
        }
    }

    public interface IWebService
    {
        void Write(string message);
        void Write(ErrorInfo message);
    }
}
