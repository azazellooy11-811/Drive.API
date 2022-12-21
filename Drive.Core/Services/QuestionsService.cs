using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Drive.Core.Interfaces;
using Drive.Core.Models;
using Drive.Database;
using Drive.Database.Entities;
using Drive.Database.Enums;
using Microsoft.EntityFrameworkCore;

namespace Drive.Core.Services
{
    public class QuestionsService : IQuestionsService
    {
        private readonly DriveContext _driveContext;
        private readonly IFilesService _filesService;
        private readonly IPhysicalFilesService _physicalFilesService;

        public QuestionsService(DriveContext driveContext, IPhysicalFilesService physicalFilesService,
            IFilesService filesService)
        {
            _driveContext = driveContext;
            _physicalFilesService = physicalFilesService;
            _filesService = filesService;
        }

        public async Task<List<Question>> List(QuestionCategory? questionCategory, DriveCategory? driveCategory)
        {
            var result = await _driveContext.Questions
                .Include(x => x.File)
                .Include(x => x.Answers)
                .ToListAsync();
            if (questionCategory != null)
                result = result
                    .Where(x => x.QuestionCategory == questionCategory)
                    .ToList();
            if (driveCategory != null)
                result = result
                    .Where(x => x.DriveCategory == driveCategory)
                    .ToList();
            return result;
        }

        public async Task Create(string text, string prompt, string correctAnswer, QuestionCategory questionCategory,
            DriveCategory driveCategory,
            List<string> answers,
            UserFile photoFile)
        {
            var question = new Question
            {
                Text = text,
                Answers = answers.Select(x => new Answer
                {
                    Text = x
                }).ToList(),
                QuestionCategory = questionCategory,
                DriveCategory = driveCategory,
                Prompt = prompt,
                CorrectAnswer = correctAnswer
            };
            if (photoFile != null)
            {
                const string userImportDirectoryPath = "/Users/azazellooy/Projects/drive.xamarin/DriveXamarin/Resources/drawable";
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

        public async Task Delete(long driveContextId)
        {
            var question = await _driveContext.Questions.FirstOrDefaultAsync(x => x.Id == driveContextId);
            _driveContext.Remove(question);
            await _driveContext.SaveChangesAsync();
        }

        public async Task Update(long questionId, string text, string prompt, string correctAnswer,
            QuestionCategory? questionCategory, DriveCategory? driveCategory,
            List<string> answers, UserFile photoFile)
        {
            var question = await _driveContext.Questions.Include(x => x.Answers).Include(x => x.File)
                .FirstOrDefaultAsync(x => x.Id == questionId);
            if (text != null) question.Text = text;
            if (prompt != null) question.Prompt = prompt;
            if (correctAnswer != null) question.CorrectAnswer = correctAnswer;
            if (questionCategory != null) question.QuestionCategory = (QuestionCategory) questionCategory;
            if (driveCategory != null) question.DriveCategory = (DriveCategory) driveCategory;
            if (photoFile != null)
            {
                const string userImportDirectoryPath = "/Users/azazellooy/Files";
                photoFile.FileName = Guid.NewGuid() + Path.GetExtension(photoFile.FileName);
                if (question.File != null)
                    _physicalFilesService.Delete(question.File.Path);

                // сохраняем файл на сервере
                var path = await _physicalFilesService.Save(userImportDirectoryPath, photoFile);

                // добавляем сущность файла в бд
                var file = await _filesService.Create(path, photoFile.FileName);

                question.File = file;
                question.FileId = file.Id;
            }

            if (answers != null && answers.Count != 0)
                question.Answers = answers.Select(x => new Answer
                {
                    Text = x
                }).ToList();
            var existAnswers = await _driveContext.Answers.Where(x => x.QuestionId == questionId).ToListAsync();
            _driveContext.Answers.RemoveRange(existAnswers);
            await _driveContext.SaveChangesAsync();
            _driveContext.Questions.Update(question);
            await _driveContext.SaveChangesAsync();
        }

        public List<QuestionCategoryDto> GetQuestionCategories()
        {
            return (from suit in (QuestionCategory[]) Enum.GetValues(typeof(QuestionCategory))
                select new QuestionCategoryDto {Id = (int) suit, Name = GetDescriptionAttribute(suit)}).ToList();
        }

        private static string GetDescriptionAttribute(QuestionCategory result)
        {
            return ((DescriptionAttribute) Attribute.GetCustomAttribute(
                result.GetType().GetField(result.ToString()) ?? throw new InvalidCastException(),
                typeof(DescriptionAttribute)))?.Description;
        }
    }
}