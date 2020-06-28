using EFSQLite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EFSQLite
{
    class DatabaseContext : DbContext
    {
        public DbSet<ObjectModel> ObjectModels { get; set; }
        public DbSet<ObjectTypeModel> ObjectTypeModels { get; set; }

        public DatabaseContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObjectModel>()
              .HasOne(d => d.TypeModel)
              .WithMany(dm => dm.Objects)
              .HasForeignKey(dkey => dkey.TypeId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Data\Database.sqlite");
            base.OnConfiguring(optionsBuilder);
        }

        public Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker
                  .Entries()
                  .Where(e => e.Entity is BaseEntity && (
                          e.State == EntityState.Added ||
                          e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                // overwrite `ModifiedOn` value with current date.
                ((BaseEntity)entityEntry.Entity).ModifiedOn = DateTime.Now;

                // set `CreatedOn` to current date if its not already set. 
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedOn = DateTime.Now;
                }
            }
            return base.SaveChangesAsync();
        }
    }
}
