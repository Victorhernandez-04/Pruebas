using System.ComponentModel.DataAnnotations;

namespace TTI.Practicas.Data
{
    public class PruebasTablas
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public int TablasRelId { get; set; }
        public PruebasTablasRelacionadas pruebasTablas { get; set; }

    }
}
