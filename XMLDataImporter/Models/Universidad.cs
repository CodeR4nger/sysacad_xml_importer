
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace XMLDataImporter.Models;

public class Universidad
{
    [Key]
    [XmlElement("universida")]
    public int Id { get; set; }
    [Column(TypeName = "varchar(50)")]
    [XmlElement("nombre")]
    public required string Nombre { get; set; }
}

[XmlRoot("VFPData")]
public class UniversidadWrapper
{
    [XmlElement("_expxml")]
    public required List<Universidad> Universidades { get; set; }
}