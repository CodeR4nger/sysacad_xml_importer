using System.Globalization;
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
    private readonly PaisService paisService;

    public LocalidadImporterTests()
    {
        Service = new LocalidadService(new Repositories.LocalidadRepository(Context));
        paisService = new PaisService(new Repositories.PaisRepository(Context));
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
        entity.PaisId = 6;
        entity.Pais.Id = 6;

        paisService.Create(entity.Pais);
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        LocalidadXML localidadXML = new()
        {
            Id = entity.Id,
            Ciudad = entity.Ciudad,
            Provincia = entity.Provincia,
            Pais = textInfo.ToTitleCase(entity.Pais.Nombre.ToLower())
        };
        LocalidadWrapper entities = new()
        {
            Localidades = [localidadXML]
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
        Assert.Equivalent(original.Pais,searched.Pais);
    }
    [Fact]
    public void CanImportXML()
    {
        var originalLocalidad = CreateTestXML();
        var importer = new LocalidadImporter(Service,paisService);
        importer.Import(TestFilePath);
        Localidad? searchedLocalidad = Service.SearchById(originalLocalidad.Id);
        CheckEntity(originalLocalidad, searchedLocalidad);
    }
}