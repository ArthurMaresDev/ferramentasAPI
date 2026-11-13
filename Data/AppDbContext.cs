using Microsoft.EntityFrameworkCore;
using ferramentasAPI.Models;

namespace ferramentasAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
            public DbSet<Ferramenta> Ferramentas { get; set; }
         
            public DbSet<Funcionario> Funcionarios { get; set; } 

    }
}

