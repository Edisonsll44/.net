using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class InventoryContext: DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<InputOutputEntity> InOuts { get; set; }
        public DbSet<WherehouseEntity> Wherehouses { get; set; }
        public DbSet<StorageEntity> Storages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server= IPS109\MSSQLSERVER01; Database = InventoryDb; User Id = inps; Password=AmadoDios87*");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity { CategoryId= "ASG", CategoryName="Aseo hogar"},
                new CategoryEntity { CategoryId = "ASD", CategoryName = "Aseo personal" },
                new CategoryEntity { CategoryId = "ASS", CategoryName = "Hogar" },
                new CategoryEntity { CategoryId = "ASW", CategoryName = "Perfumeriar" },
                new CategoryEntity { CategoryId = "ASV", CategoryName = "Salud" },
                new CategoryEntity { CategoryId = "ASN", CategoryName = "Video Juegos" }
                );

            modelBuilder.Entity<WherehouseEntity>().HasData(
                new WherehouseEntity { WherehouseId = Guid.NewGuid().ToString(), WherehouseName = "Bodega central", WherehouseAddress ="Calle 8 con 23"},
                new WherehouseEntity { WherehouseId = Guid.NewGuid().ToString(), WherehouseName = "Bodega norte", WherehouseAddress = "Calle 10 con Occidente" }
                );
        }
    }
}
