using XMLDataImporter.Data;
using XMLDataImporter.Models;

namespace XMLDataImporter.Repositories;

///<summary> Repositorio para la entidad Materia. </summary>
public class MateriaRepository(DatabaseContext context) : BaseModelRepository<Materia>(context)
{
    
}