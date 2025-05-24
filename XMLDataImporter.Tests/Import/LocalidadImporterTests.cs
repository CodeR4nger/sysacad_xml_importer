using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Import;
using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Tests.Utils;

namespace XMLDataImporter.Tests.Import;

public class LocalidadImporterTests : BaseTestDB
{
    private readonly string TestFilePath = "testLocalidades.xml";
    private readonly LocalidadService Service;

    public LocalidadImporterTests()
    {
        Service = new LocalidadService(new Repositories.LocalidadRepository(Context));
    }
    public override void Dispose()
    {
        if (File.Exists(TestFilePath))
            File.Delete(TestFilePath);
        base.Dispose();
        GC.SuppressFinalize(this);
    }
    private Localidad CreateTestXML()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var entity = TestDataFactory.CreateLocalidad();
        entity.Id = 5;
        LocalidadWrapper entities = new()
        {
            Localidades = [entity]
        };
        XmlSerializer serializer = new(typeof(LocalidadWrapper));
        using (var writer = new StreamWriter(TestFilePath,false,Encoding.GetEncoding(1252)))
        {
            serializer.Serialize(writer, entities);
        }
        return entity;
    }
    private static void CheckEntity(Localidad original,Localidad? searched)
    {
        Assert.NotNull(searched);
        Assert.Equivalent(original,searched);
    }
    [Fact]
    public void CanImportXML()
    {
        var originalLocalidad = CreateTestXML();
        var importer = new LocalidadImporter(Service);
        importer.Import(TestFilePath);
        Localidad? searchedLocalidad = Service.SearchById(originalLocalidad.Id);
        CheckEntity(originalLocalidad, searchedLocalidad);
    }
}