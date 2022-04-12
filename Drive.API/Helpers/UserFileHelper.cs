using System.IO;
using System.Threading.Tasks;
using Drive.Core.Models;
using Microsoft.AspNetCore.Http;

namespace Drive.API.Helpers
{
    public static class UserFileHelper
    {
        public static async Task<UserFile> ToUserFile(this IFormFile file)
        {
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            return new UserFile
            {
                Data = memoryStream.ToArray(),
                FileName = file.FileName
            };
        }
    }
}