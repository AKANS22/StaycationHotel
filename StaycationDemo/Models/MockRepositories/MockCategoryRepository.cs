using System.Collections.Generic;
using System.Threading.Tasks;
using StaycationDemo.Models.Abstractions;

namespace StaycationDemo.Models.Repositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories() =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Houses with beauty backyard", Description="Enjoy beautiful backyards."},
                new Category{CategoryId=2, CategoryName="Hotels with large living room", Description="Large living rooms all the way."},
                new Category{CategoryId=3, CategoryName="Apartments with kitchen set", Description="Great kitchen set to wow you."}
            };
    }
}
