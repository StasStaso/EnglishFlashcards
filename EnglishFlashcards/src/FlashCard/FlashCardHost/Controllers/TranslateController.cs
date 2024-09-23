using Microsoft.AspNetCore.Mvc;

namespace FlashCard.Host.Controllers
{
    [ApiController]
    [Route("api/translate")]
    public class TranslateController
        (ITranslateService translateService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Translate(string message) 
        {
            var result = await translateService.Translate(message);
            return Ok(result);
        }
    }
}
