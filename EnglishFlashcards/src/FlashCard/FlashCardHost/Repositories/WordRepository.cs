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

        public async Task<int> AddNewWord(string value, string translateValue, string type, string level,
            string? pronunciationUkMp3, string? phoneticsUk, List<string> examples)
        {
            var word = new WordDbModel
            {
                Value = value,
                TranslateValue = translateValue,
                Type = type,
                Level = level,
                PronunciationUkMp3 = pronunciationUkMp3,
                PhoneticsUk = phoneticsUk,
                Examples = examples
            };

            await dbContext.Words.AddAsync(word);
            await dbContext.SaveChangesAsync();

            return word.Id;
        }

        public async Task<int> UpdateWord(int id, string value, string translateValue, string type, string level,
            string? pronunciationUkMp3, string? phoneticsUk, List<string> examples)
        {
            var word = await dbContext.Words.FirstOrDefaultAsync(x => x.Id == id);

            if (word == null)
            {

            }

            word.Value = value;
            word.TranslateValue = translateValue;
            word.Type = type;
            word.Level = level;
            word.PronunciationUkMp3 = pronunciationUkMp3;
            word.PhoneticsUk = phoneticsUk;
            word.Examples = examples;

            dbContext.Update(word);
            await dbContext.SaveChangesAsync();

            return word.Id;
        }

        public async Task<bool> DeleteWord(int id) 
        {
            var word = dbContext.Words.First(x => x.Id == id);

            if(word is null) 
            {
                return false;
            }

            dbContext.Remove(word);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
