using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Import;
using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Tests.Utils;

namespace XMLDataImporter.Tests.Import;

public class UniversidadImporterTests : BaseTestDB
{
    private readonly string TestFilePath = "testUniversidades.xml";
    private readonly UniversidadService Service;

    public UniversidadImporterTests()
    {
        Service = new UniversidadService(new Repositories.UniversidadRepository(Context));
    }
    public override void Dispose()
    {
        if (File.Exists(TestFilePath))
            File.Delete(TestFilePath);
        base.Dispose();
        GC.SuppressFinalize(this);
    }
    private Universidad CreateTestXML()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var entity = TestDataFactory.CreateUniversidad();
        entity.Id = 5;
        UniversidadWrapper entities = new()
        {
            Universidades = [entity]
        };
        XmlSerializer serializer = new(typeof(UniversidadWrapper));
        using (var writer = new StreamWriter(TestFilePath,false,Encoding.GetEncoding(1252)))
        {
            serializer.Serialize(writer, entities);
        }
        return entity;
    }
    private static void CheckEntity(Universidad original,Universidad? searched)
    {
        Assert.NotNull(searched);
        Assert.Equal(original.Nombre,searched.Nombre);  
    }
    [Fact]
    public void CanImportXML()
    {
        var originalUniversidad = CreateTestXML();
        var importer = new UniversidadImporter(Service);
        importer.Import(TestFilePath);
        Universidad? searchedUniversidad = Service.SearchById(originalUniversidad.Id);
        CheckEntity(originalUniversidad, searchedUniversidad);
    }
}