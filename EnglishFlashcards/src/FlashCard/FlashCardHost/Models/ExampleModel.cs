namespace FlashCard.Host.Models
{
    public class ExampleModel
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public string ExampleText { get; set; } = default!;

        public WordDbModel Word { get; set; } = default!;
    }
}
