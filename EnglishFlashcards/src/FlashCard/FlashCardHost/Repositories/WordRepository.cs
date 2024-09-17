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

        public Task<List<WordDbModel>> GetByName(string name)
        {
            var query = dbContext.Words
                .Where(x => x.Value.Contains(name))
                .ToListAsync();

            return query;
        }

        public async Task<WordDbModel> AddNewWord(WordDbModel word) 
        {
            if(word.Value == null) 
            {

            }

            await dbContext.Words.AddAsync(word);
            await dbContext.SaveChangesAsync();
            
            return word;
        }
    }
}
