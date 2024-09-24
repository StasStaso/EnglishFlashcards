using FlashCard.Host.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlashCardHost.Controllers
{
    [ApiController]
    [Route("api/flashcard")]
    public class FlashCardController(IFlashCardService flashCardService) : ControllerBase
    {
        [HttpGet("flashcard/GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await flashCardService.GetFlashCardById(id);

            return Ok(response);
        }
    }
}
