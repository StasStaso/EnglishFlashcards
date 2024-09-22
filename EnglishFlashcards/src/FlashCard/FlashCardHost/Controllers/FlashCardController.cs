using Microsoft.AspNetCore.Mvc;

namespace FlashCardHost.Controllers
{
    [ApiController]
    [Route("api/flashcard")]
    public class FlashCardController(
        ITranslateService translate) : ControllerBase
    {
        [HttpGet("/GetTranslateWord")]
        public async Task<IActionResult> GetTranslateWord(string text) 
        {
            var response = await translate.Translate(text);

            return Ok(response);
        }
    }
}
