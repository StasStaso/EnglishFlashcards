namespace FlashCard.Host.Repositories.Abstractions;

public interface IFlashCardRepository
{
    Task<FlashCardDto> GetFlashCardById(int id);
    Task<FlashCardDto> GetRandomFlashCard();
    Task<int> AddFlashCard(AddNewFlashCardDto model);
    Task<int> UpdateFlashCardStatus(int flashCardId, int statusId);
    Task<bool> DeleteFlashCard(int id);
}