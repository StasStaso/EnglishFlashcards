namespace FlashCard.Host.Models
{
    public class WordDbModel
    {
        public int WordId { get; set; }
        public string Value { get; set; } = default!;
        public string TranslateValue { get; set; } = default!;
        public Status Status { get; set; } = Status.Unknown;
        public string Type { get; set; } = default!;
        public string Level { get; set; } = default!;
        public string PronunciationUkMp3 { get; set; } = default!;
        public string PhoneticsUk { get; set; } = default!;
        public List<string> Examples { get; set; } = new();
    }

    public enum Status
    {
        Unknown = 1,
        Learning = 2,
        Known = 3,
    }
}
