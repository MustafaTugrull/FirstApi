using FirstApi.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.DataAccess.Concrete.EntityFramework
{
    public class FirstApiDbContext : DbContext
    {
        public FirstApiDbContext(DbContextOptions<FirstApiDbContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-AO5K0VF;Initial Catalog=YMYP4FirstApiDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(30);
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(50);
            modelBuilder.Entity<Author>().Property(a => a.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Author>().Property(a => a.LastName).HasMaxLength(50);
            modelBuilder.Entity<Book>().Property(b => b.Title).HasMaxLength(150);
            modelBuilder.Entity<Author>().Property(a => a.Email).HasMaxLength(30);
            modelBuilder.Entity<Author>().HasIndex(a => a.Email).IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

    }

}
