using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.ValueObjects;

namespace ExpenseManagement.Domain.Interfaces.Services
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
