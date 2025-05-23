using XMLDataImporter.Data;
using XMLDataImporter.Models;

namespace XMLDataImporter.Repositories;

///<summary> Repositorio para la entidad Plan. </summary>
public class PlanRepository(DatabaseContext context) : BaseModelRepository<Plan>(context)
{
    
}