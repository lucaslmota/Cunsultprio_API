using ConsultorioCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioData.Context
{
    public class ConsultorioContext : DbContext
    {
        public ConsultorioContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
