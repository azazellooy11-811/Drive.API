using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drive.API.Helpers;
using Drive.API.Models;
using Drive.API.Models.Requests;
using Drive.Core.Interfaces;
using Drive.Core.Models;
using Drive.Database.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Drive.API.Controllers
{
    [Produces("application/json")]
    [Route("driveapi/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsService _questionsService;

        public QuestionsController(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        [HttpGet("List")]
        public async Task<List<QuestionDto>> List(QuestionCategory? questionCategory, DriveCategory? driveCategory)
        {
            var result = await _questionsService.List(questionCategory, driveCategory);
            return result.Select(QuestionDto.FromQuestion).ToList();
        }

        [HttpGet("GetQuestionCategories")]
        public List<QuestionCategoryDto> GetQuestionCategories()
        {
            var result = _questionsService.GetQuestionCategories();
            return result;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] QuestionCreateRequest questionCreateRequest)
        {
            var file = questionCreateRequest.File != null
                ? await questionCreateRequest.File.ToUserFile()
                : null;
            await _questionsService.Create(questionCreateRequest.Text, questionCreateRequest.Prompt,
                questionCreateRequest.CorrectAnswer,
                questionCreateRequest.QuestionCategory,
                questionCreateRequest.DriveCategory,
                questionCreateRequest.Answers, file);
            return NoContent();
        }


        [HttpDelete("Delete")]
        public async Task Delete(long questionId)
        {
            await _questionsService.Delete(questionId);
        }

        [HttpPatch("Update")]
        public async Task Update([FromForm] QuestionUpdateRequest questionUpdateRequest)
        {
            UserFile file = null;
            if (questionUpdateRequest.File != null)
                file = questionUpdateRequest.File != null
                    ? await questionUpdateRequest.File.ToUserFile()
                    : null;
            await _questionsService.Update(questionUpdateRequest.QuestionId, questionUpdateRequest.Text,
                questionUpdateRequest.Prompt, questionUpdateRequest.CorrectAnswer,
                questionUpdateRequest.QuestionCategory, questionUpdateRequest.DriveCategory,
                questionUpdateRequest.Answers, file);
        }
    }
}