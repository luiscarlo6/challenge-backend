/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {

        public static IFormaGeometrica GetFormaGeometrica(TipoForma forma, decimal medida1)
        {
            switch (forma)
            {
                case TipoForma.Circulo: return new Circulo(medida1);//Diametro
                case TipoForma.Cuadrado: return new Cuadrado(medida1);//Lado
                case TipoForma.TrianguloEquilatero: return new TrianguloEquilatero(medida1);//Lado
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public static IFormaGeometrica GetFormaGeometrica(TipoForma forma, decimal medida1, decimal medida2)
        {
            switch (forma)
            {
                case TipoForma.Rectangulo: return new Rectangulo(medida1, medida2);//Lado
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
        public static IFormaGeometrica GetFormaGeometrica(TipoForma forma, decimal medida1, decimal medida2, decimal medida3, decimal medida4, decimal medida5)
        {
            switch (forma)
            {
                case TipoForma.Trapecio: return new Trapecio(medida1, medida2, medida3, medida4, medida5);//Base mayor, Base menor, Altura, Lado 1, Lado 2 
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
    }
}
