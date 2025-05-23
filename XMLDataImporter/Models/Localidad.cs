
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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