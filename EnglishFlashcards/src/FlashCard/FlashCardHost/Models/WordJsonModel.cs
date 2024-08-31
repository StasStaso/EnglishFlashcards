namespace FlashCard.Host.Models
{
    public class WordJsonModel
    {
        public int Id { get; set; }
        public WordValue Value { get; set; } = default!;
    }

    public class WordValue()
    {
        public string Word { get; set; } = default!;
        public string Href { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string Level { get; set; } = default!;
        public Pronunciation Us { get; set; } = default!;
        public Pronunciation Uk { get; set; } = default!;
        public Phonetics Phonetics { get; set; } = default!;
        public List<string> Examples { get; set; } = new();
    }

    public class Pronunciation()
    {
        public string Mp3 { get; set; } = default!;
        public string Ogg { get; set; } = default!;
    }

    public class Phonetics()
    {
        public string Us { get; set; } = default!;
        public string Uk { get; set; } = default!;
    }
}
