using XMLDataImporter.Models;
using XMLDataImporter.Repositories;

namespace XMLDataImporter.Services;

/// <summary>
/// Proporciona una clase base para servicios que gestionan operaciones CRUD sobre entidades del tipo <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">Tipo de entidad manejada por el servicio. Debe ser una clase.</typeparam>
public class BaseModelService<T>(BaseModelRepository<T> repository) where T : class
{
    protected readonly BaseModelRepository<T> _repository = repository;
    /// <summary>
    /// Crea una nueva instancia de la entidad <typeparamref name="T"/> en el repositorio.
    /// </summary>
    /// <param name="entity">Entidad a crear.</param>
    /// <returns>Entidad creada.</returns>
    public virtual T Create(T entity) => _repository.Create(entity);
    /// <summary>
    /// Busca una entidad por su identificador único.
    /// </summary>
    /// <param name="id">Identificador de la entidad.</param>
    /// <returns>Entidad encontrada o <c>null</c> si no se encuentra.</returns>
    public virtual T? SearchById(int id) => _repository.SearchById(id);
    /// <summary>
    /// Recupera todas las entidades disponibles.
    /// </summary>
    /// <returns>Lista de todas las entidades.</returns>
    public virtual List<T> SearchAll() => _repository.SearchAll();
    /// <summary>
    /// Actualiza una entidad existente.
    /// </summary>
    /// <param name="entity">Entidad con los nuevos valores.</param>
    /// <returns>Entidad actualizada.</returns>
    public virtual T Update(T entity) => _repository.Update(entity);
    /// <summary>
    /// Elimina una entidad según su identificador único.
    /// </summary>
    /// <param name="id">Identificador de la entidad a eliminar.</param>
    /// <returns><c>true</c> si la entidad fue eliminada con éxito; de lo contrario, <c>false</c>.</returns>
    public virtual bool DeleteById(int id) => _repository.DeleteById(id);
}
