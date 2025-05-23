using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using XMLDataImporter.Models;
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
    public DbSet<Grado> Grados { get; set; }
    public DbSet<Especialidad> Especialidades { get; set; }
    public DbSet<Facultad> Facultades { get; set; }
    public DbSet<Universidad> Universidades { get; set; }
}

/// <summary>
/// Define un contrato para crear instancias de <see cref="DatabaseContext"/>.
/// </summary>
public interface IDatabaseContextFactory
{
    /// <summary>
    /// Crea una nueva instancia de <see cref="DatabaseContext"/>.
    /// </summary>
    /// <param name="args">Argumentos opcionales de configuración.</param>
    /// <returns>Una instancia de <see cref="DatabaseContext"/>.</returns>
    DatabaseContext CreateDbContext(string[] args);
}

public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>,IDatabaseContextFactory
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

