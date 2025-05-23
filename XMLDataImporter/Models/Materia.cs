
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XMLDataImporter.Models;

public class Materia
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "varchar(50)")]
    public required string Nombre { get; set; }
    [Column(TypeName = "varchar(10)")]
    public required string Ano { get; set; }
    public int EspecialidadId { get; set; }
    [ForeignKey("EspecialidadId")]
    public required Especialidad Especialidad { get; set; }
    public int PlanId { get; set; }
    [ForeignKey("PlanId")]
    public required Plan Plan { get; set; }
}