using FlashCard.Host.Data;
using FlashCard.Host.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FlashCard.Host.Repositories
{
    public class WordRepository(ApplicationDbContext dbContext) : IWordRepository
    {
        public async Task<List<WordDbModel>> GetAll(int pageSize, int pageIndex)
        {
            var query = await dbContext.Words
                .OrderBy(x => x.WordId)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return query;
        }

        public async Task<WordDbModel> GetById(int id)
        {
            var query = await dbContext.Words.FirstOrDefaultAsync(x => x.WordId == id);

            if (query == null) 
            {
                return new WordDbModel();
            }

            return query;
        }

        public Task<WordDbModel> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
