using System.ComponentModel.DataAnnotations;

namespace ServidorApiPlatos.Models
{
    public class Plato
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Costo { get; set; }
        public string Ingredientes { get; set; }
    }
}
