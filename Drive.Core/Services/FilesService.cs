using System.Threading.Tasks;
using Drive.Core.Interfaces;
using Drive.Database;
using Drive.Database.Entities;

namespace Drive.Core.Services
{
    public class FilesService : IFilesService
    {
        private readonly DriveContext _driveContext;

        public FilesService(DriveContext driveContext)
        {
            _driveContext = driveContext;
        }

        public async Task<File> Create(string path, string name)
        {
            var file = new File
            {
                Path = path,
                Name = name
            };
            await _driveContext.Files.AddAsync(file);
            await _driveContext.SaveChangesAsync();
            return file;
        }

        public async Task<bool> Delete(string id)
        {
            var file = await _driveContext.Files.FindAsync(id);
            _driveContext.Files.Remove(file);
            await _driveContext.SaveChangesAsync();
            return true;
        }
    }
}