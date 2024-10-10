using CasaInteligente.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaInteligente.Data.Contexts;

public class DatabaseContext : DbContext
{
    public virtual DbSet<CasaModel> Casas { get; set; }
    public virtual DbSet<DispositivoSegModel> Dispositivos { get; set; }
    public virtual DbSet<EventoDeEmergenciaModel> Eventos { get; set; }
    public virtual DbSet<UsuarioModel> Usuarios { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UsuarioModel>(entity =>
        {
            entity.ToTable("Usuarios");
            entity.HasKey(e => e.UsuarioId);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Nome).HasMaxLength(60).IsRequired();
            entity.Property(e => e.Telefone).HasColumnType("NUMBER(11)");
            
        });
        
        modelBuilder.Entity<CasaModel>(entity =>
        {
            entity.ToTable("Casas");
            entity.HasKey(e => e.CasaId);
            entity.Property(e => e.Cep).IsRequired();
            entity.Property(e => e.Endereco).HasMaxLength(50).IsRequired();
            entity.HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.UsuarioId);
        });
        
        modelBuilder.Entity<EventoDeEmergenciaModel>(entity =>
        {
            entity.ToTable("Eventos");
            entity.HasKey(e => e.EventoId);
            entity.Property(e => e.Tipo).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Mensagem).IsRequired().HasMaxLength(100);
            entity.Property(e => e.DataEvento).HasColumnType("DATE");
            entity.HasOne(e => e.Dispositivos)
                .WithMany().HasForeignKey(e=> e.DispositivoId);
        });

        modelBuilder.Entity<DispositivoSegModel>(entity =>
        {
            entity.ToTable("DispositivosSeg");
            entity.HasKey(e => e.DispositivoId);
            entity.Property(e => e.Status).IsRequired().HasMaxLength(30);
            entity.Property(e => e.Tipo).IsRequired().HasMaxLength(30);
            entity.Property(e => e.LocalInstalacao).IsRequired().HasMaxLength(50);
            entity.HasOne(e => e.Casa)
                .WithMany()
                .HasForeignKey(e => e.CasaId);
            entity.HasOne(e => e.Evento)
                .WithOne(e => e.Dispositivos);

        });
        
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    protected DatabaseContext()
    {
    }
}