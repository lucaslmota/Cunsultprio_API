using ConsultorioCore.Domain;
using ConsultorioCore.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioData.Configuration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.ClienteId);
            builder.Property(x => x.Estado).HasConversion(
                y => y.ToString(),
                z => (EEstado)Enum.Parse(typeof(EEstado), z));
        }
    }
}
