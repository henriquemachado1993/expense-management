using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Domain.Interfaces.Services
{
    public interface IBankAccountsService
    {
        BusinessResult<BankAccounts> Add(BankAccounts category);
        BusinessResult<BankAccounts> Update(BankAccounts category);
        PagingResult<List<BankAccounts>> GetPaginated(int limit = 50, int offset = 1, QueryCriteria<BankAccounts>? query = null);
        BusinessResult<List<BankAccounts>> GetFiltered(QueryCriteria<BankAccounts>? query = null);
        BusinessResult<BankAccounts> GetById(int id);
    }
}
