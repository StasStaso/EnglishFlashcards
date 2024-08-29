using Newtonsoft.Json;

namespace FlashCard.Host.Data.InitialData
{
    public class FlashCardInitialData(IWebHostEnvironment env, IMapper mapper, ITranslateService translateService)
    {
        public async Task<List<WordDbModel>> MapAndTranslateWordJsonToWordDb()
        {
            var wordJsonModels = await DeserializeWordJsonModel();
            var wordDbModels = MapToWordDbModels(wordJsonModels);

            await AddTranslationsToWordDbModelsAsync(wordDbModels);

            return wordDbModels;
        }

        private async Task<List<WordJsonModel>> DeserializeWordJsonModel()
        {
            var path = Path.Combine(env.ContentRootPath, "Data", "WordsJson", "full-word.json");

            var jsonContent = await File.ReadAllTextAsync(path);

            var allWords = JsonConvert.DeserializeObject<List<WordJsonModel>>(jsonContent);

            if (allWords is null)
            {
                throw new FileNotFoundException("full-word.json not found");
            }

            return allWords;
        }

        private List<WordDbModel> MapToWordDbModels(List<WordJsonModel> wordJsonModels)
        {
            return mapper.Map<List<WordJsonModel>, List<WordDbModel>>(wordJsonModels);
        }

        private async Task AddTranslationsToWordDbModelsAsync(List<WordDbModel> wordDbModels)
        {
            var translateTasks = wordDbModels.Select(async wordDbModel =>
            {
                if (wordDbModel.Value != null)
                {
                    wordDbModel.TranslateValue = await translateService.Translate(wordDbModel.Value);
                }
            });

            await Task.WhenAll(translateTasks);
        }
    }
}