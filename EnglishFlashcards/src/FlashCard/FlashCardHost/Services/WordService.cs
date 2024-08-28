<<<<<<< HEAD
<<<<<<< HEAD
﻿using FlashCardHost.Models;
using FlashCardHost.Services.Abstractions;

namespace FlashCardHost.Services
{
    public class WordService(ITranslateService translate) 
    {
        public async Task<string> GetWord()
        {
            return string.Empty;
=======
﻿using FlashCard.Host.Services.Abstractions;
using FlashCardHost.Models;
using System.Text.Json;
=======
﻿using FlashCard.Host.Models;
using FlashCard.Host.Services.Abstractions;
using Newtonsoft.Json;
>>>>>>> 27dc157 (Update)

namespace FlashCard.Host.Services
{
    public class WordService(IWebHostEnvironment env) : IWordService
    {
        public async Task<List<WordJsonModel>> GetWord() 
        {
            var path = Path.Combine(env.ContentRootPath, "Data", "WordsJson", "full-word.json");

            var jsonContent = await File.ReadAllTextAsync(path);

<<<<<<< HEAD
            return words;
>>>>>>> ecaa71e (Update)
=======
            var allWords = JsonConvert.DeserializeObject<List<WordJsonModel>>(jsonContent);

            return allWords ?? new List<WordJsonModel>();
>>>>>>> 27dc157 (Update)
        }
    }
}
