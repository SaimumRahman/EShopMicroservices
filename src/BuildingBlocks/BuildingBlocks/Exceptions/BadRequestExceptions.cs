namespace BuildingBlocks.Exceptions
{
    public class BadRequestExceptions: Exception
    {
        public BadRequestExceptions(string message):base(message)
        { 
        }
        public BadRequestExceptions(string message,string details):base(message)
        {
                Details = details;
        }
        public string Details { get; }
    }
}
