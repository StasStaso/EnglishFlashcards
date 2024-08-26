namespace FlashCardHost.Models
{
    public class Word
    {
        public int Id { get; set; }
        public string? Value { get; set; }
        public string? TranslateValue { get; set; }
        public string? Type { get; set; }
        public string? Level { get; set; }
        public Phonetics? Phonetics { get; set; }
        public List<string> Examples { get; set; } = new();
    }

    public class Phonetics()
    {
        public string Mp3 { get; set; }
    }
}
