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
            foreach (var grado in data.Universidades)
            {
                Service.Create(grado);
            }
        }
    }
}