namespace FlashCard.Host.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) 
        {
        }

        public NotFoundException(string name, object key) : base($"Entity |({name}) - ({key})| was not found.") 
        { 
        }
    }

    public class WordNotFoundException : NotFoundException
    {
        public WordNotFoundException(int Id) : base("Word", Id)
        {
        }

        public WordNotFoundException(string Name) : base("Word", Name) 
        {
        }
    }
}
