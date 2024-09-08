using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Interfaces;

namespace CodingChallenge.Data.Classes
{
    public class Rectangulo : IFormaGeometrica
    {
        private readonly decimal _largo;
        private readonly decimal _ancho;

        public Rectangulo(decimal largo, decimal ancho)
        {
            _largo = largo; 
            _ancho = ancho; 
        }

        public TipoForma Tipo => TipoForma.Rectangulo;

        public decimal CalcularArea() => _largo * _ancho;
        public decimal CalcularPerimetro() => (_largo + _ancho) * 2;
    }
}
