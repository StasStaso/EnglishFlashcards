using Microsoft.EntityFrameworkCore;

namespace FlashCard.Host.Data.InitialData
{
    public class FlashCardInitialData(ApplicationDbContext dbContext)
    {
        public async Task Handle() 
        {
            if(!await dbContext.FlashCards.AnyAsync()) 
            {
                var result = await InitData();
                
                await dbContext.FlashCards.AddRangeAsync(result);
                await dbContext.SaveChangesAsync();
            }
        }


        private async Task<List<FlashCardModel>> InitData()
        {
            var wordIds = await dbContext.Words.Select(x => x.Id).ToListAsync();

            if(wordIds.Count == 0) 
            {
                throw new InvalidOperationException("No words found in the Words table.");
            }

            var flashCards = wordIds.Select(wordId => new FlashCardModel
            {
                WordId = wordId,
                StatusId = 1
            }).ToList();

            return flashCards;
        }
    }
}
