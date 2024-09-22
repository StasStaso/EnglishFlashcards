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

        public async Task<int> AddNewWord(string value, string translateValue, string type, string level,
            string? pronunciationUkMp3, string? phoneticsUk, List<string> examples)
        {
            var result = await wordRepository.AddNewWord(value, translateValue, type,
                level, pronunciationUkMp3, phoneticsUk, examples);

            return result;
        }

        public async Task<int> UpdateWord(int id, string value, string translateValue, string type, string level,
            string? pronunciationUkMp3, string? phoneticsUk, List<string> examples)
        {
            var result = await wordRepository.UpdateWord(id, value, translateValue, type,
                level, pronunciationUkMp3, phoneticsUk, examples);

            return result;
        }

        public async Task<bool> DeleteWord(int id) 
        {
            var result = await wordRepository.DeleteWord(id);

            return result;
        }
    }
}
