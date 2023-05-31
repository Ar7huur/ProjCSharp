using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjCsharp.Models;

namespace ProjCsharp.Context {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SalesRecord> SelesRecords { get; set; }

        public void Configure(EntityTypeBuilder<Departament> builder) {
            builder.ToTable("Departaments");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .HasColumnType("varchar(100)");

        }
        public void Configure(EntityTypeBuilder<SalesRecord> builder) {
            builder.ToTable("SalesRecords");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Date)
                .HasColumnType("varchar(10)");
            builder.Property(p => p.Amount)
             .HasColumnType("decimal(10,2)");

            builder.HasOne(p => p.Seller).WithMany();
        }

        public void Configure(EntityTypeBuilder<Seller> builder) {
            builder.ToTable("Sallers");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .HasColumnType("varchar(10)");
            builder.Property(p => p.Email)
             .HasColumnType("varchar(20)");
            builder.Property(p => p.CPF)
             .HasColumnType("varchar(20)");
            builder.Property(p => p.BaseSalary)
             .HasColumnType("decimal(10,2)");
            builder.HasOne(p => p.Departament).WithMany();
        }


    }
}
