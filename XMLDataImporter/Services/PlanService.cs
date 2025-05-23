
using XMLDataImporter.Models;
using XMLDataImporter.Repositories;

namespace XMLDataImporter.Services;



///<summary> Servicio para la entidad Plan. </summary>

public class PlanService : BaseModelService<Plan>
{
    public PlanService(PlanRepository repository) : base(repository)
    {
    }
}
