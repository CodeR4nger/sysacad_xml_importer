using XMLDataImporter.Data;
using XMLDataImporter.Models;

namespace XMLDataImporter.Repositories;

///<summary> Repositorio para la entidad Orientacion. </summary>
public class OrientacionRepository(DatabaseContext context) : BaseModelRepository<Orientacion>(context)
{
    
}