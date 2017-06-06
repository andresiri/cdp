using System.Collections.Generic;

namespace domain.Entities.Exceptions
{
    public class ApiException
    {
        public string ErrorMsg { get; set; }
        public string Type { get; set; }
        public List<ExceptionInfo> Info { get; set; }
    }
}
