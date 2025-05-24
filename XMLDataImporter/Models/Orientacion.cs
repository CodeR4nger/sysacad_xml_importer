
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace XMLDataImporter.Models;

public class Orientacion
{
    [Key]
    [XmlElement("orientacion")]
    public int Id { get; set; }
    [Column(TypeName = "varchar(100)")]
    [XmlElement("nombre")]
    public required string Nombre { get; set; }
    [XmlElement("especialidad")]
    public int EspecialidadId { get; set; }
    [ForeignKey("EspecialidadId")]
    [XmlIgnore]
    public required Especialidad Especialidad { get; set; }
    [XmlElement("plan")]
    public int PlanId { get; set; }
    [ForeignKey("PlanId")]
    [XmlIgnore]
    public required Plan Plan { get; set; }
}

[XmlRoot("VFPData")]
public class OrientacionWrapper
{
    [XmlElement("_expxml")]
    public required List<Orientacion> Orientaciones { get; set; }
}