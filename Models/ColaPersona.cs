using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtencionCliente.Models
{
    [Table("ColaPersona", Schema = "dbo")]
    public class ColaPersona
    {
        [Key]
        public int IdColaPersona { get; set; }
        public int IdPersona { get; set; }
        public int IdCola { get; set; }
        public bool Estado { get; set; }
        
    }
}
