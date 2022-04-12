using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Drive.Core.Interfaces;
using Drive.Core.Models;
using Drive.Database;
using Drive.Database.Entities;

namespace Drive.Core.Services
{
    public class QuestionsService : IQuestionsService
    {
        private readonly DriveContext _driveContext;
        private readonly IPhysicalFilesService _physicalFilesService;
        private readonly IFilesService _filesService;

        public QuestionsService(DriveContext driveContext, IPhysicalFilesService physicalFilesService,
            IFilesService filesService)
        {
            _driveContext = driveContext;
            _physicalFilesService = physicalFilesService;
            _filesService = filesService;
        }

        public async Task Create(string text, string prompt, string correctAnswer, QuestionCategory questionCategory,
            List<string> answers,
            UserFile photoFile)
        {
            var question = new Question()
            {
                Text = text,
                Answers = answers.Select(x => new Answer()
                {
                    Text = x
                }).ToList(),
                QuestionCategory = questionCategory,
                Prompt = prompt,
                CorrectAnswer = correctAnswer
            };
            if (photoFile != null)
            {
                const string userImportDirectoryPath = "/files";
                photoFile.FileName = Guid.NewGuid() + Path.GetExtension(photoFile.FileName);

                // сохраняем файл на сервере
                var path = await _physicalFilesService.Save(userImportDirectoryPath, photoFile);

                // добавляем сущность файла в бд
                var file = await _filesService.Create(path, photoFile.FileName);

                question.File = file;
                question.FileId = file.Id;
            }

            await _driveContext.AddAsync(question);
            await _driveContext.SaveChangesAsync();
        }
    }
}