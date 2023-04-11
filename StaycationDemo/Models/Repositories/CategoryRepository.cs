using System.IO;
using System;
using StaycationDemo.Models.Abstractions;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace StaycationDemo.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private static string path = Path.Combine(Environment.CurrentDirectory, "db");
        private static readonly string categoryDb = Path.Combine(path, "category.json");
        private static IEnumerable<Category> SeedCategories()  =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Houses with beauty backyard", Description="Enjoy beautiful backyards."},
                new Category{CategoryId=2, CategoryName="Hotels with large living room", Description="Large living rooms all the way."},
                new Category{CategoryId=3, CategoryName="Apartments with kitchen set", Description="Great kitchen set to wow you."}
            };

        public IEnumerable<Category> AllCategories()
        {
            List<Category> allCategories = null;
            bool exists = File.Exists(categoryDb);
            bool existsPath = Directory.Exists(path);
            if (!exists)
            {
                if (!existsPath)
                {
                    Directory.CreateDirectory(path);
                }
                var seedCategories = SeedCategories();
                File.WriteAllText(categoryDb, JsonConvert.SerializeObject(seedCategories, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }));
            }
            var readText = File.ReadAllLines(categoryDb);
            allCategories = JsonConvert.DeserializeObject<List<Category>>(readText[0] , new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            return allCategories;
        }
    }
}
