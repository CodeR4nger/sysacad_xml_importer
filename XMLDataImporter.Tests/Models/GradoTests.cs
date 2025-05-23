using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Repositories;

namespace XMLDataImporter.Tests.Models;

public class GradoTests : EntityTestBase<Grado, GradoService>
{
    public GradoTests()
        : base(ctx => new GradoService(new GradoRepository(ctx))) { }

    protected override Grado CreateEntity() => new()
    {
        Nombre = "Adjunto"
    };

    protected override void CheckEntity(Grado entity)
    {
        Assert.Equal("Adjunto", entity.Nombre);
    }

    protected override Grado Create(Grado entity) => Service.Create(entity);
    protected override Grado? GetById(int id) => Service.SearchById(id);
    protected override IList<Grado> GetAll() => Service.SearchAll();
    protected override Grado Update(Grado entity) => Service.Update(entity);
    protected override bool Delete(int id) => Service.DeleteById(id);
    protected override int GetId(Grado entity) => entity.Id;
    protected override void ModifyEntity(Grado entity)
    {
        entity.Nombre = "Asociado";
    }
    protected override void CheckUpdatedEntity(Grado entity)
    {
        Assert.Equal("Asociado", entity.Nombre);
    }
}