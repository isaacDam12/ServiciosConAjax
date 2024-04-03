using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class ServicesAjaxContext : DbContext
{
    public ServicesAjaxContext()
    {
    }

    public ServicesAjaxContext(DbContextOptions<ServicesAjaxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<RegistroPedido> RegistroPedidos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= ServicesAjax; Trusted_Connection=True; User ID=sa; Password=pass@word1; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedido__9D335DC3BBABB11F");

            entity.ToTable("Pedido");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Pedido__IdUsuari__1273C1CD");
        });

        modelBuilder.Entity<RegistroPedido>(entity =>
        {
            entity.HasKey(e => e.IdRegistro).HasName("PK__Registro__FFA45A990201D873");

            entity.ToTable("RegistroPedido");

            entity.Property(e => e.Fecha).HasColumnType("date");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.RegistroPedidos)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK__RegistroP__IdPed__15502E78");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97CD1E7DE3");

            entity.ToTable("Usuario");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
