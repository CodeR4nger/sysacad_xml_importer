
using XMLDataImporter.Models;
using XMLDataImporter.Repositories;

namespace XMLDataImporter.Services;



///<summary> Servicio para la entidad Universidad. </summary>

public class UniversidadService : BaseModelService<Universidad>
{
    public UniversidadService(UniversidadRepository repository) : base(repository)
    {
    }
}
