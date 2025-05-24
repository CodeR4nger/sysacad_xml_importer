using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Import;
using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Tests.Utils;

namespace XMLDataImporter.Tests.Import;

[Collection("SequentialTests")]
public class FacultadImporterTests : BaseTestDB
{
    private readonly string TestFilePath = "testFacultades.xml";
    private readonly FacultadService Service;

    public FacultadImporterTests()
    {
        Service = new FacultadService(new Repositories.FacultadRepository(Context));
    }
    public override void Dispose()
    {
        if (File.Exists(TestFilePath))
            File.Delete(TestFilePath);
        base.Dispose();
        GC.SuppressFinalize(this);
    }
    private Facultad CreateTestXML()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var especialidad = TestDataFactory.CreateFacultad();
        especialidad.Id = 5;
        FacultadWrapper especialidades = new()
        {
            Facultades = [especialidad]
        };
        XmlSerializer serializer = new(typeof(FacultadWrapper));
        using (var writer = new StreamWriter(TestFilePath, false, Encoding.GetEncoding(1252)))
        {
            serializer.Serialize(writer, especialidades);
        }
        return especialidad;
    }
    private static void CheckEntity(Facultad original, Facultad? searched)
    {
        Assert.NotNull(searched);
        Assert.Equal(original.Nombre, searched.Nombre);
    }
    [Fact]
    public void CanImportXML()
    {
        var originalFacultad = CreateTestXML();
        var importer = new FacultadImporter(Service);
        importer.Import(TestFilePath);
        Facultad? searchedFacultad = Service.SearchById(originalFacultad.Id);
        CheckEntity(originalFacultad, searchedFacultad);
    }
    [Fact]
    public void CanImportWhenDuplicated()
    {
        var originalFacultad = CreateTestXML();
        var importer = new FacultadImporter(Service);
        Service.Create(originalFacultad);
        importer.Import(TestFilePath);
        Facultad? searchedFacultad = Service.SearchById(originalFacultad.Id);
        CheckEntity(originalFacultad, searchedFacultad);
    }
}