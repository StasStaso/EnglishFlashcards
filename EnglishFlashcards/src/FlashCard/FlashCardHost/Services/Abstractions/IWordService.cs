namespace FlashCard.Host.Services.Abstractions;

public interface IWordService
{
    Task<List<WordDbModel>> GetAll(int pageSize, int pageIndex);
    Task<WordDbModel> GetWordById(int id);
    Task<List<WordDbModel>> GetWordsByName(string name);
    Task<int> AddNewWord(string value, string translateValue, string type, string level,
        string? pronunciationUkMp3, string? phoneticsUk, List<string> examples);
    Task<int> UpdateWord(int id, string value, string translateValue, string type, string level,
            string? pronunciationUkMp3, string? phoneticsUk, List<string> examples);
    Task<bool> DeleteWord(int id);
}
