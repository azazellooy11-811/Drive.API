using System.ComponentModel;

namespace Drive.Database.Entities
{
    public enum QuestionCategory
    {
        [Description("Общие положения")] GeneralProvisions,
        [Description("Дорожные знаки")] RoadSigns
    }
}
