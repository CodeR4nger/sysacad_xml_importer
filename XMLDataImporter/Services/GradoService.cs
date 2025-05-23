
using XMLDataImporter.Models;
using XMLDataImporter.Repositories;

namespace XMLDataImporter.Services;



///<summary> Servicio para la entidad Grado. </summary>

public class GradoService : BaseModelService<Grado>
{
    public GradoService(GradoRepository repository) : base(repository)
    {
    }
}
