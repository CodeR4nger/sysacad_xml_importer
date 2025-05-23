using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Repositories;
using XMLDataImporter.Tests.Utils;

namespace XMLDataImporter.Tests.Models;

public class MateriaTests : EntityTestBase<Materia, MateriaService>
{
    public MateriaTests()
        : base(ctx => new MateriaService(new MateriaRepository(ctx))) { }

    protected override Materia CreateEntity() => TestDataFactory.CreateMateria();

    protected override void CheckEntity(Materia entity)
    {
        Assert.NotNull(entity);
        Assert.Equal("Estabilidad I", entity.Nombre);
        Assert.Equal("2", entity.Ano);
        Assert.NotNull(entity.Especialidad);
        Assert.Equal("Análisis de Sistemas", entity.Especialidad.Nombre);
        Assert.NotNull(entity.Plan);
        Assert.Equal("2019", entity.Plan.Nombre);
    }

    protected override Materia Create(Materia entity) => Service.Create(entity);
    protected override Materia? GetById(int id) => Service.SearchById(id);
    protected override IList<Materia> GetAll() => Service.SearchAll();
    protected override Materia Update(Materia entity) => Service.Update(entity);
    protected override bool Delete(int id) => Service.DeleteById(id);
    protected override int GetId(Materia entity) => entity.Id;
    protected override void ModifyEntity(Materia entity)
    {
        entity.Ano = "3";
    }
    protected override void CheckUpdatedEntity(Materia entity)
    {
        Assert.Equal("3", entity.Ano);
    }
}