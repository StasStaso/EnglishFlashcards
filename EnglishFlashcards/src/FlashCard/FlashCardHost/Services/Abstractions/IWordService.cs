using FlashCard.Host.Models;

namespace FlashCard.Host.Services.Abstractions;

public interface IWordService
{
    Task<List<WordDbModel>> MapAndTranslateWordJsonToWordDb();
}
