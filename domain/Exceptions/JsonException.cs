using System.Collections.Generic;

namespace domain.Exceptions
{
    public class JsonException
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public List<ExceptionInfo> Info { get; set; }
        public string Stacktrace { get; set; }
    }
}
