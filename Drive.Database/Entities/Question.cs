using System.Collections.Generic;
using Drive.Database.Enums;

namespace Drive.Database.Entities
{
    public class Question
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
        public List<User> ErrorUsers { get; set; } 
    }
}