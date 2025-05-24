using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Models;
using XMLDataImporter.Services;

namespace XMLDataImporter.Import;

public class LocalidadImporter(LocalidadService Service,PaisService paisService)
{
    public Pais? GetPaisFromXMLCode(string paisString,PaisService service)
    {
        string formattedPais;
        if (paisString.Contains("Sin Definir"))
        {
            formattedPais = paisString.Replace(" Sin ","  SIN  ");
        } else {
            formattedPais = paisString.ToUpper();
        }
        Pais? pais = service.SearchByNombre(formattedPais);
        return pais;
    }
    public void Import(string path)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        string xmlData = File.ReadAllText(path, Encoding.GetEncoding(1252));
        XmlSerializer serializer = new(typeof(LocalidadWrapper));
        using (StringReader reader = new(xmlData))
        {
            LocalidadWrapper data = (LocalidadWrapper)serializer.Deserialize(reader)!;
            foreach (var entity in data.Localidades)
            {
                Pais? pais = GetPaisFromXMLCode(entity.Pais,paisService);
                if (pais == null)
                    continue;
                Localidad localidad = new()
                {
                    Id = entity.Id,
                    Ciudad = entity.Ciudad,
                    Provincia = entity.Provincia,
                    Pais = pais,
                    PaisId = pais.Id
                };
                Service.Create(localidad);
            }
        }
    }
}