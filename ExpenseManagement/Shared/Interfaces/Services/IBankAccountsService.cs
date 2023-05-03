using ExpenseManagement.Shared.Entities;
using ExpenseManagement.Shared.ValueObjects;

namespace ExpenseManagement.Shared.Interfaces.Services
{
    public interface IBankAccountsService
    {
        BusinessResult<BankAccounts> Add(BankAccounts bankAccounts);
        BusinessResult<BankAccounts> Update(BankAccounts bankAccounts);
        BusinessResult<List<BankAccounts>> GetFiltered(QueryCriteria<BankAccounts>? query = null);
        BusinessResult<BankAccounts> GetById(int id);
        BusinessResult<bool> Delete(int id);
    }
}
