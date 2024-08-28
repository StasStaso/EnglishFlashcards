using Microsoft.AspNetCore.Mvc;

namespace FlashCard.Host.Controllers
{
    [ApiController]
    [Route("api/word")]
    public class WordController : ControllerBase
    {
        [HttpGet("/deserialize")]
        public async Task<IActionResult> GetTranslateWord()
        {
            return Ok();
        }
    }
}
