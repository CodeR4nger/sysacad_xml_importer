using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;

namespace XMLDataImporter.Data
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {

    }

        
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            Env.Load();

            string connectionString = $"Host={Env.GetString("POSTGRES_HOST")};" +
                                    $"Username={Env.GetString("POSTGRES_USER")};" +
                                    $"Password={Env.GetString("POSTGRES_PASSWORD")};" +
                                    $"Database={Env.GetString("POSTGRES_DB")};";

            optionsBuilder.UseNpgsql(connectionString);

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
