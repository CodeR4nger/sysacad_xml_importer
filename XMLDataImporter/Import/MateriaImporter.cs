using System.Text;
using System.Xml.Serialization;
using XMLDataImporter.Models;
using XMLDataImporter.Services;

namespace XMLDataImporter.Import;

public class MateriaImporter(MateriaService Service)
{
    public void Import(string path)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        string xmlData = File.ReadAllText(path, Encoding.GetEncoding(1252));
        XmlSerializer serializer = new(typeof(MateriaWrapper));
        using (StringReader reader = new(xmlData))
        {
            MateriaWrapper data = (MateriaWrapper)serializer.Deserialize(reader)!;
            foreach (var entity in data.Materias)
            {
                var existing = Service.SearchById(entity.Id);
                if (existing == null) {
                    Service.Create(entity);
                }
                else
                {
                    existing.Id = entity.Id;
                    existing.Nombre = entity.Nombre;
                    existing.Ano = entity.Ano;
                    existing.EspecialidadId = entity.EspecialidadId;
                    existing.PlanId = entity.PlanId;
                    Service.Update(existing);
                }
            }
        }
    }
}