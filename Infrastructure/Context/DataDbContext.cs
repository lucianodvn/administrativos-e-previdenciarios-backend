using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContasAPagar>()
                .HasOne(p => p.Fornecedor)
                .WithMany()
                .HasForeignKey(p => p.IdFornecedor);

            modelBuilder.Entity<ContasAPagar>()
                .HasOne(p => p.FornecedorEmpresa)
                .WithMany()
                .HasForeignKey(p => p.IdFornecedorEmpresa);

            modelBuilder.Entity<Cliente>()
              .HasOne(p => p.Beneficio)
              .WithMany()
              .HasForeignKey(p => p.TipoBeneficioId);

            modelBuilder.Entity<Cliente>()
                .HasOne(p => p.Etapa)
                .WithMany()
                .HasForeignKey(p => p.EtapaServicoId);

            modelBuilder.Entity<FornecedorEmpresa>()
                .HasOne(p => p.Empresa)
                .WithMany()
                .HasForeignKey(p => p.IdEmpresa);

            //modelBuilder.Entity<ContasAReceber>()
            //    .HasOne(p => p.Fornecedor)
            //    .WithMany()
            //    .HasForeignKey(p => p.IdFornecedor);

            //modelBuilder.Entity<ContasAReceber>()
            //    .HasOne(p => p.Parceiro)
            //    .WithMany()
            //    .HasForeignKey(p => p.IdParceiro);

            //modelBuilder.Entity<ContasAReceber>()
            //    .HasOne(p => p.Contrato)
            //    .WithMany()
            //    .HasForeignKey(p => p.IdContratoAdm);

            //modelBuilder.Entity<ContasAReceber>()
            //    .HasOne(p => p.ContratoJudicial)
            //    .WithMany()
            //    .HasForeignKey(p => p.IdContratoJud);

            //modelBuilder
            //    .Entity<Contrato>()
            //    .Property(c => c.StatusContrato)
            //    .HasConversion(
            //        v => v.GetStatusDescricao(),
            //        v => v.ToStatusEnum().Value
            //    );

            modelBuilder
                .Entity<ContratoJudicial>()
                .Property(c => c.TipoDeContrato)
                .HasConversion(
                    v => v.GetTipoDescricao(),
                    v => v.ToTipoDeContratoEnum().Value
                );

            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId);

            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Beneficios)
                .WithMany()
                .HasForeignKey(c => c.IdBeneficioServico);

            modelBuilder.Entity<ContratoJudicial>()
                .HasOne(p => p.Parceiro)
                .WithMany()
                .HasForeignKey(p => p.IdParceiro);

            modelBuilder.Entity<ContratoJudicial>()
                .HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.IdCliente);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Parceiro> Parceiros { get; set; }
        //public DbSet<ContasAReceber> ContasAReceber { get; set; }
        public DbSet<Recibo> Recibos { get; set; }
        public DbSet<BeneficiosServicos> BeneficiosServicos { get; set; }
        public DbSet<EtapaServico> EtapaServico { get; set; }
        public DbSet<ContasAPagar> ContasAPagar { get; set; }
        public DbSet<VinculoClienteBeneficioEtapa> VinculoClienteBeneficioEtapas { get; set; }
        public DbSet<VinculoClienteParceiro> VinculoClienteParceiros { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<ContratoJudicial> ContratoJudicial { get; set; }
        public DbSet<FornecedorEmpresa> FornecedorEmpresa { get; set; }
    }
}
