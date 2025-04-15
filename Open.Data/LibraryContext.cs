using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Open.Entidades;
using System.Threading.Channels;

namespace Open.Data
{
    public class LibraryContextOpen:DbContext
    {
        public DbSet<SportHouse> SportHouses { get; set; }//DbSet me deja hacer el crud
        public DbSet<Shoe> Shoes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-SDF1NAA\\SQLEXPRESS; Initial Catalog=LibraryDb; Trusted_Connection=true; TrustServerCertificate=true;")
                .EnableSensitiveDataLogging()//Permite ver los valores en las consultas
                .LogTo(Console.WriteLine, LogLevel.Information)
                .UseLazyLoadingProxies(false);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shoe>(entity => 
            {
                entity.ToTable("Shoes");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Model).HasMaxLength(300)
                    .IsRequired();
                entity.Property(e => e.Size).IsRequired();
                entity.Property(e => e.Release).HasColumnType("Date")
                    .IsRequired();
                entity.HasIndex(e => new { e.Model, e.SportHouseId }, "IX_Shoes_Model_SportHousesId").IsUnique();
                entity.HasOne(e => e.SportHouse).WithMany(e => e.Shoes).HasForeignKey(e => e.SportHouseId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                var shoesList = new List<Shoe>
                {
                    new Shoe{Id=6,Model="Reebok Classic Leather", Release=DateOnly.FromDateTime(new DateTime(2006,10,30)), Size=44, SportHouseId=1},
                    new Shoe{Id=7,Model="Converse Chuck Taylor All Star", Release=DateOnly.FromDateTime(new DateTime(1970,10,10)), Size=42, SportHouseId=1}
                };
                entity.HasData(shoesList);
            });
        }
    }
}
