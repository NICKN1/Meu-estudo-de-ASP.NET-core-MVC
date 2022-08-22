using Microsoft.EntityFrameworkCore;

namespace Api_Teste.Models
{
    public partial class DbClienteContext : DbContext
    {
        public DbClienteContext()
        {

        }
        public DbClienteContext(DbContextOptions<DbClienteContext> options) : base(options)
        {

        }

        public DbSet<Cliente> clientes { get; set; }

        //Configuração das Informações do Banco de Dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente).HasName("PK__cliente__2HJ321GHJ321JHGH");
                entity.ToTable("Clientes_Table");
                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
                entity.Property(e => e.NomeCliente)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nome_cliente");
                entity.Property(e => e.email)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("email");
                entity.Property(e => e.Idade).HasColumnName("idade");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
