namespace FlashCard.Host.Services.Abstractions
{
    public interface IFlashCardService
    {
        Task<FlashCardDto> GetFlashCardById(int id);
        Task<FlashCardDto> GetRandomFlashCard();
        Task<int> AddFlashCard(AddNewFlashCardDto model);
        Task<bool> DeleteFlashCard(int id);
        Task<int> UpdateFlashCardStatus(int flashCardId, int statusId);
    }
}
