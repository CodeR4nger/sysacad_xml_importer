using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Repositories;

namespace XMLDataImporter.Tests.Models;

public class UniversidadTests : EntityTestBase<Universidad, UniversidadService>
{
    public UniversidadTests()
        : base(ctx => new UniversidadService(new UniversidadRepository(ctx))) { }

    protected override Universidad CreateEntity() => new()
    {
        Nombre = "Universidad Nacional del Comahue"
    };

    protected override void CheckEntity(Universidad entity)
    {
        Assert.Equal("Universidad Nacional del Comahue", entity.Nombre);
    }

    protected override Universidad Create(Universidad entity) => Service.Create(entity);
    protected override Universidad? GetById(int id) => Service.SearchById(id);
    protected override IList<Universidad> GetAll() => Service.SearchAll();
    protected override Universidad Update(Universidad entity) => Service.Update(entity);
    protected override bool Delete(int id) => Service.DeleteById(id);
    protected override int GetId(Universidad entity) => entity.Id;
    protected override void ModifyEntity(Universidad entity)
    {
        entity.Nombre = "Universidad Nacional de Cuyo";
    }
    protected override void CheckUpdatedEntity(Universidad entity)
    {
        Assert.Equal("Universidad Nacional de Cuyo", entity.Nombre);
    }
}