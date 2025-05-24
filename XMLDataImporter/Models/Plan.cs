
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace XMLDataImporter.Models;

public class Plan
{
    [Key]
    [XmlElement("plan")]
    public int Id { get; set; }
    [Column(TypeName = "varchar(100)")]
    [XmlElement("nombre")]
    public required string Nombre { get; set; }
    [XmlElement("especialidad")]
    public int EspecialidadId { get; set; }
    [ForeignKey("EspecialidadId")]
    [XmlIgnore]
    public required Especialidad Especialidad { get; set; }
}

[XmlRoot("VFPData")]
public class PlanWrapper
{
    [XmlElement("_expxml")]
    public required List<Plan> Planes { get; set; }
}