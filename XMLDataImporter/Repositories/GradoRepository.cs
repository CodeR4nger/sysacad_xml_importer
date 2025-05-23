using XMLDataImporter.Data;
using XMLDataImporter.Models;

namespace XMLDataImporter.Repositories;

///<summary> Repositorio para la entidad Grado. </summary>
public class GradoRepository(DatabaseContext context) : BaseModelRepository<Grado>(context)
{
}