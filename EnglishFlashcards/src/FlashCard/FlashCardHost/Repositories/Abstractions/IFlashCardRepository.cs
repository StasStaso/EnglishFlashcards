namespace FlashCard.Host.Repositories.Abstractions;

public interface IFlashCardRepository
{
    Task<FlashCardModel> GetFlashCardById(int id);
    Task<FlashCardModel> GetRandomFlashCard();
    Task<int> AddFlashCard(FlashCardModel model);
    Task<int> UpdateFlashCard(FlashCardModel model);
    Task<bool> DeleteFlashCard(int id);
    Task<int> UpdateFlashCardStatus(int flashCardId, int statusId);
}