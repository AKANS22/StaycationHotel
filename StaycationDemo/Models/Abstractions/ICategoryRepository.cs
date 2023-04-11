using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaycationDemo.Models.Abstractions
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories();
    }
}
