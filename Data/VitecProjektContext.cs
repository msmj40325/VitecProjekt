using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VitecProjekt.Models
{
    public class VitecProjektContext : DbContext
    {
        public VitecProjektContext (DbContextOptions<VitecProjektContext> options)
            : base(options)
        {
        }

        public DbSet<VitecProjekt.Models.Product> Product { get; set; }
    }
}
