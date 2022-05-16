using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Models
{
    public class CapstoneContext:DbContext
    {
        DbSet<TaiKhoan> TaiKhoans { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("MyDB"));
            }
        }
    }
}
