using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    internal class TraductorPortugues : ITraductor
    {

        public string ObtenerLinea(int cantidad, decimal area, decimal perimetro, TipoForma tipo)
        {
            return $"{cantidad} {TraducirForma(tipo, cantidad)} | Área  {area:#.##} | Perímetro  {perimetro:#.##} <br/>";
        }


        public string TraducirForma(TipoForma tipo, int cantidad)
        {
            switch (tipo)
            {
                case TipoForma.Cuadrado:
                    return cantidad == 1 ? "Quadrado" : "Quadrados";
                case TipoForma.Circulo:
                    return cantidad == 1 ? "Círculo" : "Círculos";
                case TipoForma.TrianguloEquilatero:
                    return cantidad == 1 ? "Triângulo" : "Triângulos";
                case TipoForma.Trapecio:
                    return cantidad == 1 ? "Trapézio" : "Trapézios";
                case TipoForma.Rectangulo:
                    return cantidad == 1 ? "Retângulo" : "Rectângulos";
                default:
                    return string.Empty;
            }

        }

        public string Footer(dynamic totales)
        {
            var sb = new StringBuilder();
            sb.Append("TOTAL:<br/>");
            sb.Append(totales.Cantidad + " formas ");
            sb.Append("Perímetro " + (totales.Perimetro).ToString("#.##") + " ");
            sb.Append("Área " + (totales.Area).ToString("#.##"));
            return sb.ToString();
        }

        public string Header()
        {
            return "<h1>Relatório de formas</h1>";
        }

        public string ListaVacia()
        {
            return "<h1>Lista vazia de formas!</h1>";
        }
    }
}
