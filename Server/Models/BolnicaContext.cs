using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    public class BolnicaContext :DbContext
    {
        public DbSet<Bolnica> Bolnice{get;set;}
        public DbSet<Soba> Sobe{get;set;}
        public DbSet<Smena> Smene{get;set;}
        public DbSet<Lekar> Lekari{get;set;}
        public BolnicaContext(DbContextOptions options) :base(options)
        {
            
        }
    }
}