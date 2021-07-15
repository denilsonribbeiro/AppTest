using AppTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest.Infra.Config
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
            builder.Property(c => c.DataNascimento).HasColumnType("datetime");
            builder.Property(c => c.Sexo);
            builder.Property(c => c.Idade);
            builder.Property(c => c.IsAtivo);
            builder.Property(c => c.CriadoEm).HasColumnType("datetime");
            builder.Property(c => c.AtualizadoEm).HasColumnType("datetime");
        }
    }
}
