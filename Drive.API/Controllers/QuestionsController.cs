using System.Threading.Tasks;
using Drive.API.Helpers;
using Drive.API.Models.Requests;
using Drive.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drive.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/1/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsService _questionsService;

        public QuestionsController(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] QuestionCreateRequest questionCreateRequest)
        {
            var file = questionCreateRequest.File != null
                ? await questionCreateRequest.File.ToUserFile()
                : null;
            await _questionsService.Create(questionCreateRequest.Text, questionCreateRequest.Prompt,
                questionCreateRequest.CorrectAnswer,
                questionCreateRequest.QuestionCategory,
                questionCreateRequest.Answers, file);
            return NoContent();
        }
    }
}
