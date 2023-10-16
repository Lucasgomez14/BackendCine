namespace Application.Exceptions
{
    public class Conflict : Exception
    {
        public Conflict() : base()
        {
        }
        public Conflict(string message) : base(message)
        {
        }
        public Conflict(string message, Exception ex) : base(message)
        {
        }
    }
}
