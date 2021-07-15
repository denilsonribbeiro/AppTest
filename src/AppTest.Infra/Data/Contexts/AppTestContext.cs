using AppTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppTest.Infra.Contexts
{
    public class AppTestContext: DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

        public AppTestContext(DbContextOptions options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppTestContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
