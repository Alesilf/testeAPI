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
    internal class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                .IsRequired()
                .HasColumnName("NOME")
                .HasColumnType("VARCHAR(150)");

            builder.Property(prop => prop.Cpf)
               .IsRequired()
               .HasColumnName("CPF")
               .HasColumnType("varchar(14)");

            builder.Property(prop => prop.Uf)
                .IsRequired()
                .HasColumnName("UF")
                .HasColumnType("VARCHAR(2)");

            builder.Property(prop => prop.Celular)
                .IsRequired()
                .HasColumnName("CELULAR")
                .HasColumnType("VARCHAR(11)");
        }
    }
}
