using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.ValueObjects;

namespace ExpenseManagement.Domain.Interfaces.Data
{
    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        T Add(T entity);
        Task<T> AddAsync(T entity);
        ICollection<T> AddMultiple(ICollection<T> listEntity);
        Task<ICollection<T>> AddMultipleAsync(ICollection<T> listEntity);
        void Delete(int id);
        void Delete(T entity);
        void DeleteMultiple(ICollection<T> listEntity);
        T Update(T entity);
        T GetById(int id, string navigation = "");
        IQueryable<T> GetFiltered(QueryCriteria<T> query);
        IQueryable<T> GetPaged(QueryCriteria<T> query);
        int GetCount(QueryCriteria<T> query = null);
    }
}
