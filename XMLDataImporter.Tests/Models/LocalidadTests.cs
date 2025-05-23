using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Repositories;
using XMLDataImporter.Tests.Utils;

namespace XMLDataImporter.Tests.Models;

public class LocalidadTests : EntityTestBase<Localidad, LocalidadService>
{
    public LocalidadTests()
        : base(ctx => new LocalidadService(new LocalidadRepository(ctx))) { }

    protected override Localidad CreateEntity() => TestDataFactory.CreateLocalidad();

    protected override void CheckEntity(Localidad entity)
    {
        Assert.NotNull(entity);
        Assert.Equal("FLORIDA", entity.Ciudad);
        Assert.Equal("Buenos Aires", entity.Provincia);
        Assert.NotNull(entity.Pais);
        Assert.Equal("AUSTRALIA", entity.Pais.Nombre);
    }

    protected override Localidad Create(Localidad entity) => Service.Create(entity);
    protected override Localidad? GetById(int id) => Service.SearchById(id);
    protected override IList<Localidad> GetAll() => Service.SearchAll();
    protected override Localidad Update(Localidad entity) => Service.Update(entity);
    protected override bool Delete(int id) => Service.DeleteById(id);
    protected override int GetId(Localidad entity) => entity.Id;
    protected override void ModifyEntity(Localidad entity)
    {
        entity.Ciudad = "MUNRO";
    }
    protected override void CheckUpdatedEntity(Localidad entity)
    {
        Assert.Equal("MUNRO", entity.Ciudad);
    }
}