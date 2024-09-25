using Microsoft.EntityFrameworkCore;

namespace FlashCard.Host.Repositories
{
    public class FlashCardRepository(ApplicationDbContext dbContext) : IFlashCardRepository
    {
        public async Task<int> AddFlashCard(AddNewFlashCardDto model)
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

        public async Task<FlashCardDto> GetFlashCardById(int id)
        {
            var flashCard = await dbContext.FlashCards
                .Include(w => w.Word)
                .Include(w => w.Status)
                .FirstOrDefaultAsync(x => x.Id == id);


            if (flashCard is null) 
            {
                throw new FlashCardNotFoundException(id);
            }

            return new FlashCardDto
            {
                Id = flashCard.Id,
                Value = flashCard.Word.Value,
                TranslateValue = flashCard.Word.TranslateValue,
                Status = flashCard.Status.StatusName,
                Type = flashCard.Word.Type,
                Level = flashCard.Word.Level,
                PronunciationUkMp3 = flashCard.Word.PronunciationUkMp3,
                PhoneticsUk = flashCard.Word.PhoneticsUk,
                Examples = flashCard.Word.Examples
            };
        }

        public async Task<FlashCardDto> GetRandomFlashCard()
        {
            var flashCards = await dbContext.FlashCards
                .Where(x => x.StatusId == 1)
                .Include(w => w.Word)
                .Include(s => s.Status)
                .ToListAsync();

            if (flashCards == null || flashCards.Count == 0)
            {
                throw new FlashCardNotFoundException();
            }

            var random = new Random();
            int randomIndex = random.Next(flashCards.Count);

            var result = new FlashCardDto
            {
                Id = flashCards[randomIndex].Id,
                Value = flashCards[randomIndex].Word.Value,
                TranslateValue = flashCards[randomIndex].Word.TranslateValue,
                Status = flashCards[randomIndex].Status.StatusName,
                Type = flashCards[randomIndex].Word.Type,
                Level = flashCards[randomIndex].Word.Level,
                PronunciationUkMp3 = flashCards[randomIndex].Word.PronunciationUkMp3,
                PhoneticsUk = flashCards[randomIndex].Word.PhoneticsUk,
                Examples = flashCards[randomIndex].Word.Examples
            };

            return result;
        }

        public async Task<int> UpdateFlashCardStatus(int flashCardId, int statusId)
        {
            var flashCard = await dbContext.FlashCards.FirstOrDefaultAsync(x => x.Id == flashCardId);

            if (flashCard is null)
            {
                throw new NotFoundException("FlashCard", flashCardId);
            }

            flashCard.StatusId = statusId;
            
            await dbContext.SaveChangesAsync();

            return flashCard.Id;
        }
    }
}
