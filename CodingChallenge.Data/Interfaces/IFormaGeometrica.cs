using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge.Data.Enums;


namespace CodingChallenge.Data.Interfaces
{
    public interface IFormaGeometrica
    {
        TipoForma Tipo { get; }
        decimal CalcularArea();
        decimal CalcularPerimetro();
    }
}
