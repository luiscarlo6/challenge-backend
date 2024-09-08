using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class TraductorCastellano : ITraductor
    {
        public string ObtenerLinea(int cantidad, decimal area, decimal perimetro, TipoForma tipo)
        {
            return $"{cantidad} {TraducirForma(tipo, cantidad)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";
        }


        public string TraducirForma(TipoForma tipo, int cantidad)
        {
            switch (tipo)
            {
                case TipoForma.Cuadrado:
                    return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                case TipoForma.Circulo:
                    return cantidad == 1 ? "Círculo" : "Círculos";
                case TipoForma.TrianguloEquilatero:
                    return cantidad == 1 ? "Triángulo" : "Triángulos";
                case TipoForma.Trapecio:
                    return cantidad == 1 ? "Trapecio" : "Trapecios";
                case TipoForma.Rectangulo:
                    return cantidad == 1 ? "Rectángulo" : "Rectángulos";
                default:
                    return string.Empty;
            }
        }

        public string Footer(dynamic totales)
        {
            var sb = new StringBuilder();
            sb.Append("TOTAL:<br/>");
            sb.Append(totales.Cantidad + " formas ");
            sb.Append("Perimetro " + (totales.Perimetro).ToString("#.##") + " ");
            sb.Append("Area " + (totales.Area).ToString("#.##"));
            return sb.ToString();
        }

        public string Header()
        {
            return "<h1>Reporte de Formas</h1>";
        }

        public string ListaVacia()
        {
            return "<h1>Lista vacía de formas!</h1>";
        }
    }
}
