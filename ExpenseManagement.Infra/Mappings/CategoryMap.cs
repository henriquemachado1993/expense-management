using ExpenseManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThayCompany.Infra.Data.Mappings;

namespace ExpenseManagement.Infra.Mappings
{
    public class CategoryMap : MapBase<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.ToTable("Category");
            builder.Property(x => x.Title).IsRequired();

            // Relationships
            builder.HasMany(x => x.Expenses);
        }
    }
}
