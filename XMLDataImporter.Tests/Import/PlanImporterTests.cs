using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Import;
using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Tests.Utils;

namespace XMLDataImporter.Tests.Import;

[Collection("SequentialTests")]
public class PlanImporterTests : BaseTestDB
{
    private readonly string TestFilePath = "testPlanes.xml";
    private readonly PlanService Service;

    public PlanImporterTests()
    {
        Service = new PlanService(new Repositories.PlanRepository(Context));
    }
    public override void Dispose()
    {
        if (File.Exists(TestFilePath))
            File.Delete(TestFilePath);
        base.Dispose();
        GC.SuppressFinalize(this);
    }
    private Plan CreateTestXML()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var entity = TestDataFactory.CreatePlan();
        entity.Id = 5;
        entity.Especialidad.Id = 6;
        entity.EspecialidadId = 6;
        var especialidadService = new EspecialidadService(new Repositories.EspecialidadRepository(Context));
        especialidadService.Create(entity.Especialidad);
        PlanWrapper entities = new()
        {
            Planes = [entity]
        };
        XmlSerializer serializer = new(typeof(PlanWrapper));
        using (var writer = new StreamWriter(TestFilePath, false, Encoding.GetEncoding(1252)))
        {
            serializer.Serialize(writer, entities);
        }
        return entity;
    }
    private static void CheckEntity(Plan original, Plan? searched)
    {
        Assert.NotNull(searched);
        Assert.Equal(original.Nombre, searched.Nombre);
        Assert.Equivalent(original.Especialidad, searched.Especialidad);
    }
    [Fact]
    public void CanImportXML()
    {
        var originalPlan = CreateTestXML();
        var importer = new PlanImporter(Service);
        importer.Import(TestFilePath);
        Plan? searchedPlan = Service.SearchAll().First();
        CheckEntity(originalPlan, searchedPlan);
    }
    [Fact]
    public void CanImportWhenDuplicated()
    {
        var originalPlan = CreateTestXML();
        Service.Create(originalPlan);
        var importer = new PlanImporter(Service);
        importer.Import(TestFilePath);
        Plan? searchedPlan = Service.SearchAll().First();
        CheckEntity(originalPlan, searchedPlan);
    }
}