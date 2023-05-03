using ExpenseManagement.Shared.Entities;
using ExpenseManagement.Shared.ValueObjects;

namespace ExpenseManagement.Shared.Interfaces.Services
{
    public interface ICategoryService
    {
        BusinessResult<Category> Add(Category category);
        BusinessResult<Category> Update(Category category);
        BusinessResult<List<Category>> GetFiltered(QueryCriteria<Category>? query = null);
        BusinessResult<Category> GetById(int id);
        BusinessResult<bool> Delete(int id);
    }
}
