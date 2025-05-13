using Microsoft.EntityFrameworkCore;

namespace EventEase2.Data
{
    public class Factory
    {

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Configure your DbContext here
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=YourDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}






