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

        public static IFormaGeometrica getFormaGeometrica(Forma forma, decimal ancho)
        {
            switch (forma)
            {
                case Forma.Circulo: return new Circulo(ancho);
                case Forma.Cuadrado: return new Cuadrado(ancho);
                case Forma.TrianguloEquilatero: return new TrianguloEquilatero(ancho);
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }


    }
}
