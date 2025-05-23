
using Microsoft.EntityFrameworkCore.Storage;
using XMLDataImporter.Data;

namespace XMLDataImporter.Tests.Utils;

public interface IDatabaseTestScope : IDisposable
{
    DatabaseContext Context { get; }
}

/// <summary>
/// Proporciona un contexto de base de datos para pruebas, asegurando que cada prueba se revierte al finalizar.
/// </summary>
public class BaseTestDB : IDatabaseTestScope
{
    public DatabaseContext Context { get; }
    private readonly IDbContextTransaction _transaction;

    public BaseTestDB(IDatabaseContextFactory? factory = null)
    {
        factory ??= new DatabaseContextFactory(); //Si factory es null, se crea un nuevo contexto con la implementacion por defecto
        Context = factory.CreateDbContext([]);
        Context.Database.EnsureCreated();
        _transaction = Context.Database.BeginTransaction();
    }

    /// <summary>
    /// Revierte la transacción abierta y libera los recursos asociados con el contexto de base de datos.
    /// </summary>
    public virtual void Dispose()
    {
        _transaction.Rollback();
        _transaction.Dispose();
        Context.Dispose();
    }
}


