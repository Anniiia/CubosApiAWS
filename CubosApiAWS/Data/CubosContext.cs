
using CubosApiAWS.Models;
using Microsoft.EntityFrameworkCore;

namespace CubosApiAWS.Data
{
    public class CubosContext : DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options)
           : base(options) { }

        public DbSet<Cubo> Cubos { get; set; }
    }
}
