using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Repositories;

namespace XMLDataImporter.Tests.Models;

public class PaisTests : EntityTestBase<Pais, PaisService>
{
    public PaisTests()
        : base(ctx => new PaisService(new PaisRepository(ctx))) { }

    protected override Pais CreateEntity() => new()
    {
        Nombre = "AUSTRALIA"
    };

    protected override void CheckEntity(Pais entity)
    {
        Assert.Equal("AUSTRALIA", entity.Nombre);
    }

    protected override Pais Create(Pais entity) => Service.Create(entity);
    protected override Pais? GetById(int id) => Service.SearchById(id);
    protected override IList<Pais> GetAll() => Service.SearchAll();
    protected override Pais Update(Pais entity) => Service.Update(entity);
    protected override bool Delete(int id) => Service.DeleteById(id);
    protected override int GetId(Pais entity) => entity.Id;
    protected override void ModifyEntity(Pais entity)
    {
        entity.Nombre = "AUSTRIA";
    }
    protected override void CheckUpdatedEntity(Pais entity)
    {
        Assert.Equal("AUSTRIA", entity.Nombre);
    }
}