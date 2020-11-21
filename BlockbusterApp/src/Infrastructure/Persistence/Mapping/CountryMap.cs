using BlockbusterApp.src.Domain.CountryAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Persistence.Mapping
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .Property(c => c.id)
                .HasColumnName("id")
                .HasColumnType("nvarchar(40)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CountryId(v)
                )
                .IsRequired();

            builder
                .Property(c => c.code)
                .HasColumnName("code")
                .HasColumnType("nvarchar(10)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CountryCode(v)
                )
                .IsRequired();

            builder
                .Property(c => c.tax)
                .HasColumnName("tax")
                .HasColumnType("nvarchar(10)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CountryTax(v)
                )
                .IsRequired();
            
        }
    }
}
