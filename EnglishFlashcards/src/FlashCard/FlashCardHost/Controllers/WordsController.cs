using Microsoft.AspNetCore.Mvc;

namespace FlashCard.Host.Controllers
{
    [ApiController]
    [Route("api/words")]
    public class WordsController(IWordService wordService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int pageSize, int pageIndex)
        {
            var response = await wordService.GetAll(pageSize, pageIndex);

            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetWordById(int id)
        {
            var response = await wordService.GetWordById(id);
            return Ok(response);
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetWordsByName(string name)
        {
            var response = await wordService.GetWordsByName(name);
            return Ok(response);
        }

        [HttpPost("AddNewWord")]
        public async Task<IActionResult> AddNewWord([FromBody] AddNewWordDto addNewWordDto)
        {
            var response = await wordService.AddNewWord(
                addNewWordDto.Value,
                addNewWordDto.TranslateValue,
                addNewWordDto.Type,
                addNewWordDto.Level,
                addNewWordDto.PronunciationUkMp3,
                addNewWordDto.PhoneticsUk,
                addNewWordDto.Examples);


            return Ok(response);
        }

        [HttpPut("UpdateWord")]
        public async Task<IActionResult> UpdateWord([FromBody] UpdateWordDto updateWordDto)
        {
            var response = await wordService.UpdateWord(
                updateWordDto.Id,
                updateWordDto.Value,
                updateWordDto.TranslateValue,
                updateWordDto.Type,
                updateWordDto.Level,
                updateWordDto.PronunciationUkMp3,
                updateWordDto.PhoneticsUk,
                updateWordDto.Examples);

            return Ok(response);
        }

        [HttpDelete("DeleteWord/{id}")]
        public async Task<IActionResult> DeleteWord(int id)
        {
            var response = await wordService.DeleteWord(id);
            return Ok(response);
        }
    }
}
