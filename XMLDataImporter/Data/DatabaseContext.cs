using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using XMLDataImporter.Utils;

namespace XMLDataImporter.Data;

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        
    }

        
public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    private readonly IEnvironmentHandler _envHandler;

    public DatabaseContextFactory() : this(new EnvironmentHandler())
    {
    }

    public DatabaseContextFactory(IEnvironmentHandler envHandler)
    {
        _envHandler = envHandler;
        _envHandler.Load();
    }

    public DatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

        string connectionString = $"Host={_envHandler.Get("POSTGRES_HOST")};" +
                                  $"Username={_envHandler.Get("POSTGRES_USER")};" +
                                  $"Password={_envHandler.Get("POSTGRES_PASSWORD")};" +
                                  $"Database={_envHandler.Get("POSTGRES_DB")};";

        optionsBuilder.UseNpgsql(connectionString);

        return new DatabaseContext(optionsBuilder.Options);
    }
}

