using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.ValueObjects;

namespace ExpenseManagement.Domain.Interfaces.Services
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
