using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.ValueObjects;

namespace ExpenseManagement.Domain.Interfaces.Services
{
    public interface IExpenseService
    {
        BusinessResult<Expense> Add(Expense expense);
        BusinessResult<Expense> Update(Expense expense);
        PagingResult<List<Expense>> GetPaginated(int limit = 50, int offset = 1, QueryCriteria<Expense>? query = null);
        BusinessResult<List<Expense>> GetFiltered(QueryCriteria<Expense>? query = null);
        BusinessResult<Expense> GetById(int id);
        BusinessResult<bool> Delete(int id);
    }
}
