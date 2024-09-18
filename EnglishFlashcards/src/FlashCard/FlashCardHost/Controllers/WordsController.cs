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

        [HttpGet("/GetById/{id}")]
        public async Task<IActionResult> GetWordById(int id) 
        {
            var response = await wordService.GetWordById(id); 
            return Ok(response);
        }

        [HttpGet("/GetByName/{name}")]
        public async Task<IActionResult> GetWordsByName(string name) 
        {
            var response = await wordService.GetWordsByName(name);
            return Ok(response);
        }

        [HttpPost("/AddNewWord")]
        public async Task<IActionResult> AddNewWord(string value, string translateValue, string type, string level,
            string? pronunciationUkMp3, string? phoneticsUk, List<string> examples)
        {
            var response = await wordService.AddNewWord(value, translateValue, type,
                level, pronunciationUkMp3, phoneticsUk, examples);

            return Ok(response);
        }
    }
}
