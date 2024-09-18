namespace FlashCard.Host.Services.Abstractions;

public interface IWordService
{
    Task<List<WordDbModel>> GetAll(int pageSize, int pageIndex);
    Task<WordDbModel> GetWordById(int id);
    Task<List<WordDbModel>> GetWordsByName(string name);
    Task<int> AddNewWord(WordDbModel word);
}
