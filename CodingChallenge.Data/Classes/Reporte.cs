using Castle.Core.Internal;
using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class Reporte
    {
        public List<IFormaGeometrica> Formas = new List<IFormaGeometrica>();
        public int Idioma = 1;

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;

        #endregion

        public Reporte(List<IFormaGeometrica> formas, int idioma ) {
            Formas = formas;
            Idioma = idioma;
        }

        public static string Imprimir(List<IFormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                //No Hay formas
                if (idioma == Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else
                    sb.Append("<h1>Empty list of shapes!</h1>");

                return sb.ToString();
            }
            
            // HEADER
            if (idioma == Castellano)
                sb.Append("<h1>Reporte de Formas</h1>");
            else
                // default es inglés
                sb.Append("<h1>Shapes report</h1>");

               
            var cuentas = formas.GroupBy(f => f.Tipo).Select(o => new
            {
                Tipo =  o.Key,
                Numero = o.Count(),
                Area= o.Sum(f => f.CalcularArea()),
                Perimetro = o.Sum(f => f.CalcularPerimetro())
            }).ToList();

            cuentas.Select(c => ObtenerLinea(c.Numero, c.Area, c.Perimetro, c.Tipo, idioma)).ForEach(i => sb.Append(i));

            var totales = new
            {
                Numero = cuentas.Sum(f => f.Numero),
                Area = cuentas.Sum(f => f.Area),
                Perimetro = cuentas.Sum(f => f.Perimetro),
            };


            // FOOTER
            sb.Append("TOTAL:<br/>");
            sb.Append(totales.Numero + " " + (idioma == Castellano ? "formas" : "shapes") + " ");
            sb.Append((idioma == Castellano ? "Perimetro " : "Perimeter ") + (totales.Perimetro).ToString("#.##") + " ");
            sb.Append("Area " + (totales.Area).ToString("#.##"));
            
            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, Forma tipo, int idioma)
        {
            if (cantidad > 0)
            {
                if (idioma == Castellano)
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";

                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }


        private static string TraducirForma(Forma tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case Forma.Cuadrado:
                    if (idioma == Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                    else return cantidad == 1 ? "Square" : "Squares";
                case Forma.Circulo:
                    if (idioma == Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
                    else return cantidad == 1 ? "Circle" : "Circles";
                case Forma.TrianguloEquilatero:
                    if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
                    else return cantidad == 1 ? "Triangle" : "Triangles";
            }

            return string.Empty;
        }
    }
}
