using ConsultorioCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioData.Configuration
{
    internal class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            //Aqui é a construção da chave composta.
            builder.HasKey(x => new { x.ClienteId, x.Numero });
            // aqui diz que há 1 cliente para muitos telefones, entretanto o entityframework já enten esse relacionamento 
            //e não precisaria dessa construção abaix, mas vou deixar
            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Telefone)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
