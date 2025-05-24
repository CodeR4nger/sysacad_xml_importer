
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace XMLDataImporter.Models;

public class Localidad
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "varchar(50)")]
    public required string Ciudad { get; set; }
    [Column(TypeName = "varchar(50)")]
    public required string Provincia { get; set; }
    public int PaisId { get; set; }
    [ForeignKey("PaisId")]
    public required Pais Pais { get; set; }
}

public class LocalidadXML
{
    public int Id { get; set; }
    public required string Ciudad { get; set; }
    public required string Provincia { get; set; }
    public required string Pais { get; set; }
}

[XmlRoot("VFPData")]
public class LocalidadWrapper
{
    [XmlElement("_expxml")]
    public required List<LocalidadXML> Localidades { get; set; }
}