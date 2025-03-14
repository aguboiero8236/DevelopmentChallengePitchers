using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : IFormaGeometrica
    {
        public decimal Radio { get; }

        public Circulo(decimal radio) => Radio = radio;

        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (Radio * Radio);
        }

        public decimal CalcularPerimetro() => (decimal)(2 * Math.PI) * Radio;

        public string ObtenerNombre(int idioma) => FormaGeometrica.Traducciones[idioma]["Circulo"];
    }
}
