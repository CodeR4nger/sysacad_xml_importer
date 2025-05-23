
using XMLDataImporter.Models;
using XMLDataImporter.Repositories;

namespace XMLDataImporter.Services;



///<summary> Servicio para la entidad Pais. </summary>

public class PaisService : BaseModelService<Pais>
{
    public PaisService(PaisRepository repository) : base(repository)
    {
    }
}
