using Microsoft.EntityFrameworkCore;
using Repositories;
using Entities.Models;
using Repositories.Config;
using System.Reflection;

namespace Repositories
{
public class RepositoryContext : DbContext
    { 
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        
        }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);      

            // 1.yol      
            // modelBuilder.ApplyConfiguration(new ProductConfig());
            // modelBuilder.ApplyConfiguration(new CategoryConfig());                              
           
            //2.yol
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}