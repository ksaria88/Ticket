using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AtencionCliente.Models;

namespace AtencionCliente.Data
{
    public class AtencionClienteContext : DbContext
    {
        public AtencionClienteContext (DbContextOptions<AtencionClienteContext> options)
            : base(options)
        {
        }

        public DbSet<AtencionCliente.Models.Cola>? Cola { get; set; }

        public DbSet<AtencionCliente.Models.Persona>? Persona { get; set; }

        public DbSet<AtencionCliente.Models.ColaPersona>? ColaPersona { get; set; }
    }
}
