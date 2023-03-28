using Backend_Angular_Crud_Operation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Angular_Crud_Operation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Student> students { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(s => s.State == EntityState.Deleted))
            {
                
                entry.State = EntityState.Modified;
                entry.CurrentValues.SetValues(new { IsDelete = true });
            }

            return base.SaveChanges();
        }

    }
}
