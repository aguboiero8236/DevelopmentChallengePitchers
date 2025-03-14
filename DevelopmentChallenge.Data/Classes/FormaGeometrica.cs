/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;


        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Italiano = 3;

        #endregion


        public static string Imprimir(List<IFormaGeometrica> formas, int idioma)
        {
            if (!Traducciones.ContainsKey(idioma))
            {
                idioma = Ingles;
            }

            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append(Traducciones[idioma]["ListaVacia"]);
                return sb.ToString();
            }

            sb.Append(Traducciones[idioma]["Titulo"]);

            var resumen = formas.GroupBy(f => f.ObtenerNombre(idioma))
                                .Select(g => new
                                {
                                    Nombre = g.Key,
                                    Cantidad = g.Count(),
                                    AreaTotal = g.Sum(f => f.CalcularArea()),
                                    PerimetroTotal = g.Sum(f => f.CalcularPerimetro())
                                });

            foreach (var grupo in resumen)
            {
                sb.AppendFormat("{0} {1} | {2}: {3:#.##} | {4}: {5:#.##} <br/>",
                    grupo.Cantidad, grupo.Nombre,
                    Traducciones[idioma]["Perimetro"], grupo.PerimetroTotal,
                    Traducciones[idioma]["Area"], grupo.AreaTotal);
            }

            sb.Append(Traducciones[idioma]["Total"]);
            sb.AppendFormat("{0} {1} | {2}: {3:#.##} | {4}: {5:#.##}",
                formas.Count, Traducciones[idioma]["Formas"],
                Traducciones[idioma]["Perimetro"], formas.Sum(f => f.CalcularPerimetro()),
                Traducciones[idioma]["Area"], formas.Sum(f => f.CalcularArea()));

            return sb.ToString();
        }        
               

        public static readonly Dictionary<int, Dictionary<string,
            string>> Traducciones = new Dictionary<int, Dictionary<string, string>>
            {
                { Castellano, new Dictionary<string, string>
                    {
                        { "Titulo", "<h1>Reporte de Formas</h1>" },
                        { "ListaVacia", "<h1>Lista vacía de formas!</h1>" },
                        { "Total", "TOTAL:<br/>" },
                        { "Formas", "formas" },
                        { "Perimetro", "Perímetro" },
                        { "Area", "Área" },
                        { "Cuadrado", "Cuadrado" },
                        { "Circulo", "Círculo" },
                        { "Triangulo", "Triángulo Equilátero" }
                    }
                },
                { Ingles, new Dictionary<string, string>
                    {
                        { "Titulo", "<h1>Shapes report</h1>" },
                        { "ListaVacia", "<h1>Empty list of shapes!</h1>" },
                        { "Total", "TOTAL:<br/>" },
                        { "Formas", "shapes" },
                        { "Perimetro", "Perimeter" },
                        { "Area", "Area" },
                        { "Cuadrado", "Square" },
                        { "Circulo", "Circle" },
                        { "Triangulo", "Equilateral Triangle" }
                    }
                },
                { Italiano, new Dictionary<string, string>
                    {
                        { "Titulo", "<h1>Report delle Forme</h1>" },
                        { "ListaVacia", "<h1>Lista vuota di forme!</h1>" },
                        { "Total", "TOTALE:<br/>" },
                        { "Formas", "forme" },
                        { "Perimetro", "Perimetro" },
                        { "Area", "Area" },
                        { "Cuadrado", "Quadrato" },
                        { "Circulo", "Cerchio" },
                        { "Triangulo", "Triangolo Equilatero" }
                    }
                }
            };
    }
}
