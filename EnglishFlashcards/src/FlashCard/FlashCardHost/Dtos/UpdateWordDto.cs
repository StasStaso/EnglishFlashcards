namespace FlashCard.Host.Dtos
{
    public class UpdateWordDto
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string TranslateValue { get; set; }
        public string Type { get; set; }
        public string Level { get; set; }
        public string? PronunciationUkMp3 { get; set; }
        public string? PhoneticsUk { get; set; }
        public List<string> Examples { get; set; }
    }
}
