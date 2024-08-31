using FlashCard.Host.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FlashCardHost.Controllers
{
    [ApiController]
    [Route("api/flashcard")]
    public class FlashCardController(
        ITranslateService translate, IWordService wordService) : ControllerBase
    {
        [HttpGet("/generate")]
        public async Task<IActionResult> GetTranslateWord(string text) 
        {
            var response = await translate.Translate(text);

            return Ok();
        }
    }
}
