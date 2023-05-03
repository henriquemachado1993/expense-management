using ExpenseManagement.Shared.Interfaces.Data;
using ExpenseManagement.Shared.Interfaces.Services;
using ExpenseManagement.Infra.Repositories;
using ExpenseManagement.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseManagement.Infra
{
    public class DependenciesInjector
    {
        public static void Register(IServiceCollection svcCollection)
        {
            // Services
            svcCollection.AddScoped<ICategoryService, CategoryService>();
            svcCollection.AddScoped<IBankAccountsService, BankAccountsService>();
            svcCollection.AddScoped<IExpenseService, ExpenseService>();

            // Repositories
            svcCollection.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            svcCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            svcCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
