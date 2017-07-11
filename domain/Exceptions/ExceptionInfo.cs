namespace domain.Exceptions
{
    public class ExceptionInfo
    {
        public string Property { get; set; }
        public string ErrorType { get; set; }

        public ExceptionInfo(string property, string errorType) {

            Property = property;
            ErrorType = errorType;
        }
    }
}
