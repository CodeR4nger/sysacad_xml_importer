using XMLDataImporter.Data;
using XMLDataImporter.Models;

namespace XMLDataImporter.Repositories;

///<summary> Repositorio para la entidad Universidad. </summary>
public class UniversidadRepository(DatabaseContext context) : BaseModelRepository<Universidad>(context)
{
    
}