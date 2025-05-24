using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Models;
using XMLDataImporter.Services;

namespace XMLDataImporter.Import;

public class UniversidadImporter(UniversidadService Service)
{
    public void Import(string path)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        string xmlData = File.ReadAllText(path, Encoding.GetEncoding(1252));
        XmlSerializer serializer = new(typeof(UniversidadWrapper));
        using (StringReader reader = new(xmlData))
        {
            UniversidadWrapper data = (UniversidadWrapper)serializer.Deserialize(reader)!;
            foreach (var entity in data.Universidades)
            {
                var existing = Service.SearchById(entity.Id);
                if (existing == null) {
                    Service.Create(entity);
                }
                else
                {
                    existing.Id = entity.Id;
                    existing.Nombre = entity.Nombre;
                    Service.Update(existing);
                }
            }
        }
    }
}