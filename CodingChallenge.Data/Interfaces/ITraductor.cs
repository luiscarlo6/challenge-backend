using CodingChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Interfaces
{
    public interface ITraductor
    {
        string ListaVacia();
        string Header();
        string Footer(dynamic totales);
        string ObtenerLinea(int cantidad, decimal area, decimal perimetro, TipoForma tipo);
        string TraducirForma(TipoForma tipo, int cantidad);
    }
}

