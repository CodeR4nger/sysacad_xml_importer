using XMLDataImporter.Data;
using XMLDataImporter.Models;

namespace XMLDataImporter.Repositories;

///<summary> Repositorio para la entidad Plan. </summary>
public class PlanRepository(DatabaseContext context) : BaseModelRepository<Plan>(context)
{
    public Plan? GetByPlanIdAndEspecialidadId(int Codigo, int EspecialidadId)
    {
        return _context.Planes
            .FirstOrDefault(p => p.Codigo == Codigo && p.EspecialidadId == EspecialidadId);
    }
}