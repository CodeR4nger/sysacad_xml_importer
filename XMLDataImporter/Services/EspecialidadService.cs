
using XMLDataImporter.Models;
using XMLDataImporter.Repositories;

namespace XMLDataImporter.Services;



///<summary> Servicio para la entidad Especialidad. </summary>

public class EspecialidadService : BaseModelService<Especialidad>
{
    public EspecialidadService(EspecialidadRepository repository) : base(repository)
    {
    }
}
