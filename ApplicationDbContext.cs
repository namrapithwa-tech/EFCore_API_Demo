using EFCore_API_Demo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration configuration;
    public ApplicationDbContext(IConfiguration _configuration)
    {
        configuration = _configuration;
    }

    // DbSet properties represent collections of the entities.
    public DbSet<Course> Courses { get; set; }

    // Configure the database connection string.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // SQL Server connection string.
        optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"));
    }
}
