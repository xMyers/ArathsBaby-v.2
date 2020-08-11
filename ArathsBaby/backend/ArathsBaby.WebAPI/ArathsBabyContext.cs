using ArathsBaby.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArathsBaby.WebAPI
{
    public class ArathsBabyContext: DbContext
    {
        public ArathsBabyContext()
        {
        }

        public ArathsBabyContext(DbContextOptions<ArathsBabyContext> options) : base(options)
        {
        }
        
        public DbSet<Users> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
