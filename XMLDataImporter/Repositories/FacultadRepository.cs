using XMLDataImporter.Data;
using XMLDataImporter.Models;

namespace XMLDataImporter.Repositories;

///<summary> Repositorio para la entidad Facultad. </summary>
public class FacultadRepository(DatabaseContext context) : BaseModelRepository<Facultad>(context)
{
}