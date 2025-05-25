using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Import;
using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Tests.Utils;

namespace XMLDataImporter.Tests.Import;

[Collection("SequentialTests")]
public class OrientacionImporterTests : BaseTestDB
{
    private readonly string TestFilePath = "testOrientacions.xml";
    private readonly OrientacionService Service;

    public OrientacionImporterTests()
    {
        Service = new OrientacionService(new Repositories.OrientacionRepository(Context));
    }
    public override void Dispose()
    {
        if (File.Exists(TestFilePath))
            File.Delete(TestFilePath);
        base.Dispose();
        GC.SuppressFinalize(this);
    }
    private Orientacion CreateTestXML()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var entity = TestDataFactory.CreateOrientacion();
        entity.Id = 5;
        entity.Especialidad.Id = 6;
        entity.EspecialidadId = 6;
        entity.Plan.Id = 7;
        entity.Plan.EspecialidadId = 6;
        entity.Plan.Especialidad = entity.Especialidad;
        entity.PlanId = 7;
        var especialidadService = new EspecialidadService(new Repositories.EspecialidadRepository(Context));
        var planService = new PlanService(new Repositories.PlanRepository(Context));
        entity.Especialidad = especialidadService.Create(entity.Especialidad);
        entity.EspecialidadId = entity.Especialidad.Id;
        entity.Plan = planService.Create(entity.Plan);
        entity.PlanId = entity.Plan.Id;
        Orientacion testOrientacion = new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Especialidad = entity.Especialidad,
            Codigo = entity.Codigo,
            EspecialidadId = entity.EspecialidadId,
            Plan = entity.Plan,
            PlanId = entity.Plan.Codigo,
        };
        OrientacionWrapper entities = new()
        {
            Orientaciones = [testOrientacion]
        };
        XmlSerializer serializer = new(typeof(OrientacionWrapper));
        using (var writer = new StreamWriter(TestFilePath, false, Encoding.GetEncoding(1252)))
        {
            serializer.Serialize(writer, entities);
        }
        return entity;
    }
    private static void CheckEntity(Orientacion original, Orientacion? searched)
    {
        Assert.NotNull(searched);
        Assert.Equal(original.Nombre, searched.Nombre);
        Assert.Equivalent(original.Plan, searched.Plan);
        Assert.Equivalent(original.Especialidad, searched.Especialidad);
    }
    [Fact]
    public void CanImportXML()
    {
        var originalOrientacion = CreateTestXML();
        var importer = new OrientacionImporter(Service,new PlanService(new Repositories.PlanRepository(Context)));
        importer.Import(TestFilePath);
        Orientacion? searchedOrientacion = Service.SearchAll().First();
        CheckEntity(originalOrientacion, searchedOrientacion);
    }
    [Fact]
    public void CanImportWhenDuplicated()
    {
        var originalOrientacion = CreateTestXML();
        Service.Create(originalOrientacion);
        var importer = new OrientacionImporter(Service,new PlanService(new Repositories.PlanRepository(Context)));
        importer.Import(TestFilePath);
        Orientacion? searchedOrientacion = Service.SearchById(originalOrientacion.Id);
        CheckEntity(originalOrientacion, searchedOrientacion);
    }
}