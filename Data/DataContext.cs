using Microsoft.EntityFrameworkCore;

namespace mba.apiref
{
    public class DataContext : DbContext {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Event> Events { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Email> Emails { get; set; }
        // Necessari només quan l'aplicació és executada en mode consola - per tal que funcioni migrations add
        
    }
}