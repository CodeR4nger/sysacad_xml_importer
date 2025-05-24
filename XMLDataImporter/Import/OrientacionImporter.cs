using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Models;
using XMLDataImporter.Services;

namespace XMLDataImporter.Import;

public class OrientacionImporter(OrientacionService Service)
{
    public void Import(string path)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        string xmlData = File.ReadAllText(path, Encoding.GetEncoding(1252));
        XmlSerializer serializer = new(typeof(OrientacionWrapper));
        using (StringReader reader = new(xmlData))
        {
            OrientacionWrapper data = (OrientacionWrapper)serializer.Deserialize(reader)!;
            foreach (var entity in data.Orientaciones)
            {
                Service.Create(entity);
            }
        }
    }
}