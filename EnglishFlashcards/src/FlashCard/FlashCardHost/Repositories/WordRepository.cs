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
                .OrderBy(x => x.Id)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return query;
        }

        public async Task<WordDbModel> GetById(int id)
        {
            var query = await dbContext.Words.FirstOrDefaultAsync(x => x.Id == id);

            if (query == null) 
            {
                return new WordDbModel();
            }

            return query;
        }

        public async Task<List<WordDbModel>> GetByName(string name)
        {
            var query = await dbContext.Words
                .Where(x => x.Value.Contains(name))
                .ToListAsync();

            return query;
        }

        public async Task<int> AddNewWord(WordDbModel word) 
        {
            var existingId = await dbContext.Words
                .FirstOrDefaultAsync(w => w.Id == word.Id);

            if (existingId is not null)
            {
                throw new ArgumentException($"Word with Id {word.Id} already exists.");
            }

            await dbContext.Words.AddAsync(word);
            await dbContext.SaveChangesAsync();
            
            return word.Id;
        }
    }
}
