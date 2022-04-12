
namespace Drive.Database.Entities
{
    public class File
    {
        public long Id { get; set; }

        /// <summary>
        ///     Путь к файлу на сервере
        /// </summary>
        public string Path { get; set; } = null!;

        /// <summary>
        ///     Пользовательское имя файла
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
