
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace XMLDataImporter.Models;

public class Localidad
{
    [Key]
    [XmlElement("codigo")]
    public int Id { get; set; }
    [XmlElement("ciudad")]
    [Column(TypeName = "varchar(100)")]
    public required string Ciudad { get; set; }
    [Column(TypeName = "varchar(100)")]
    [XmlElement("provincia")]
    public required string Provincia { get; set; }
    [Column(TypeName = "varchar(100)")]
    [XmlElement("pais_del_c")]
    public required string Pais { get; set; }
}
[XmlRoot("VFPData")]
public class LocalidadWrapper
{
    [XmlElement("_exportar")]
    public required List<Localidad> Localidades { get; set; }
}