namespace FlashCard.Host.Services.Abstractions;

public interface IWordService
{
    Task<List<WordDbModel>> GetAll(int pageSize, int pageIndex);
}
