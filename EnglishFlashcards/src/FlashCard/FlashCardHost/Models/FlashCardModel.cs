namespace FlashCard.Host.Models
{
    public class FlashCardModel
    {
        public int WordId { get; set; }
        public int StatusId { get; set; }

        public WordDbModel Word { get; set; }
        public StatusModel Status { get; set; }
    }
}
