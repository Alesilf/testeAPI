using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Layer.Architecture.Domain.Entities;

namespace Layer.Architecture.Infra.Data.Mapping
{
    internal class FinanciamentoMap : IEntityTypeConfiguration<Financiamento>
    {
        public void Configure(EntityTypeBuilder<Financiamento> builder)
        {
            builder.ToTable("FINANCIAMENTO");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Cpf)
                .IsRequired()
                .HasColumnName("CPF")
                .HasColumnType("VARCHAR(14)");

            builder.Property(prop => prop.ValorFinancimento)
               .IsRequired()
               .HasColumnName("VALOR_FINANCIAMENTO")
               .HasColumnType("DECIMAL(12,2)");

            builder.Property(prop => prop.ValorTotal)
               .IsRequired()
               .HasColumnName("VALOR_TOTAL")
               .HasColumnType("DECIMAL(12,2)");

            builder.Property(prop => prop.TipoFinanciamento)
                .IsRequired()
                .HasColumnName("TIPO_FINANCIAMENTO");

            builder.Property(prop => prop.Parcelas)
                .IsRequired()
                .HasColumnName("PARCELAS");

            builder.Property(prop => prop.DataPrimeiroVencimento)
                .IsRequired()
                .HasColumnName("DATA_PRIMEIRO_VENCIMENTO");

            builder.Property(prop => prop.DataUltimoVencimento)
                .IsRequired()
                .HasColumnName("DATA_ULTIMO_VENCIMENTO");

            builder.Property(prop => prop.StatusFinanciamento)
                .IsRequired()
                .HasColumnName("STATUS_FINANCIAMENTO")
                .HasColumnType("VARCHAR(30)");
        }
    }
}
