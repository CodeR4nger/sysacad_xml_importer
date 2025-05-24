using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Import;
using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Tests.Utils;

namespace XMLDataImporter.Tests.Import;

[Collection("SequentialTests")]
public class EspecialidadImporterTests : BaseTestDB
{
    private readonly string TestFilePath = "testEspecialidades.xml";
    private readonly EspecialidadService Service;

    public EspecialidadImporterTests()
    {
        Service = new EspecialidadService(new Repositories.EspecialidadRepository(Context));
    }
    public override void Dispose()
    {
        if (File.Exists(TestFilePath))
            File.Delete(TestFilePath);
        base.Dispose();
        GC.SuppressFinalize(this);
    }
    private Especialidad CreateTestXML()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var especialidad = TestDataFactory.CreateEspecialidad();
        especialidad.Id = 5;
        EspecialidadWrapper especialidades = new()
        {
            Especialidades = [especialidad]
        };
        XmlSerializer serializer = new(typeof(EspecialidadWrapper));
        using (var writer = new StreamWriter(TestFilePath, false, Encoding.GetEncoding(1252)))
        {
            serializer.Serialize(writer, especialidades);
        }
        return especialidad;
    }
    private static void CheckEntity(Especialidad original, Especialidad? searched)
    {
        Assert.NotNull(searched);
        Assert.Equal(original.Nombre, searched.Nombre);
    }
    [Fact]
    public void CanImportXML()
    {
        var originalEspecialidad = CreateTestXML();
        var importer = new EspecialidadImporter(Service);
        importer.Import(TestFilePath);
        Especialidad? searchedEspecialidad = Service.SearchById(originalEspecialidad.Id);
        CheckEntity(originalEspecialidad, searchedEspecialidad);
    }
    [Fact]
    public void CanImportWhenDuplicated()
    {
        var originalEspecialidad = CreateTestXML();
        Service.Create(originalEspecialidad);
        var importer = new EspecialidadImporter(Service);
        importer.Import(TestFilePath);
        Especialidad? searchedEspecialidad = Service.SearchById(originalEspecialidad.Id);
        CheckEntity(originalEspecialidad, searchedEspecialidad);
    }
}