namespace FlashCard.Host.Models
{
    public class WordDbModel
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public string Value { get; set; } = default!;
        public string TranslateValue { get; set; } = default!;
        public string? Type { get; set; }
        public string? Level { get; set; }
        public string? PronunciationUkMp3 { get; set; }
        public string? PhoneticsUk { get; set; }
        public List<string> Examples { get; set; } = new();
    }
}
