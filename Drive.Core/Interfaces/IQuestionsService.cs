using System.Collections.Generic;
using System.Threading.Tasks;
using Drive.Core.Models;
using Drive.Database.Entities;
using Drive.Database.Enums;

namespace Drive.Core.Interfaces
{
    public interface IQuestionsService
    {
        Task Create(string text, string prompt, string correctAnswer, QuestionCategory questionCategory,
            DriveCategory driveCategory, List<string> answers, UserFile photoFile);

        Task Update(long questionId, string text, string prompt, string correctAnswer,
            QuestionCategory? questionCategory, DriveCategory? driveCategory,
            List<string> answers, UserFile photoFile);

        Task<List<Question>> List(QuestionCategory? questionCategory, DriveCategory? driveCategory);
        Task Delete(long driveContextId);
        List<QuestionCategoryDto> GetQuestionCategories();

    }
}