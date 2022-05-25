using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtencionCliente.Models
{
    [Table("Persona", Schema = "dbo")]
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }
        public string? Identificacion { get; set; }
        public string? Nombre { get; set; }
    }
}
