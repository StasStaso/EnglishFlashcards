using Amazon.Translate;
using Amazon.Translate.Model;
using FlashCard.Host.Services.Abstractions;


namespace FlashCardHost.Services.TranslateService
{
    public class TranslateService(IAmazonTranslate translate)
        : ITranslateService
    {
        public async Task<string> Translate(string word)
        {
            return string.Empty;
        }
    }
}
