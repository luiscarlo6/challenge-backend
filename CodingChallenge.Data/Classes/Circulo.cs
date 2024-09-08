using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Interfaces;
using System;

namespace CodingChallenge.Data.Classes
{
    public class Circulo(decimal diametro) : IFormaGeometrica
    {
        private readonly decimal _diametro = diametro;

        public Forma Tipo => Forma.Circulo;

        public decimal CalcularArea() => (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
        public decimal CalcularPerimetro() => (decimal)Math.PI * _diametro;
    }
}
