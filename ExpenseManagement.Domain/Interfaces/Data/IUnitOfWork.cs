using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Domain.Entities;

namespace ExpenseManagement.Domain.Interfaces.Data
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Monta o repositório de acordo com a entidade
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Retorna um repositório</returns>
        IBaseRepository<T> GetRepository<T>() where T : BaseEntity;

        /// <summary>
        /// Confirma a transação
        /// </summary>
        void Commit();

        /// <summary>
        /// Confirma a transação Assincrona
        /// </summary>
        Task CommitAsync();

        /// <summary>
        /// Libera os recursos do contexto
        /// </summary>
        void Dispose();
    }
}
