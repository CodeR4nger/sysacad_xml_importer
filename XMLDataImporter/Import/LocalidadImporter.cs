using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Models;
using XMLDataImporter.Services;

namespace XMLDataImporter.Import;

public class LocalidadImporter(LocalidadService Service)
{
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
                var existing = Service.SearchById(entity.Id);
                if (existing == null) {
                    Service.Create(entity);
                }
                else
                {
                    existing.Id = entity.Id;
                    existing.Ciudad = entity.Ciudad;
                    existing.Provincia = entity.Provincia;
                    existing.Pais = entity.Pais;
                    Service.Update(existing);
                }
            }
        }
    }
}