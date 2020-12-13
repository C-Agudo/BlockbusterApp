using BlockbusterApp.src.Domain.CategoryAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Persistence.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .Property(c => c.categoryId)
                .HasColumnName("id")
                .HasColumnType("nvarchar(40)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CategoryId(v)
                )
                .IsRequired();

            builder
                .Property(c => c.categoryName)
                .HasColumnName("name")
                .HasColumnType("nvarchar(30")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CategoryName(v)
                )
                .IsRequired();
        }
    }
}
