global using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
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
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<MotorcycleModel> MotorcycleModels { get; set;}
        public DbSet<Rental> Rentals { get; set;}
        public DbSet<RentalPlan> RentalsPlan { get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<DeliveryPerson> DeliveryPeople { get; set; }

        public User[] admins = new User[]
        {
            new User { Id = -100, Email = "admin@admin.com", Password="$2a$11$uLXF/MIWB7sFfvip5vhbWuAvn3fDFGrI7W8utMSefn2MIeToHHVGm", IsAdmin = true }
        };
        public RentalPlan[] reantalPlans = new RentalPlan[]
        {
            new RentalPlan { Id = 1, Days = 7, DailyPrice = 3000, DailyFinePercentage = 20, ExtraDayPrice = 5000},
            new RentalPlan { Id = 2, Days = 15, DailyPrice = 2800, DailyFinePercentage = 40, ExtraDayPrice = 5000},
            new RentalPlan { Id = 3, Days = 30, DailyPrice = 2200, DailyFinePercentage = 60, ExtraDayPrice = 5000}
        };
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(admins);
            modelBuilder.Entity<RentalPlan>().HasData(reantalPlans);
        }
    }
}
