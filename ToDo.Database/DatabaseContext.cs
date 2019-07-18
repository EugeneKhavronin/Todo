using Microsoft.EntityFrameworkCore;
using System;
using ToDo.Database.Models;

namespace ToDo.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem {Guid = Guid.NewGuid(), Name = "name1", IsComplete = true},
                new TodoItem {Guid = Guid.NewGuid(), Name = "name2", IsComplete = false},
                new TodoItem {Guid = Guid.NewGuid(), Name = "name3", IsComplete = true}
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}