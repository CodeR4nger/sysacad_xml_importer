using XMLDataImporter.Data;
using XMLDataImporter.Models;

namespace XMLDataImporter.Repositories;

///<summary> Repositorio para la entidad Localidad. </summary>
public class LocalidadRepository(DatabaseContext context) : BaseModelRepository<Localidad>(context)
{
    
}