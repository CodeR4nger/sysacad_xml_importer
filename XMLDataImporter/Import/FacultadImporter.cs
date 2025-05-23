using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Models;
using XMLDataImporter.Services;

namespace XMLDataImporter.Import;

public class FacultadImporter(FacultadService Service)
{
    public void Import(string path)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        string xmlData = File.ReadAllText(path, Encoding.GetEncoding(1252));
        XmlSerializer serializer = new(typeof(FacultadWrapper));
        using (StringReader reader = new(xmlData))
        {
            FacultadWrapper data = (FacultadWrapper)serializer.Deserialize(reader)!;
            foreach (var grado in data.Facultades)
            {
                Service.Create(grado);
            }
        }
    }
}