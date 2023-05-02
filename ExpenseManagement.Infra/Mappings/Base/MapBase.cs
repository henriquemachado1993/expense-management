using ExpenseManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ThayCompany.Infra.Data.Mappings
{
    public class MapBase<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id");

            // Audit
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.LastModifiedAt).ValueGeneratedOnUpdate();
        }
    }
}
