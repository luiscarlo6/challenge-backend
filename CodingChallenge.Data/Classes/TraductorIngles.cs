﻿using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    internal class TraductorIngles : ITraductor
    {

        public string ObtenerLinea(int cantidad, decimal area, decimal perimetro, Forma tipo)
        {
            return $"{cantidad} {TraducirForma(tipo, cantidad)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
        }


        public string TraducirForma(Forma tipo, int cantidad)
        {
            switch (tipo)
            {
                case Forma.Cuadrado:
                    return cantidad == 1 ? "Square" : "Squares";
                case Forma.Circulo:
                    return cantidad == 1 ? "Circle" : "Circles";
                case Forma.TrianguloEquilatero:
                    return cantidad == 1 ? "Triangle" : "Triangles";
                default:
                    return string.Empty;
            }

        }

        public string Footer(dynamic totales)
        {
            var sb = new StringBuilder();
            sb.Append("TOTAL:<br/>");
            sb.Append(totales.Cantidad + " shapes ");
            sb.Append("Perimeter "+ (totales.Perimetro).ToString("#.##") + " ");
            sb.Append("Area " + (totales.Area).ToString("#.##"));
            return sb.ToString();
        }

        public string Header()
        {
            return "<h1>Shapes report</h1>";
        }

        public string ListaVacia()
        {
            return "<h1>Empty list of shapes!</h1>";
        }
    }
}
