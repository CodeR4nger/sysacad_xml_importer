using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Repositories;
using XMLDataImporter.Tests.Utils;

namespace XMLDataImporter.Tests.Models;

public class PlanTests : EntityTestBase<Plan, PlanService>
{
    public PlanTests()
        : base(ctx => new PlanService(new PlanRepository(ctx))) { }

    protected override Plan CreateEntity() => TestDataFactory.CreatePlan();

    protected override void CheckEntity(Plan entity)
    {
        Assert.NotNull(entity);
        Assert.Equal(2019, entity.Codigo);
        Assert.Equal("2019", entity.Nombre);
        Assert.NotNull(entity.Especialidad);
        Assert.Equal("Análisis de Sistemas", entity.Especialidad.Nombre);
    }

    protected override Plan Create(Plan entity) => Service.Create(entity);
    protected override Plan? GetById(int id) => Service.SearchById(id);
    protected override IList<Plan> GetAll() => Service.SearchAll();
    protected override Plan Update(Plan entity) => Service.Update(entity);
    protected override bool Delete(int id) => Service.DeleteById(id);
    protected override int GetId(Plan entity) => entity.Id;
    protected override void ModifyEntity(Plan entity)
    {
        entity.Nombre = "2020";
    }
    protected override void CheckUpdatedEntity(Plan entity)
    {
        Assert.Equal("2020", entity.Nombre);
    }

    [Fact]
    public void CanSearchByCompositeKey()
    {
        var entity = Create(CreateEntity());
        var fetched = Service.GetByPlanIdAndEspecialidadId(entity.Codigo, entity.EspecialidadId);
        Assert.NotNull(fetched);
        CheckEntity(fetched);
    }
}