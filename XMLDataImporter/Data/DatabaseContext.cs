using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using XMLDataImporter.Utils;

namespace XMLDataImporter.Data;

/// <summary>
/// Representa el contexto de la base de datos utilizado por Entity Framework Core
/// </summary>
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
    /// <summary>
    /// Constructor que permite inyectar una implementación personalizada de <see cref="IEnvironmentHandler"/>.
    /// </summary>
    public DatabaseContextFactory(IEnvironmentHandler envHandler)
    {
        _envHandler = envHandler;
        _envHandler.Load();
    }
    /// <summary>
    /// Crea una nueva instancia de <see cref="DatabaseContext"/> usando los parámetros de conexión definidos en variables de entorno.
    /// </summary>
    /// <returns>Una nueva instancia de <see cref="DatabaseContext"/>.</returns>
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

