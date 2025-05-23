
using XMLDataImporter.Models;
using XMLDataImporter.Repositories;

namespace XMLDataImporter.Services;



///<summary> Servicio para la entidad Orientacion. </summary>

public class OrientacionService : BaseModelService<Orientacion>
{
    public OrientacionService(OrientacionRepository repository) : base(repository)
    {
    }
}
