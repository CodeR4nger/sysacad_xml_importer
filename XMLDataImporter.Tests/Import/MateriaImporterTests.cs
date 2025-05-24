using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Import;
using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Tests.Utils;

namespace XMLDataImporter.Tests.Import;

public class MateriaImporterTests : BaseTestDB
{
    private readonly string TestFilePath = "testMaterias.xml";
    private readonly MateriaService Service;

    public MateriaImporterTests()
    {
        Service = new MateriaService(new Repositories.MateriaRepository(Context));
    }
    public override void Dispose()
    {
        if (File.Exists(TestFilePath))
            File.Delete(TestFilePath);
        base.Dispose();
        GC.SuppressFinalize(this);
    }
    private Materia CreateTestXML()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var entity = TestDataFactory.CreateMateria();
        entity.Id = 5;
        entity.Especialidad.Id = 6;
        entity.EspecialidadId = 6;
        entity.Plan.Id = 7;
        entity.PlanId = 7;
        var especialidadService = new EspecialidadService(new Repositories.EspecialidadRepository(Context));
        var planService = new PlanService(new Repositories.PlanRepository(Context));
        especialidadService.Create(entity.Especialidad);
        planService.Create(entity.Plan);
        MateriaWrapper entities = new()
        {
            Materias = [entity]
        };
        XmlSerializer serializer = new(typeof(MateriaWrapper));
        using (var writer = new StreamWriter(TestFilePath,false,Encoding.GetEncoding(1252)))
        {
            serializer.Serialize(writer, entities);
        }
        return entity;
    }
    private static void CheckEntity(Materia original,Materia? searched)
    {
        Assert.NotNull(searched);
        Assert.Equal(original.Nombre,searched.Nombre);
        Assert.Equal(original.Ano,searched.Ano);
        Assert.Equivalent(original.Plan,searched.Plan);
        Assert.Equivalent(original.Especialidad,searched.Especialidad);
    }
    [Fact]
    public void CanImportXML()
    {
        var originalMateria = CreateTestXML();
        var importer = new MateriaImporter(Service);
        importer.Import(TestFilePath);
        Materia? searchedMateria = Service.SearchById(originalMateria.Id);
        CheckEntity(originalMateria, searchedMateria);
    }
}