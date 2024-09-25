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

        [HttpGet("GetRandomWord")]
        public async Task<IActionResult> GetRandomWord() 
        {
            var response = await flashCardService.GetRandomFlashCard();

            return Ok(response);
        }

        [HttpPost("AddNewFlashCard")]
        public async Task<IActionResult> AddNewFlashCard(FlashCardModel model) 
        {
            var response = await flashCardService.AddFlashCard(model);

            return Ok(response);
        }

        [HttpDelete("DeleteFlashCard/{id}")]
        public async Task<IActionResult> DeleteFlashCard(int id) 
        {
            var response = await flashCardService.DeleteFlashCard(id);

            return Ok(response);
        }

        [HttpPut("UpdateFlashCard")]
        public async Task<IActionResult> UpdateFlashCard(FlashCardModel model) 
        {
            var response = await flashCardService.UpdateFlashCard(model);

            return Ok(response);
        }

        [HttpPut("UpdateFlashCardStatus/{flashCardId}/{statusId}")]
        public async Task<IActionResult> UpdateFlashCardStatus(int flashCardId, int statusId) 
        {
            var response = await flashCardService.UpdateFlashCardStatus(flashCardId, statusId);

            return Ok(response);
        }
    }
}
