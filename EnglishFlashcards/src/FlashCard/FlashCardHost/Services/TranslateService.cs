using Amazon.Translate;
using Amazon.Translate.Model;


namespace FlashCard.Host.Services
{
    public class TranslateService(IAmazonTranslate translate)
        : ITranslateService
    {
        private const string SourceLanguageCode = "en";
        private const string TargetLanguageCode = "uk";

        public async Task<string> Translate(string word)
        {
            var request = new TranslateTextRequest
            {
                Text = word,
                SourceLanguageCode = SourceLanguageCode,
                TargetLanguageCode = TargetLanguageCode
            };

            var response = await translate.TranslateTextAsync(request);

            return response.TranslatedText;
        }
    }
}
