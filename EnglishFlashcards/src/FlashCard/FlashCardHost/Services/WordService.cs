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

namespace FlashCard.Host.Services
{
    public class WordService : IWordService
    {
        public async Task<List<Word>> GetWordById() 
        {
            string filePath = "C:\\Users\\Admin\\Source\\Repos\\EnglishFlashcards\\EnglishFlashcards\\src\\FlashCard\\FlashCardHost\\Data\\WordsJson\\full-word.json";
            string jsonString = await File.ReadAllTextAsync(filePath);

            List<Word> words = JsonSerializer.Deserialize<List<Word>>(jsonString);

            return words;
>>>>>>> ecaa71e (Update)
        }
    }
}
