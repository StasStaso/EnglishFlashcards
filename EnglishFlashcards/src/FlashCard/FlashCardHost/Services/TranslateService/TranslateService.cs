using Amazon.Translate;
using Amazon.Translate.Model;
using FlashCard.Host.Services.Abstractions;


namespace FlashCard.Host.Services.TranslateService
{
    public class TranslateService(IAmazonTranslate translate)
        : ITranslateService
    {
        private const string SourceLanguageCode = "en";

        public async Task<string> Translate(string word)
        {
            return string.Empty;
        }
    }
}
