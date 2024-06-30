namespace API.Errors
{
    public class ApiException : Exception
    {
        public ApiException(int statusCode, string message = null, Exception exception = null) : base(message, exception)
        {
            StatusCode = statusCode;
            Details = exception.StackTrace;
        }

        public int StatusCode { get; set; }

        public string Details { get; set; }
    }
}
