
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XMLDataImporter.Models;

public class Universidad
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "varchar(50)")]
    public required string Nombre { get; set; }
}