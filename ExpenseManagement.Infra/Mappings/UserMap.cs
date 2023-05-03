using ExpenseManagement.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseManagement.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public virtual void Configure(EntityTypeBuilder<User> builder)
        {            
        }
    }
}
