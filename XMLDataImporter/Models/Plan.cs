
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XMLDataImporter.Models;

public class Plan
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "varchar(50)")]
    public required string Nombre { get; set; }
    public int EspecialidadId { get; set; }
    [ForeignKey("EspecialidadId")]
    public required Especialidad Especialidad { get; set; }
}