using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : IFormaGeometrica
    {
        public decimal Lado { get; }

        public Cuadrado(decimal lado) => Lado = lado;

        public decimal CalcularArea() => Lado * Lado;

        public decimal CalcularPerimetro() => Lado * 4;

        public string ObtenerNombre(int idioma) => FormaGeometrica.Traducciones[idioma]["Cuadrado"];
    }
}
