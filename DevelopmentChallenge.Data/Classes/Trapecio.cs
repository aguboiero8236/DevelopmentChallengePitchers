using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : IFormaGeometrica
    {
        public decimal BaseMayor { get; }
        public decimal BaseMenor { get; }
        public decimal Altura { get; }
        public decimal Lado1 { get; }
        public decimal Lado2 { get; }

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura, decimal lado1, decimal lado2)
        {
            BaseMayor = baseMayor;
            BaseMenor = baseMenor;
            Altura = altura;
            Lado1 = lado1;
            Lado2 = lado2;
        }

        public decimal CalcularArea() => ((BaseMayor + BaseMenor) * Altura) / 2;

        public decimal CalcularPerimetro() => BaseMayor + BaseMenor + Lado1 + Lado2;

        public string ObtenerNombre(int idioma) => FormaGeometrica.Traducciones[idioma]["Trapecio"];
    }
}
