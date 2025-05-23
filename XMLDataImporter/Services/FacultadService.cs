
using XMLDataImporter.Models;
using XMLDataImporter.Repositories;

namespace XMLDataImporter.Services;



///<summary> Servicio para la entidad Facultad. </summary>

public class FacultadService : BaseModelService<Facultad>
{
    public FacultadService(FacultadRepository repository) : base(repository)
    {
    }
}
