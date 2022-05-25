using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtencionCliente.Models
{
    [Table("Cola", Schema = "dbo")]
    public class Cola
    {
        [Key]
        public int IdCola { get; set; }
        public string? Nombre { get; set; }
        public int? Minutos { get; set; }
    }
}
