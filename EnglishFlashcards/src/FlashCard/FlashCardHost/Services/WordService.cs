using FlashCard.Host.Repositories.Abstractions;

namespace FlashCard.Host.Services
{
    public class WordService(IWordRepository wordRepository)
        : IWordService
    {
        public async Task<List<WordDbModel>> GetAll(int pageSize, int pageIndex) 
        {
            var result = await wordRepository.GetAll(pageSize, pageIndex);
            return result;
        }

        public async Task<WordDbModel> GetWordById(int id) 
        {
            var result = await wordRepository.GetById(id);
            return result;
        }

        public async Task<List<WordDbModel>> GetWordsByName(string name) 
        {
            var result = await wordRepository.GetByName(name);
            return result;
        }

        public async Task<int> AddNewWord(WordDbModel word) 
        {
            var result = await wordRepository.AddNewWord(word);
            return result;
        }
    }
}
