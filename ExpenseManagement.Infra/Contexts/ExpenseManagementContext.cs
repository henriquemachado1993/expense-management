using Duende.IdentityServer.EntityFramework.Options;
using ExpenseManagement.Shared.Entities;
using ExpenseManagement.Infra.Mappings;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ExpenseManagement.Infra.Contexts
{
    public class ExpenseManagementContext : ApiAuthorizationDbContext<User>
    {
        public ExpenseManagementContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Method intentionally left empty.
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new BankAccountsMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new ExpenseMap());
        }
    }
}
