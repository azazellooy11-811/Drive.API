using System.Threading.Tasks;
using Drive.Database.Entities;

namespace Drive.Core.Interfaces
{
    public interface IFilesService
    {
        Task<File> Create(string path, string name);
        Task<bool> Delete(string id);
    }
}