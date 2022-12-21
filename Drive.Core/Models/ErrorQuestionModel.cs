using System;
using System.Collections.Generic;
using System.Linq;
using Drive.Database.Entities;
using Drive.Database.Enums;

namespace Drive.Core.Models
{
    public class ErrorQuestionModel
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public QuestionCategory QuestionCategory { get; set; }
        public DriveCategory DriveCategory { get; set; }
        public long? FileId { get; set; }
        public File? File { get; set; }
        public string CorrectAnswer { get; set; }
        public string Prompt { get; set; } //Текст подсказки
        public List<Answer> Answers { get; set; }
        public List<User> ErrorUsers { get; set; } = new List<User>();

        public static ErrorQuestionModel FromErrorQuestionModel(Question question)
        {
            return new ErrorQuestionModel
            {
                Id = question.Id,
                CorrectAnswer = question.CorrectAnswer,
                File = question.File,
                DriveCategory = question.DriveCategory,
                Prompt = question.Prompt,
                QuestionCategory = question.QuestionCategory,
                Text = question.Text,
                Answers = question.Answers,
                ErrorUsers = question.ErrorUsers
            };
        }
    }
}
