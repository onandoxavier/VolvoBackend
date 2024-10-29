namespace Volvo.API.Utils.Exceptions
{
    public class EntityValidationException : Exception
    {
        public int ErrorCode { get; }

        public EntityValidationException(string message) : base(message) { }
        public EntityValidationException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
        public EntityValidationException(string message, int errorCode, Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
