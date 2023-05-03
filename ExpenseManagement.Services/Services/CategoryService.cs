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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;

        public CategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public BusinessResult<Category> Add(Category category)
        {
            var result = BusinessResult<Category>.CreateValidResult(category);

            category.CreatedAt = DateTime.Now;
            result.Data = _uow.GetRepository<Category>().Add(category);
            _uow.Commit();

            return result;
        }

        public BusinessResult<Category> Update(Category category)
        {
            var result = BusinessResult<Category>.CreateValidResult();

            var entity = _uow.GetRepository<Category>().GetFiltered(new QueryCriteria<Category>()
            {
                Expression = x => (x.Id == category.Id || x.Title.ToLower() == category.Title.ToLower())
            }).FirstOrDefault();

            if (entity == null)
            {
                result.WithErrors("Registro não encontrado.");
                return result;
            }

            entity.Title = category.Title;
            entity.Description = category.Description;
            entity.PathImage = "";
            entity.LastModifiedAt = DateTime.Now;

            result.Data = _uow.GetRepository<Category>().Update(entity);
            _uow.Commit();

            return result;
        }

        public BusinessResult<bool> Delete(int id)
        {
            var result = BusinessResult<bool>.CreateValidResult();
            var entity = _uow.GetRepository<Category>().GetById(id);
            if (entity == null)
            {
                result.WithErrors("Produto não encontrado.");
                return result;
            }

            // verificar se existe alguma despesa vinculada
            var countExpense = _uow.GetRepository<Expense>().GetCount(new QueryCriteria<Expense>()
            {
                Expression = x => x.Category.Id == entity.Id
            });

            if (countExpense > 0)
            {
                result.WithErrors("Não é possível deletar categorias que estão vinculados em despesas.");
                return result;
            }

            _uow.GetRepository<Category>().Delete(entity);
            _uow.Commit();

            return result;
        }

        public BusinessResult<Category> GetById(int id)
        {
            var boResult = BusinessResult<Category>.CreateValidResult();

            boResult.Data = _uow.GetRepository<Category>().GetFiltered(
                new QueryCriteria<Category>()
                {
                    Expression = x => x.Id == id
                }).FirstOrDefault();

            if (boResult.Data == null)
                boResult.WithErrors("Registro não encontrado.");

            return boResult;
        }

        public BusinessResult<List<Category>> GetFiltered(QueryCriteria<Category>? query = null)
        {
            if (query == null)
                query = new QueryCriteria<Category>() { };

            if (!query.IgnoreNavigation && (query.Navigation == null || !query.Navigation.Any()))
                query.Navigation = new List<string>() { "Expenses" };

            var boResult = BusinessResult<List<Category>>.CreateValidResult();
            boResult.Data = _uow.GetRepository<Category>().GetFiltered(query).ToList();
            return boResult;
        }
    }
}
