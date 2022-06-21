using administrador.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace administrador.Persistence.Database
{
    public class RCVDbContext : DbContext, IRCVDbContext
    {
        public RCVDbContext()
        {
        }

        public RCVDbContext(DbContextOptions<RCVDbContext> options) : base(options)
        {
        }
        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
             {
                 optionsBuilder.UseNpgsql(
                     "Server=migrations;Database=postgres;Port=5432;Username=postgres;Password=admin");
             }*/
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Generar un uuid cuando creas un registro en una entidad
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.Entity<AseguradoEntity>()
                .Property(id => id.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();
            modelBuilder.Entity<CarrosEntity>()
                .Property(serial => serial.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();
            modelBuilder.Entity<IncidentesEntity>()
                .Property(registro => registro.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();
            modelBuilder.Entity<PolizaEntity>()
                .Property(registro => registro.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();
            modelBuilder.Entity<UsuariosEntity>()
                .Property(dni => dni.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();
        }
        
        public virtual DbSet<AseguradoEntity> asegurado { get; set; }
        public virtual DbSet<CarrosEntity> cars { get; set; }
        public virtual DbSet<IncidentesEntity> incident { get; set; }
        public virtual DbSet<PolizaEntity> poliza { get; set; }
        public virtual DbSet<UsuariosEntity> user { get; set; }
    }
}