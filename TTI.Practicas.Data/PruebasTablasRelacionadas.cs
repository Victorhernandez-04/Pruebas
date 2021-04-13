using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TTI.Practicas.Data
{
    [Table("PruebasRelacionadas")]
    public class PruebasTablasRelacionadas
    {
        [Key]
        public int PruebasId { get; set; }
        public int Edad { get; set; }
       
    }
}
