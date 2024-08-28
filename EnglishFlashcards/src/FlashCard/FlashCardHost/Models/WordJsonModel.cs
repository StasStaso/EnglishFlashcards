namespace FlashCard.Host.Models
{
    public class WordJsonModel
    {
        public int Id { get; set; }
        public WordValue Value { get; set; }
    }

    public class WordValue() 
    {
        public string Word { get; set; }
        public string Href { get; set; }
        public string Type { get; set; }
        public string Level { get; set; }
        public Pronunciation Us { get; set; }
        public Pronunciation Uk { get; set; }
        public Phonetics Phonetics { get; set; }
        public List<string> Examples { get; set; }
    }

    public class Pronunciation() 
    {
        public string? Mp3 { get; set; }
        public string? Ogg { get; set; }
    }

    public class Phonetics()
    {
        public string? Us { get; set; }
        public string? Uk { get; set; }
    }
}
