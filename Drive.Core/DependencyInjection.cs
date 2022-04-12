using Drive.Core.Interfaces;
using Drive.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Drive.Core
{
    public static class DependencyInjection
    {
        public static void AddBusinessLogicLayerDI(this IServiceCollection services)
        {
            //add services
            services.AddScoped<IFilesService, FilesService>();
            services.AddScoped<IPhysicalFilesService, PhysicalFilesService>();
            services.AddScoped<IQuestionsService, QuestionsService>();
        }
    }
}