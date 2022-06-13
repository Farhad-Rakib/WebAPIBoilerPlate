namespace WebApiBoilerPlate.API.DbContexts;

using Microsoft.EntityFrameworkCore;
using WebApiBoilerPlate.API.Entities;


public class ApplicationDbContext : DbContext
{
    protected readonly IConfiguration Configuration;
    public ApplicationDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server database
        
        options.UseNpgsql(Configuration.GetConnectionString("ShopConnectionStringDev"));
    }

    public DbSet<User> Users { get; set; }


}

