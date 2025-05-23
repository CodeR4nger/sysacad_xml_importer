
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace XMLDataImporter.Models;





public class Grado
{
    [Key]
    [XmlElement("grado")]
    public int Id { get; set; }
    [Column(TypeName = "varchar(50)")]
    [XmlElement("nombre")]
    public required string Nombre { get; set; }
}
[XmlRoot("VFPData")]
public class GradoWrapper
{
    [XmlElement("_expxml")]
    public required List<Grado> Grados { get; set; }
}