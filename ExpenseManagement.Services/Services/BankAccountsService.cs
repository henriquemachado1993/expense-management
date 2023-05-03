using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.Interfaces.Data;
using ExpenseManagement.Domain.Interfaces.Services;
using ExpenseManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Services.Services
{
    public class BankAccountsService : IBankAccountsService
    {
        private readonly IUnitOfWork _uow;

        public BankAccountsService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public BusinessResult<BankAccounts> Add(BankAccounts bankAccounts)
        {
            var result = BusinessResult<BankAccounts>.CreateValidResult(bankAccounts);

            bankAccounts.CreatedAt = DateTime.Now;
            result.Data = _uow.GetRepository<BankAccounts>().Add(bankAccounts);
            _uow.Commit();

            return result;
        }

        public BusinessResult<BankAccounts> Update(BankAccounts bankAccounts)
        {
            var result = BusinessResult<BankAccounts>.CreateValidResult();

            var entity = _uow.GetRepository<BankAccounts>().GetFiltered(new QueryCriteria<BankAccounts>()
            {
                Expression = x => (x.Id == bankAccounts.Id)
            }).FirstOrDefault();

            if (entity == null)
            {
                result.WithErrors("Registro não encontrado.");
                return result;
            }

            entity.Title = bankAccounts.Title;
            entity.Type = bankAccounts.Type;
            entity.AccountValue = bankAccounts.AccountValue;
            entity.LastModifiedAt = DateTime.Now;

            result.Data = _uow.GetRepository<BankAccounts>().Update(entity);
            _uow.Commit();

            return result;
        }

        public BusinessResult<bool> Delete(int id)
        {
            var result = BusinessResult<bool>.CreateValidResult();
            var entity = _uow.GetRepository<BankAccounts>().GetById(id);
            if (entity == null)
            {
                result.WithErrors("Produto não encontrado.");
                return result;
            }

            _uow.GetRepository<BankAccounts>().Delete(entity);
            _uow.Commit();

            return result;
        }

        public BusinessResult<BankAccounts> GetById(int id)
        {
            var boResult = BusinessResult<BankAccounts>.CreateValidResult();

            boResult.Data = _uow.GetRepository<BankAccounts>().GetFiltered(
                new QueryCriteria<BankAccounts>()
                {
                    Expression = x => x.Id == id
                }).FirstOrDefault();

            if (boResult.Data == null)
                boResult.WithErrors("Registro não encontrado.");

            return boResult;
        }

        public BusinessResult<List<BankAccounts>> GetFiltered(QueryCriteria<BankAccounts>? query = null)
        {
            if (query == null)
                query = new QueryCriteria<BankAccounts>() { };

            if (!query.IgnoreNavigation && (query.Navigation == null || !query.Navigation.Any()))
                query.Navigation = new List<string>();

            var boResult = BusinessResult<List<BankAccounts>>.CreateValidResult();
            boResult.Data = _uow.GetRepository<BankAccounts>().GetFiltered(query).ToList();
            return boResult;
        }
    }
}
