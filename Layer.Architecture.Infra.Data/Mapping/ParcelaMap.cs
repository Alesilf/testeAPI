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
    internal class ParcelaMap : IEntityTypeConfiguration<Parcela>
    {
        public void Configure(EntityTypeBuilder<Parcela> builder)
        {
            builder.ToTable("PARCELA");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.IdFinanciamento)
                .IsRequired()
                .HasColumnName("ID_FINANCIAMENTO");

            builder.Property(prop => prop.NumeroParcela)
               .IsRequired()
               .HasColumnName("NUMERO_PARCELA");
            
            builder.Property(prop => prop.ValorParcela)
               .IsRequired()
               .HasColumnName("VALOR_PARCELA")
               .HasColumnType("DECIMAL(12,2)");

            builder.Property(prop => prop.DataVencimento)
                .IsRequired()
                .HasColumnName("DATA_VENCIMENTO");
            
            builder.Property(prop => prop.DataPagamento)
                .HasColumnName("DATA_PAGAMENTO");
        }
    }
}
