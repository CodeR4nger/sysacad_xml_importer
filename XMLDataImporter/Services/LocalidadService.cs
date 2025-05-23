
using XMLDataImporter.Models;
using XMLDataImporter.Repositories;

namespace XMLDataImporter.Services;



///<summary> Servicio para la entidad Localidad. </summary>

public class LocalidadService : BaseModelService<Localidad>
{
    public LocalidadService(LocalidadRepository repository) : base(repository)
    {
    }
}
