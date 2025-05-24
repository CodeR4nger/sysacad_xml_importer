
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
    [XmlElement("codigo")]
    public int Id { get; set; }
    [XmlElement("ciudad")]
    public required string Ciudad { get; set; }
    [XmlElement("provincia")]
    public required string Provincia { get; set; }
    [XmlElement("pais_del_c")]
    public required string Pais { get; set; }
}

[XmlRoot("VFPData")]
public class LocalidadWrapper
{
    [XmlElement("_exportar")]
    public required List<LocalidadXML> Localidades { get; set; }
}