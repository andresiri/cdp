using System;
using domain.Entities.Exceptions;
namespace api
{
    public static class ExceptionHandler
    {
        public static JsonException FormatException(Exception e)
        {

            var jsonException = new JsonException()
            {
                Stacktrace = e.StackTrace,
                Message = e.Message
            };
            var type = e.GetType();

            if (type == typeof(CustomException))
            {

                jsonException.Info = ((CustomException)e).Info;
                jsonException.Type = ((CustomException)e).Type;
            }

            return jsonException;
        }
    }
}
