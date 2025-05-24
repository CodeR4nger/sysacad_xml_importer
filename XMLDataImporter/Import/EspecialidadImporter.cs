using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Models;
using XMLDataImporter.Services;

namespace XMLDataImporter.Import;

public class EspecialidadImporter(EspecialidadService Service)
{
    public void Import(string path)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        string xmlData = File.ReadAllText(path, Encoding.GetEncoding(1252));
        XmlSerializer serializer = new(typeof(EspecialidadWrapper));
        using (StringReader reader = new(xmlData))
        {
            EspecialidadWrapper data = (EspecialidadWrapper)serializer.Deserialize(reader)!;
            foreach (var entity in data.Especialidades)
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