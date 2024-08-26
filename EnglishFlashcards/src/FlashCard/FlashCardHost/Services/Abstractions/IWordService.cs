using FlashCardHost.Models;

namespace FlashCard.Host.Services.Abstractions
{
    public interface IWordService
    {
        Task<List<Word>> GetWordById();
    }
}
