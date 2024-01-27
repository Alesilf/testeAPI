using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Layer.Architecture.Infra.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Financiamento> Financiamentos { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new FinanciamentoMap());
            modelBuilder.ApplyConfiguration(new ParcelaMap());
            base.OnModelCreating(modelBuilder);
        }

        protected MyContext Create(DbContextOptionsBuilder optionsBuilder)
        {
            var construtor = new DbContextOptionsBuilder<MyContext>();
            return new MyContext(construtor.Options);
        }
    }
}
