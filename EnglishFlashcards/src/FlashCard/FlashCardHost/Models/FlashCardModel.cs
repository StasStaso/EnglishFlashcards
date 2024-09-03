namespace FlashCard.Host.Models
{
    public class FlashCardModel
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public int StatusId { get; set; }

        public WordDbModel Word { get; set; } = default!;
        public StatusModel Status { get; set; } = default!;
    }
}
