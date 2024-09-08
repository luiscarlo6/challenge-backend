using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Interfaces;
using System;

namespace CodingChallenge.Data.Classes
{
    internal class Trapecio(decimal baseMayor, decimal baseMenor, decimal altura, decimal lado1, decimal lado2) : IFormaGeometrica
    {
        public TipoForma Tipo => TipoForma.Trapecio;

        private readonly decimal _baseMayor = baseMayor;
        private readonly decimal _baseMenor = baseMenor;
        private readonly decimal _altura = altura;
        private readonly decimal _lado1 = lado1;
        private readonly decimal _lado2 = lado2;

        public decimal CalcularArea() => ((_baseMayor + _baseMenor) * _altura) / 2;

        public decimal CalcularPerimetro() => _baseMayor + _baseMenor + _lado1 + _lado2;
    }
}
