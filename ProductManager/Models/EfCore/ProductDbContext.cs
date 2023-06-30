using Microsoft.EntityFrameworkCore;
using ProductManager.Models.Entity;

namespace ProductManager.Models.EfCore
{
    public class ProductDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ProductManager;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(70);
            modelBuilder.Entity<Product>().Property(p => p.Code).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Code).HasMaxLength(30);
            modelBuilder.Entity<Product>().Property(p => p.Stok).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(9,2);
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id= 1,
                Code="PRZKÇ2L",
                Name= "Porçöz Kireç Çözücü 2 L",
                Stok=50,
                Price=54.90M
            },
            new Product
            {
                Id = 2,
                Code = "CNGBTR45",
                Name = "Eti Canga Bitter 45 G",
                Stok = 253,
                Price = 6M
            },
            new Product
            {
                Id = 3,
                Code = "TCRCHS450",
                Name = "Taciroğlu Koyun Peynir 3 Dilimli 450 G\r\n",
                Stok = 176,
                Price = 115.90M
            }
            );
        }
    }
}
