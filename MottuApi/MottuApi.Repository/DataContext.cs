global using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MottuApi.Model;

namespace MottuApi.Repository
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            // options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
            options.UseNpgsql("Host=localhost; Database=MottuDb; Username=postgres; Password=1234");
        }

        public DbSet<Motorcycle> Motorcycles { get; set; }
    }
}
