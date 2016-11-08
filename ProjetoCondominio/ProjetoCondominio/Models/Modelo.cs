namespace ProjetoCondominio.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tbl_Casa> tbl_Casa { get; set; }
        public virtual DbSet<tbl_Funcionario> tbl_Funcionario { get; set; }
        public virtual DbSet<tbl_Morador> tbl_Morador { get; set; }
        public virtual DbSet<tbl_Rua> tbl_Rua { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Casa>()
                .Property(e => e.Casa)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Casa>()
                .HasMany(e => e.tbl_Funcionario)
                .WithOptional(e => e.tbl_Casa)
                .HasForeignKey(e => e.Id_Casa);

            modelBuilder.Entity<tbl_Casa>()
                .HasMany(e => e.tbl_Morador)
                .WithOptional(e => e.tbl_Casa)
                .HasForeignKey(e => e.Id_Casa);

            modelBuilder.Entity<tbl_Funcionario>()
                .Property(e => e.Nome_Funcionario)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Funcionario>()
                .Property(e => e.CPF)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Funcionario>()
                .Property(e => e.Telefone)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Funcionario>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Morador>()
                .Property(e => e.Nome_Morador)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Morador>()
                .Property(e => e.CPF)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Morador>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Morador>()
                .Property(e => e.Telefone)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Rua>()
                .Property(e => e.Rua)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Rua>()
                .HasMany(e => e.tbl_Casa)
                .WithRequired(e => e.tbl_Rua)
                .HasForeignKey(e => e.Id_Rua)
                .WillCascadeOnDelete(false);
        }
    }
}
