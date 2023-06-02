using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Abstractions;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Services.Identity;

namespace TaskManagement.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>().HasKey(x => x.Id);
            modelBuilder.Entity<TaskList>().HasKey(x => x.Id);
            modelBuilder.Entity<TaskItem>().HasOne<TaskList>(input => input.List);
            base.OnModelCreating(modelBuilder);
        }
    }
}
