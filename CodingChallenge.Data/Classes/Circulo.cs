using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Interfaces;
using System;
using System.Runtime.Remoting.Messaging;

namespace CodingChallenge.Data.Classes
{
    public class Circulo : IFormaGeometrica
    {
        private readonly decimal _diametro;

        public Circulo(decimal diametro)
        {
            _diametro = diametro;
        }

        public Forma Tipo => Forma.Circulo;

        public decimal CalcularArea() => (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
        public decimal CalcularPerimetro() => (decimal)Math.PI * _diametro;
    }
}
