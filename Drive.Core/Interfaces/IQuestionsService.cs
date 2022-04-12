
using System.Collections.Generic;
using System.Threading.Tasks;
using Drive.Core.Models;
using Drive.Database.Entities;

namespace Drive.Core.Interfaces
{
    public interface IQuestionsService
    {
        Task Create(string text, string prompt, string correctAnswer, QuestionCategory questionCategory,
            List<string> answers, UserFile photoFile);
    }
}
