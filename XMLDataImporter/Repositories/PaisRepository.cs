using XMLDataImporter.Data;
using XMLDataImporter.Models;

namespace XMLDataImporter.Repositories;

///<summary> Repositorio para la entidad Pais. </summary>
public class PaisRepository(DatabaseContext context) : BaseModelRepository<Pais>(context)
{
    
}