using ExpenseManagement.Shared.Entities;
using ExpenseManagement.Shared.Interfaces.Data;
using ExpenseManagement.Shared.Interfaces.Services;
using ExpenseManagement.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Services.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IUnitOfWork _uow;

        public ExpenseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public BusinessResult<Expense> Add(Expense expense)
        {
            var result = BusinessResult<Expense>.CreateValidResult(expense);

            expense.CreatedAt = DateTime.Now;
            result.Data = _uow.GetRepository<Expense>().Add(expense);
            _uow.Commit();

            return result;
        }

        public BusinessResult<Expense> Update(Expense expense)
        {
            var result = BusinessResult<Expense>.CreateValidResult();

            var entity = _uow.GetRepository<Expense>().GetFiltered(new QueryCriteria<Expense>()
            {
                Expression = x => (x.Id == expense.Id)
            }).FirstOrDefault();

            if (entity == null)
            {
                result.WithErrors("Registro não encontrado.");
                return result;
            }

            entity.Description = expense.Description;
            entity.Amount = expense.Amount;
            entity.IsPaid = expense.IsPaid;
            entity.ExpenseDate = expense.ExpenseDate;
            entity.CategoryId = expense.CategoryId;

            result.Data = _uow.GetRepository<Expense>().Update(entity);
            _uow.Commit();

            return result;
        }

        public BusinessResult<bool> Delete(int id)
        {
            var result = BusinessResult<bool>.CreateValidResult();
            var entity = _uow.GetRepository<Expense>().GetById(id);
            if (entity == null)
            {
                result.WithErrors("Produto não encontrado.");
                return result;
            }

            _uow.GetRepository<Expense>().Delete(entity);
            _uow.Commit();

            return result;
        }

        public BusinessResult<Expense> GetById(int id)
        {
            var boResult = BusinessResult<Expense>.CreateValidResult();

            boResult.Data = _uow.GetRepository<Expense>().GetFiltered(
                new QueryCriteria<Expense>()
                {
                    Expression = x => x.Id == id,
                    Navigation = new List<string>() { "Category" }
                }).FirstOrDefault();

            if (boResult.Data == null)
                boResult.WithErrors("Registro não encontrado.");

            return boResult;
        }

        public BusinessResult<List<Expense>> GetFiltered(QueryCriteria<Expense>? query = null)
        {
            if (query == null)
                query = new QueryCriteria<Expense>() { };

            if (!query.IgnoreNavigation && (query.Navigation == null || !query.Navigation.Any()))
                query.Navigation = new List<string>() { "Category" };

            var boResult = BusinessResult<List<Expense>>.CreateValidResult();
            boResult.Data = _uow.GetRepository<Expense>().GetFiltered(query).ToList();
            return boResult;
        }

        public PagingResult<List<Expense>> GetPaginated(int limit = 50, int offset = 1, QueryCriteria<Expense>? query = null)
        {
            var resultBo = PagingResult<List<Expense>>.CreateValidResultPaging();
            if (offset == 0)
            {
                resultBo.WithErrors("Houve um problema ao buscar os dados!");
                return resultBo;
            }

            var queryCriteria = new QueryCriteria<Expense>()
            {
                Limit = limit,
                Offset = offset,
                Ascending = false,
                OrderBy = x => x.Id,
                Navigation = new List<string>() { "Category" }
            };

            var queryCriteriaCount = new QueryCriteria<Expense>();

            if (query != null)
            {
                queryCriteria.Expression = query.Expression;
                queryCriteriaCount.Expression = query.Expression;
            }

            var repository = _uow.GetRepository<Expense>();
            var result = repository.GetPaged(queryCriteria).ToList();
            var totalCount = repository.GetCount(queryCriteriaCount);

            var pageResult = new PageResult()
            {
                Limit = limit,
                Offset = offset,
                TotalCount = totalCount
            };

            resultBo = PagingResult<List<Expense>>.CreateValidResultPaging(result, pageResult);

            return resultBo;
        }

        public BusinessResult<Expense> ConfirmPayment(int id)
        {
            var boResult = BusinessResult<Expense>.CreateValidResult();

            var expense = _uow.GetRepository<Expense>().GetById(id);

            if (expense == null)
                return BusinessResult<Expense>.CreateInvalidResult("Registro não encontrado.");
            
            expense.IsPaid = 1;
            expense.LastModifiedAt = DateTime.Now;

            _uow.GetRepository<Expense>().Update(expense);
            _uow.Commit();

            return BusinessResult<Expense>.CreateValidResult(expense);
        }
    }
}
