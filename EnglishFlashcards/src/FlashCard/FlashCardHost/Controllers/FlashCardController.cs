using FlashCard.Host.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FlashCardHost.Controllers
{
    [ApiController]
    [Route("api/flashcard")]
    public class FlashCardController(
        ITranslateService translate,
        IWordService word) : ControllerBase
    {
        [HttpGet("/generate/{id}")]
        public async Task<IActionResult> GetTranslateWord(string text) 
        {
            var response = await translate.Translate(text);

            return Ok();
        }

        [HttpGet("/generate/")]
        public async Task<IActionResult> GetWord(string text)
        {
            var response = await word.GetWordById();

            return Ok(response);
        }
    }
}
