using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Models;
using XMLDataImporter.Services;

namespace XMLDataImporter.Import;

public class PlanImporter(PlanService Service)
{
    public void Import(string path)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        string xmlData = File.ReadAllText(path, Encoding.GetEncoding(1252));
        XmlSerializer serializer = new(typeof(PlanWrapper));
        using (StringReader reader = new(xmlData))
        {
            PlanWrapper data = (PlanWrapper)serializer.Deserialize(reader)!;
            foreach (var entity in data.Planes)
            {
                var existing = Service.GetByPlanIdAndEspecialidadId(entity.Codigo,entity.EspecialidadId);
                if (existing == null) {
                    Service.Create(entity);
                }
                else
                {
                    existing.Nombre = entity.Nombre;
                    existing.Codigo = entity.Codigo;
                    existing.EspecialidadId = existing.EspecialidadId;
                    Service.Update(existing);
                }
            }
        }
    }
}