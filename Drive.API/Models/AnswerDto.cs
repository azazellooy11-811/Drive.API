using Drive.Database.Entities;

namespace Drive.API.Models
{
    public class AnswerDto
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public static AnswerDto FromAnswer(Answer answer)
        {
            return new AnswerDto
            {
                Text = answer.Text,
                Id = answer.Id
            };
        }
    }
}