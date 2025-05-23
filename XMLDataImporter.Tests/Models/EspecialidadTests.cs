using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Repositories;
using XMLDataImporter.Tests.Utils;

namespace XMLDataImporter.Tests.Models;

public class EspecialidadTests : EntityTestBase<Especialidad, EspecialidadService>
{
    public EspecialidadTests()
        : base(ctx => new EspecialidadService(new EspecialidadRepository(ctx))) { }

    protected override Especialidad CreateEntity() => TestDataFactory.CreateEspecialidad();

    protected override void CheckEntity(Especialidad entity)
    {
        Assert.Equal("Análisis de Sistemas", entity.Nombre);
    }

    protected override Especialidad Create(Especialidad entity) => Service.Create(entity);
    protected override Especialidad? GetById(int id) => Service.SearchById(id);
    protected override IList<Especialidad> GetAll() => Service.SearchAll();
    protected override Especialidad Update(Especialidad entity) => Service.Update(entity);
    protected override bool Delete(int id) => Service.DeleteById(id);
    protected override int GetId(Especialidad entity) => entity.Id;
    protected override void ModifyEntity(Especialidad entity)
    {
        entity.Nombre = "Bioingeniería";
    }
    protected override void CheckUpdatedEntity(Especialidad entity)
    {
        Assert.Equal("Bioingeniería", entity.Nombre);
    }
}