using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo : IFormaGeometrica
    {
        public decimal Base { get; }
        public decimal Altura { get; }

        public Rectangulo(decimal baseRect, decimal altura)
        {
            Base = baseRect;
            Altura = altura;
        }

        public decimal CalcularArea() => Base * Altura;

        public decimal CalcularPerimetro() => 2 * (Base + Altura);

        public string ObtenerNombre(int idioma) => FormaGeometrica.Traducciones[idioma]["Rectangulo"];
    }
}
