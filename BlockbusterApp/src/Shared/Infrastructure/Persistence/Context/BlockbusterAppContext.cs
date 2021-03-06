﻿using System;
using BlockbusterApp.src.Domain.UserAggregate;
//using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Infrastructure.Persistence.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace BlockbusterApp.src.Shared.Infrastructure.Persistence.Context
{
    public class BlockbusterAppContext : DbContext
    {
        public BlockbusterAppContext(DbContextOptions opt) : base(opt) 
        {
            
        }

        public DbSet<User> Users { get; set; }
        //public DbSet<Token> Tokens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            //modelBuilder.ApplyConfiguration(new TokenMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
