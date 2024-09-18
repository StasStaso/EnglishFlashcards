namespace FlashCard.Host.Repositories.Abstractions;

public interface IWordRepository
{
    Task<List<WordDbModel>> GetAll(int pageSize, int pageIndex);
    Task<WordDbModel> GetById(int id);
    Task<List<WordDbModel>> GetByName(string name);
    Task<int> AddNewWord(WordDbModel word);
}
