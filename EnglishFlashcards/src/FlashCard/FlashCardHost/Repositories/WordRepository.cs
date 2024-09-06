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

        public Task<WordDbModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WordDbModel> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
