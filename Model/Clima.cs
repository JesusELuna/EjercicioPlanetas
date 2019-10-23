using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Clima
    {
        [Key]
        public int Dia { get; set; }
        public TipoClima Tipo { get; set; }
        public double? Perimetro { get; set; }
    }

    public enum TipoClima
    { 
        SEQUIA = 0,
        LLUVIA = 1,
        OPTIMO = 2,
        DESCONOCIDO = 3
    }
}
