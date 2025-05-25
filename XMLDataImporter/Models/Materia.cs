
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace XMLDataImporter.Models;

public class Materia
{
    [Key]
    [XmlIgnore]
    public int Id { get; set; }
    [XmlElement("materia")]
    public int Codigo { get; set; }
    [Column(TypeName = "varchar(100)")]
    [XmlElement("nombre")]
    public required string Nombre { get; set; }
    [Column(TypeName = "varchar(10)")]
    [XmlElement("ano")]
    public required string Ano { get; set; }
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
public class MateriaWrapper
{
    [XmlElement("_expxml")]
    public required List<Materia> Materias { get; set; }
}