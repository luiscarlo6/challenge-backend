using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    internal class TrianguloEquilatero(decimal lado) : IFormaGeometrica
    {
        private readonly decimal _lado = lado;

        public TipoForma Tipo => TipoForma.TrianguloEquilatero;

        public decimal CalcularArea() => ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        public decimal CalcularPerimetro() => _lado * 3;
    }
}
