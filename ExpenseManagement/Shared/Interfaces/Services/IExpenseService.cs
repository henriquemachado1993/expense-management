using ExpenseManagement.Shared.Entities;
using ExpenseManagement.Shared.ValueObjects;

namespace ExpenseManagement.Shared.Interfaces.Services
{
    public interface IExpenseService
    {
        BusinessResult<Expense> Add(Expense expense);
        BusinessResult<Expense> Update(Expense expense);
        BusinessResult<Expense> ConfirmPayment(int id);
        PagingResult<List<Expense>> GetPaginated(int limit = 50, int offset = 1, QueryCriteria<Expense>? query = null);
        BusinessResult<List<Expense>> GetFiltered(QueryCriteria<Expense>? query = null);
        BusinessResult<Expense> GetById(int id);
        BusinessResult<bool> Delete(int id);
    }
}
