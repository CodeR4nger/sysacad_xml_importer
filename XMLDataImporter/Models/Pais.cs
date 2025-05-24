
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace XMLDataImporter.Models;

public class Pais
{
    [Key]
    [XmlElement("pais")]
    public int Id { get; set; }
    [Column(TypeName = "varchar(100)")]
    [XmlElement("nombre")]
    public required string Nombre { get; set; }
}

[XmlRoot("VFPData")]
public class PaisWrapper
{
    [XmlElement("_expxml")]
    public required List<Pais> Paises { get; set; }
}