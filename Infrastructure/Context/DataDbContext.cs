using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Parceiro> Parceiros { get; set; }
        public DbSet<ContasAReceber> ContasAReceber { get; set; }
        public DbSet<Recibo> Recibos { get; set; }
        public DbSet<BeneficiosServicos> BeneficiosServicos { get; set; }
        public DbSet<EtapaServico> EtapaServico { get; set; }
    }
}
