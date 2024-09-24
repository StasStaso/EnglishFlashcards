namespace FlashCard.Host.Dtos
{
    public class FlashCardDto
    {
        public int Id { get; set; }
        public string Value { get; set; } = default!;
        public string TranslateValue { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string? Type { get; set; }
        public string? Level { get; set; }
        public string? PronunciationUkMp3 { get; set; }
        public string? PhoneticsUk { get; set; }
        public List<string> Examples { get; set; } = new();
    }
}
