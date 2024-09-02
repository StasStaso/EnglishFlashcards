namespace FlashCard.Host.Models
{
    public class WordDbModel
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public string Value { get; set; } = default!;
        public string TranslateValue { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string Level { get; set; } = default!;
        public string PronunciationUkMp3 { get; set; } = default!;
        public string PhoneticsUk { get; set; } = default!;
        public List<string> Examples { get; set; } = new();
    }
}
