using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace domain.Entities.Exceptions
{
    public class CustomException : Exception
    {
        public string ErrorMsg { get; set; }
        public string Type { get; set; }
        public List<ExceptionInfo> Info { get; set; }

        public CustomException(string errorMsg, string type)
        {
            ErrorMsg = errorMsg;
            Type = type;
        }

        public CustomException(string type, List<ExceptionInfo> info)
        {
            Type = type;
            Info = info;
        }

        public CustomException() 
        {
            
        }
    }
}
