using XMLDataImporter.Data;
using XMLDataImporter.Models;

namespace XMLDataImporter.Repositories;

///<summary> Repositorio para la entidad Especialidad. </summary>
public class EspecialidadRepository(DatabaseContext context) : BaseModelRepository<Especialidad>(context)
{
    
}