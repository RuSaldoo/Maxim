using Newtonsoft.Json;

namespace Task_API.Models
{
    public class AppSetingsOption
    {
        public class AppSettings
        {
            public LoggingSettings Logging { get; set; }
            public string AllowedHosts { get; set; }
            public string Random_api { get; set; }
            public List<string> BlackList { get; set; }
        }

        public class LoggingSettings
        {
            public LogLevelSettings LogLevel { get; set; }
        }

        public class LogLevelSettings
        {
            public string Default { get; set; }
            public string Microsoft_AspNetCore { get; set; }
        }

    }
}
