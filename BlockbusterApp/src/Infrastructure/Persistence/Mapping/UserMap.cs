using BlockbusterApp.src.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Persistence.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(c => c.userId)
                .HasColumnName("id")
                .HasColumnType("nvarchar(40)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserId(v)
                )
                .IsRequired();

            builder
                .Property(c => c.userEmail)
                .HasColumnName("email")
                .HasColumnType("nvarchar(60)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserEmail(v)
                )
                .IsRequired();

            builder
                .Property(c => c.userHashedPassword)
                .HasColumnName("password")
                .HasColumnType("nvarchar(100)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserHashedPassword(v)
                )
                .IsRequired();

            builder
                .Property(c => c.userFirstname)
                .HasColumnName("first_name")
                .HasColumnType("nvarchar(15)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserFirstname(v)
                )
                .IsRequired();

            builder
                .Property(c => c.userLastname)
                .HasColumnName("last_name")
                .HasColumnType("nvarchar(30)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserLastname(v)
                )
                .IsRequired();

            builder
                .Property(c => c.userCountry)
                .HasColumnName("country_code")
                .HasColumnType("nvarchar(5)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserCountry(v)
                )
                .IsRequired();

            builder
                .Property(c => c.userRole)
                .HasColumnName("role")
                .HasColumnType("nvarchar(20)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserRole(v)
                )
                .IsRequired();
        }
    }
}
