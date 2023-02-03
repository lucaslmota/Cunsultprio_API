using ConsultorioCore.Domain;
using ConsultorioCore.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioData.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(x => x.Nome).HasMaxLength(150);
            builder.Property(x => x.Sexo).HasConversion(
                y => y.ToString(),
                z => (ESexo)Enum.Parse(typeof(ESexo), z));
        }
    }
}
