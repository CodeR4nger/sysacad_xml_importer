using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Import;
using XMLDataImporter.Models;
using XMLDataImporter.Services;
using XMLDataImporter.Tests.Utils;

namespace XMLDataImporter.Tests.Import;

public class GradoImporterTests : BaseTestDB
{
    private readonly string TestFilePath = "testGrados.xml";
    private readonly GradoService Service;

    public GradoImporterTests()
    {
        Service = new GradoService(new Repositories.GradoRepository(Context));
    }
    public override void Dispose()
    {
        if (File.Exists(TestFilePath))
            File.Delete(TestFilePath);
        base.Dispose();
        GC.SuppressFinalize(this);
    }
    private Grado CreateTestXML()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var grado = TestDataFactory.CreateGrado();
        grado.Id = 5;
        GradoWrapper grados = new()
        {
            Grados = [grado]
        };
        XmlSerializer serializer = new(typeof(GradoWrapper));
        using (var writer = new StreamWriter(TestFilePath,false,Encoding.GetEncoding(1252)))
        {
            serializer.Serialize(writer, grados);
        }
        return grado;
    }
    private static void CheckEntity(Grado original,Grado? searched)
    {
        Assert.NotNull(searched);
        Assert.Equal(original.Nombre,searched.Nombre);  
    }
    [Fact]
    public void CanImportXML()
    {
        var originalGrado = CreateTestXML();
        var importer = new GradoImporter(Service);
        importer.Import(TestFilePath);
        Grado? searchedGrado = Service.SearchById(originalGrado.Id);
        CheckEntity(originalGrado, searchedGrado);
    }
}