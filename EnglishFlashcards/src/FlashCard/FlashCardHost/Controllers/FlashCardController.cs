using Microsoft.AspNetCore.Mvc;

namespace FlashCardHost.Controllers
{
    [ApiController]
    [Route("api/flashcard")]
    public class FlashCardController(IFlashCardService flashCardService) : ControllerBase
    {
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await flashCardService.GetFlashCardById(id);

            return Ok(response);
        }

        [HttpGet("GetNewWord")]
        public async Task<IActionResult> GetNewWord() 
        {
            var response = await flashCardService.GetRandomFlashCard();

            return Ok(response);
        }
    }
}
