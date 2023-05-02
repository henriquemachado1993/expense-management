using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        BusinessResult<Category> Add(Category category);
        BusinessResult<Category> Update(Category category);
        PagingResult<List<Category>> GetPaginated(int limit = 50, int offset = 1, QueryCriteria<Category>? query = null);
        BusinessResult<List<Category>> GetFiltered(QueryCriteria<Category>? query = null);
        BusinessResult<Category> GetById(int id);
    }
}
