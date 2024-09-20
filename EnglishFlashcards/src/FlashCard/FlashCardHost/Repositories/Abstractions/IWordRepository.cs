namespace FlashCard.Host.Repositories.Abstractions;

public interface IWordRepository
{
    Task<List<WordDbModel>> GetAll(int pageSize, int pageIndex);
    Task<WordDbModel> GetById(int id);
    Task<List<WordDbModel>> GetByName(string name);
    Task<int> AddNewWord(string value, string translateValue, string type, string level,
        string? pronunciationUkMp3, string? phoneticsUk, List<string> examples);
    Task<int> UpdateWord(int id, string value, string translateValue, string type, string level,
            string? pronunciationUkMp3, string? phoneticsUk, List<string> examples);
    Task<bool> DeleteWord(int id);
}
