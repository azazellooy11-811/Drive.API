using System.Collections.Generic;
using Drive.Database.Enums;
using Microsoft.AspNetCore.Http;

namespace Drive.API.Models.Requests
{
    public class QuestionUpdateRequest
    {
        public long QuestionId { get; set; }

        public string Text { get; set; }
        public QuestionCategory? QuestionCategory { get; set; }
        public DriveCategory? DriveCategory { get; set; }

        public string CorrectAnswer { get; set; }
        public string Prompt { get; set; } //Текст подсказки
        public List<string> Answers { get; set; }
        public IFormFile File { get; set; } = null!;
    }
}