using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMonitorREST.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Process> Processes { get; set; }
        public DbSet<ClientPC> PCs { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
