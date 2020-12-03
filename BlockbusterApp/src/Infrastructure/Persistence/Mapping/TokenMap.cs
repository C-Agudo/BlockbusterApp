using BlockbusterApp.src.Domain.TokenAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Persistence.Mapping
{
    public class TokenMap : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder
                .Property(c => c.userId)
                .HasColumnName("user_id")
                .HasColumnType("nvarchar(40)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new TokenUserId(v)
                )
                .IsRequired();

            builder
                .Property(c => c.hash)
                .HasColumnName("hash")
                .HasColumnType("nvarchar(255)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new TokenHash(v)
                )
                .IsRequired();

            builder
                .Property(c => c.createdAt)
                .HasColumnName("created_at")
                .HasColumnType("nvarchar(50)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new TokenCreatedAt(v)
                )
                .IsRequired();

            builder
                .Property(c => c.updatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("nvarchar(50)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new TokenUpdatedAt(v)
                )
                .IsRequired();          
        }
    }
}

