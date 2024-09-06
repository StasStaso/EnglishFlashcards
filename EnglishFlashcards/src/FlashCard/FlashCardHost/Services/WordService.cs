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
    }
}
