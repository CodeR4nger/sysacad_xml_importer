
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace XMLDataImporter.Models;

public class Facultad
{
    [Key]
    [XmlElement("facultad")]
    public int Id { get; set; }
    [Column(TypeName = "varchar(50)")]
    [XmlElement("nombre")]
    public required string Nombre { get; set; }
}

[XmlRoot("VFPData")]
public class FacultadWrapper
{
    [XmlElement("_expxml")]
    public required List<Facultad> Facultades { get; set; }
}