using Microsoft.EntityFrameworkCore;

namespace WebApiBoilerPlate.API.DbContexts
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }



    }
}
