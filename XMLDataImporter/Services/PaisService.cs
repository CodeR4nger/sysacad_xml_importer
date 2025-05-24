
using XMLDataImporter.Models;
using XMLDataImporter.Repositories;

namespace XMLDataImporter.Services;



///<summary> Servicio para la entidad Pais. </summary>

public class PaisService(PaisRepository repository) : BaseModelService<Pais>(repository)
{
    public Pais? SearchByNombre(string nombre) => (repository as PaisRepository)?.SearchByNombre(nombre);
}
