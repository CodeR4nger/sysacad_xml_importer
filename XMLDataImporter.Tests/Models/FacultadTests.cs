using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Repositories;

namespace XMLDataImporter.Tests.Models;

public class FacultadTests : EntityTestBase<Facultad, FacultadService>
{
    public FacultadTests()
        : base(ctx => new FacultadService(new FacultadRepository(ctx))) { }

    protected override Facultad CreateEntity() => new()
    {
        Nombre = "Adjunto"
    };

    protected override void CheckEntity(Facultad entity)
    {
        Assert.Equal("Adjunto", entity.Nombre);
    }

    protected override Facultad Create(Facultad entity) => Service.Create(entity);
    protected override Facultad? GetById(int id) => Service.SearchById(id);
    protected override IList<Facultad> GetAll() => Service.SearchAll();
    protected override Facultad Update(Facultad entity) => Service.Update(entity);
    protected override bool Delete(int id) => Service.DeleteById(id);
    protected override int GetId(Facultad entity) => entity.Id;
    protected override void ModifyEntity(Facultad entity)
    {
        entity.Nombre = "Asociado";
    }
    protected override void CheckUpdatedEntity(Facultad entity)
    {
        Assert.Equal("Asociado", entity.Nombre);
    }
}