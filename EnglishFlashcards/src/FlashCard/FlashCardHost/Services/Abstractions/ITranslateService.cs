namespace FlashCard.Host.Services.Abstractions;

public interface ITranslateService
{
    Task<string> Translate(string word);
}
