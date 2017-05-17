using System;
namespace domain.Entities.Exceptions
{
    public class CustomException : Exception
    {
        public string ErrorMsg { get; set; }
        public string Type { get; set; }

        public CustomException(string errorMsg, string type)
        {
            ErrorMsg = errorMsg;
            Type = type;
        }
    }
}
