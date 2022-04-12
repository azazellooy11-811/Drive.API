using System.IO;
using System.Threading.Tasks;
using Drive.Core.Models;

namespace Drive.Core.Interfaces
{
    public interface IPhysicalFilesService
    {
        Task<string> Save(string directory, UserFile userFile);
        Task<FileStream> Get(string path);
        Task<string> Read(string path);
        bool Delete(string path);
    }
}
