
using XMLDataImporter.Models;
using XMLDataImporter.Repositories;

namespace XMLDataImporter.Services;



///<summary> Servicio para la entidad Plan. </summary>

public class PlanService : BaseModelService<Plan>
{
    private readonly PlanRepository Repository;
    public PlanService(PlanRepository repository) : base(repository)
    {
        Repository = repository;
    }
    public Plan? GetByPlanIdAndEspecialidadId(int Codigo, int EspecialidadId)
    {
        return Repository.GetByPlanIdAndEspecialidadId(Codigo, EspecialidadId);
    }
}
