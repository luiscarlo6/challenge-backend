using Castle.Core.Internal;
using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class Reporte
    {
        private static ITraductor _traductorCastellano;
        private static ITraductor _traductorIngles;

        private static ITraductor ObtenerTraductor(Idioma idioma)
        {
            return idioma switch
            {
                Idioma.Castellano => _traductorCastellano ??= new TraductorCastellano(),
                Idioma.Ingles => _traductorIngles ??= new TraductorIngles(),
                _ => _traductorIngles ??= new TraductorIngles()
            };
        }

        public static string Imprimir(List<IFormaGeometrica> formas, Idioma idioma)
        {
            var traductor = ObtenerTraductor(idioma);
            var sb = new StringBuilder();

            if (formas.Count == 0)
            {
                sb.Append(traductor.ListaVacia());
                return sb.ToString();
            }

            sb.Append(traductor.Header());
               
            var cuentas = formas.GroupBy(f => f.Tipo).Select(o => new
            {
                Tipo =  o.Key,
                Cantidad = o.Count(),
                Area= o.Sum(f => f.CalcularArea()),
                Perimetro = o.Sum(f => f.CalcularPerimetro())
            }).ToList();

            cuentas.Select(c => c.Cantidad > 0 ? traductor.ObtenerLinea(c.Cantidad, c.Area, c.Perimetro, c.Tipo): string.Empty).ToList().ForEach(i => sb.Append(i));

            var totales = new
            {
                Cantidad = cuentas.Sum(f => f.Cantidad),
                Area = cuentas.Sum(f => f.Area),
                Perimetro = cuentas.Sum(f => f.Perimetro),
            };

            sb.Append(traductor.Footer(totales));
            return sb.ToString();
        }
    }
}
