using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Quiz.Models;

namespace Quiz.Services
{
    public class FileService : IFileService
    {
        //public Task<List<ClosedQuestionModel>> GetAsync()
        //{
        //    return GetAsync<List<ClosedQuestionModel>>("questions.json");
        //}

        public async Task<T> GetAsync<T>(string file) where T : class, new()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(file);
            using var reader = new StreamReader(stream);

            string json = await reader.ReadToEndAsync();

            return JsonSerializer.Deserialize<T>(json) ?? new T();
        }
    }
}
