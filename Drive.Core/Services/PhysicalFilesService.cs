using System.IO;
using System.Threading.Tasks;
using Drive.Core.Interfaces;
using Drive.Core.Models;

namespace Drive.Core.Services
{
    public class PhysicalFilesService : IPhysicalFilesService
    {
        /// <summary>
        ///     Сохраняет файл на сервере
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="userFile"></param>
        /// <returns>Путь к сохраненному файлу</returns>
        public async Task<string> Save(string directory, UserFile userFile)
        {
            Directory.CreateDirectory(directory);
            var path = Path.Combine(directory, userFile.FileName);

            // save file
            await File.WriteAllBytesAsync(path, userFile.Data);

            return path;
        }

        public async Task<FileStream> Get(string path)
        {
            return await Task.FromResult(File.OpenRead(path));
        }

        public bool Delete(string path)
        {
            try
            {
                File.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> Read(string path)
        {
            using StreamReader sourceReader = File.OpenText(path);
            string text = await sourceReader.ReadToEndAsync();
            return text;
        }
    }
}