namespace FlashCard.Host.Models
{
    public class StatusModel
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; } = default!;

        public List<WordDbModel> Words { get; set; } = new();
    }
}
