using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Import;
using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Tests.Utils;

namespace XMLDataImporter.Tests.Import;

public class PaisImporterTests : BaseTestDB
{
    private readonly string TestFilePath = "testPaises.xml";
    private readonly PaisService Service;

    public PaisImporterTests()
    {
        Service = new PaisService(new Repositories.PaisRepository(Context));
    }
    public override void Dispose()
    {
        if (File.Exists(TestFilePath))
            File.Delete(TestFilePath);
        base.Dispose();
        GC.SuppressFinalize(this);
    }
    private Pais CreateTestXML()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var especialidad = TestDataFactory.CreatePais();
        especialidad.Id = 5;
        PaisWrapper especialidades = new()
        {
            Paises = [especialidad]
        };
        XmlSerializer serializer = new(typeof(PaisWrapper));
        using (var writer = new StreamWriter(TestFilePath,false,Encoding.GetEncoding(1252)))
        {
            serializer.Serialize(writer, especialidades);
        }
        return especialidad;
    }
    private static void CheckEntity(Pais original,Pais? searched)
    {
        Assert.NotNull(searched);
        Assert.Equal(original.Nombre,searched.Nombre);  
    }
    [Fact]
    public void CanImportXML()
    {
        var originalPais = CreateTestXML();
        var importer = new PaisImporter(Service);
        importer.Import(TestFilePath);
        Pais? searchedPais = Service.SearchById(originalPais.Id);
        CheckEntity(originalPais, searchedPais);
    }
}