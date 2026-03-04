namespace Event_management_Project.Common.Exceptions;

public class ApiException : Exception
{
    public int StatusCode { get; }
    public string ErrorCode { get; }

    public ApiException(int statusCode, string message, string errorCode = "error")
        : base(message)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }
}
