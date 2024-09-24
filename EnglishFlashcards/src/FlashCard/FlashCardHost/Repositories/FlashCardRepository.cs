using Microsoft.EntityFrameworkCore;

namespace FlashCard.Host.Repositories
{
    public class FlashCardRepository(ApplicationDbContext dbContext) : IFlashCardRepository
    {
        public async Task<int> AddFlashCard(FlashCardModel model)
        {
            var flashCard = new FlashCardModel
            {
                WordId = model.WordId,
                StatusId = model.StatusId,
            };

            await dbContext.AddAsync(flashCard);
            await dbContext.SaveChangesAsync();

            return flashCard.Id;
        }

        public async Task<bool> DeleteFlashCard(int id)
        {
            var flashCard = await dbContext.FlashCards.FirstAsync(x => x.Id == id);

            if(flashCard is null) 
            {
                throw new FlashCardNotFoundException(id);
            }

            dbContext.FlashCards.Remove(flashCard);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<FlashCardModel> GetFlashCardById(int id)
        {
            var flashCard = await dbContext.FlashCards.FirstOrDefaultAsync(x => x.Id == id);

            if (flashCard is null) 
            {
                throw new FlashCardNotFoundException(id);
            }

            return flashCard;
        }

        public async Task<FlashCardModel> GetRandomFlashCard()
        {
            var flashCards = await dbContext.FlashCards
                .Where(x => x.StatusId == 1)
                .ToListAsync();

            if (flashCards == null || flashCards.Count == 0)
            {
                throw new FlashCardNotFoundException();
            }

            var random = new Random();
            int randomIndex = random.Next(flashCards.Count);
            
            return flashCards[randomIndex];
        }

        public Task<int> UpdateFlashCard(FlashCardModel model)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateFlashCardStatus(int flashCardId, int statusId)
        {
            throw new NotImplementedException();
        }
    }
}
