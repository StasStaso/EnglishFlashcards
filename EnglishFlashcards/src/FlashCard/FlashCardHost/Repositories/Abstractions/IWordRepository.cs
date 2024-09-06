namespace FlashCard.Host.Repositories.Abstractions;

public interface IWordRepository
{
    Task<List<WordDbModel>> GetAll(int pageSize, int pageIndex);
    Task<WordDbModel> GetById(int id);
    Task<WordDbModel> GetByName(string name);
}
