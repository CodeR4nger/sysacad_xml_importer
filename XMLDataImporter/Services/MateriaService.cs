
using XMLDataImporter.Models;
using XMLDataImporter.Repositories;

namespace XMLDataImporter.Services;



///<summary> Servicio para la entidad Materia. </summary>

public class MateriaService : BaseModelService<Materia>
{
    public MateriaService(MateriaRepository repository) : base(repository)
    {
    }
}
