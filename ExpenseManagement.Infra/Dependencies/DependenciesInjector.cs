using ExpenseManagement.Domain.Interfaces.Data;
using ExpenseManagement.Domain.Interfaces.Services;
using ExpenseManagement.Infra.Repositories;
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
            //svcCollection.AddScoped<IUserService, UserService>();

            // Repositories
            svcCollection.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            svcCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            svcCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
