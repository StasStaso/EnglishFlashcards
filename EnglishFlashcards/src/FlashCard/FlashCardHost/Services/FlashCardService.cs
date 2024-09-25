
namespace FlashCard.Host.Services
{
    public class FlashCardService(IFlashCardRepository flashCardRepository) : IFlashCardService
    {
        public async Task<FlashCardDto> GetFlashCardById(int id)
        {
            var result = await flashCardRepository.GetFlashCardById(id);
            return result;
        }

        public async Task<FlashCardDto> GetRandomFlashCard()
        {
            var result = await flashCardRepository.GetRandomFlashCard();
            return result;
        }

        public async Task<int> AddFlashCard(FlashCardModel model)
        {
            var result = await flashCardRepository.AddFlashCard(model);
            return result;
        }

        public async Task<bool> DeleteFlashCard(int id)
        {
            var result = await flashCardRepository.DeleteFlashCard(id);
            return result;
        }

        public async Task<int> UpdateFlashCard(FlashCardModel model)
        {
            var result = await flashCardRepository.UpdateFlashCard(model);
            return result;
        }

        public async Task<int> UpdateFlashCardStatus(int flashCardId, int statusId)
        {
            var result = await UpdateFlashCardStatus(flashCardId, statusId);
            return result;
        }
    }
}
