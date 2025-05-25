using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Repositories;
using XMLDataImporter.Tests.Utils;

namespace XMLDataImporter.Tests.Models;

public class OrientacionTests : EntityTestBase<Orientacion, OrientacionService>
{
    public OrientacionTests()
        : base(ctx => new OrientacionService(new OrientacionRepository(ctx))) { }

    protected override Orientacion CreateEntity() => TestDataFactory.CreateOrientacion();

    protected override void CheckEntity(Orientacion entity)
    {
        Assert.NotNull(entity);
        Assert.Equal("Analista de Sistemas", entity.Nombre);
        Assert.Equal(1, entity.Codigo);
        Assert.NotNull(entity.Especialidad);
        Assert.Equal("Análisis de Sistemas", entity.Especialidad.Nombre);
        Assert.NotNull(entity.Plan);
        Assert.Equal("2019", entity.Plan.Nombre);
    }

    protected override Orientacion Create(Orientacion entity) => Service.Create(entity);
    protected override Orientacion? GetById(int id) => Service.SearchById(id);
    protected override IList<Orientacion> GetAll() => Service.SearchAll();
    protected override Orientacion Update(Orientacion entity) => Service.Update(entity);
    protected override bool Delete(int id) => Service.DeleteById(id);
    protected override int GetId(Orientacion entity) => entity.Id;
    protected override void ModifyEntity(Orientacion entity)
    {
        entity.Nombre = "Analista Universitario de Sistemas";
    }
    protected override void CheckUpdatedEntity(Orientacion entity)
    {
        Assert.Equal("Analista Universitario de Sistemas", entity.Nombre);
    }
}