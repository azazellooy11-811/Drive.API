using System.Collections.Generic;
using System.Linq;
using Drive.Database.Entities;
using Drive.Database.Enums;

namespace Drive.API.Models
{
    public class QuestionDto
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public QuestionCategory QuestionCategory { get; set; }
        public DriveCategory DriveCategory { get; set; }

        public File File { get; set; }
        public string CorrectAnswer { get; set; }
        public string Prompt { get; set; } //Текст подсказки
        public List<AnswerDto> Answers { get; set; }

        public static QuestionDto FromQuestion(Question question)
        {
            return new QuestionDto
            {
                Id = question.Id,
                CorrectAnswer = question.CorrectAnswer,
                File = question.File,
                DriveCategory = question.DriveCategory,
                Prompt = question.Prompt,
                QuestionCategory = question.QuestionCategory,
                Text = question.Text,
                Answers = question.Answers.Select(AnswerDto.FromAnswer).ToList()
            };
        }
    }
}