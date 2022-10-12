using Allocations.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Ef
{
    public class AllocationsDbContext : DbContext
    {
        public AllocationsDbContext()
        {

        }
        public AllocationsDbContext(DbContextOptions<AllocationsDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //TODO spostare stringa di connessione
            if(!options.IsConfigured)
            {
                options.UseSqlServer(@"Server=WINAPMXbbT5rXOE;Initial Catalog=AllocationsDb;Integrated Security=true;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AllocationsDbContext).Assembly);
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }


    }
}
