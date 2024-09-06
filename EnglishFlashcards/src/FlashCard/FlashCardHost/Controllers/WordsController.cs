using Microsoft.AspNetCore.Mvc;

namespace FlashCard.Host.Controllers
{
    [ApiController]
    [Route("api/words")]
    public class WordsController(IWordService wordService) : ControllerBase
    {
        [HttpGet("/GetAll")]
        public async Task<IActionResult> GetAll(int pageSize, int pageIndex)
        {
            var response = await wordService.GetAll(pageSize, pageIndex);

            return Ok(response);
        }
    }
}
