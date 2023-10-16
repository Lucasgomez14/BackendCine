namespace Application.Exceptions
{
    public class ExceptionBadRequest : Exception
    {
        public ExceptionBadRequest() : base()
        {
        }
        public ExceptionBadRequest(string message) : base(message)
        {
        }
        public ExceptionBadRequest(string message, Exception ex) : base(message)
        {
        }
    }
}
