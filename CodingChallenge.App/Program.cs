using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Interfaces;
using System.Text;

var formas = new List<IFormaGeometrica>
            {
                FormaGeometrica.GetFormaGeometrica(TipoForma.Rectangulo, 5, 3),
                FormaGeometrica.GetFormaGeometrica(TipoForma.Rectangulo, 10, 4),
                FormaGeometrica.GetFormaGeometrica(TipoForma.Rectangulo, 7, 2),
                FormaGeometrica.GetFormaGeometrica(TipoForma.Trapecio, 8, 5, 4, 6, 7),
                FormaGeometrica.GetFormaGeometrica(TipoForma.Trapecio, 12,7,5,9,10),
                FormaGeometrica.GetFormaGeometrica(TipoForma.Trapecio, 15,6,8,10,11),
            };
bool exit = false;
while (!exit)
{
    Console.Clear();
    Console.WriteLine("Reporte Interactivo de Formas Geometricas");
    Console.WriteLine("1) Add Element to List");
    Console.WriteLine("2) Print List ES");
    Console.WriteLine("3) Print List EN");
    Console.WriteLine("4) Print List PR");
    Console.WriteLine("5) Exit");
    Console.WriteLine("Por favor elija una opción");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.WriteLine("Elija una forma geometrica");
            Console.WriteLine("1) Circulo");
            Console.WriteLine("2) Cuadrado");
            Console.WriteLine("3) Triangulo Equilatero");
            Console.WriteLine("4) Trapecio");
            Console.WriteLine("5) Rectangulo");
            Console.Write("Choose an option: ");
            string? formaElegida = Console.ReadLine();

            TipoForma? forma= formaElegida switch
            {
                "1" => TipoForma.Circulo,
                "2" => TipoForma.Cuadrado,
                "3" => TipoForma.TrianguloEquilatero,
                "4" => TipoForma.Trapecio,
                "5" => TipoForma.Rectangulo,
                _ => null,
            };

            if (forma == null)
            {
                Console.WriteLine("Opcion inválida");
                Console.ReadLine();
                return;
            }

            Console.Write("Indique el valor del lado: ");
            if (double.TryParse(Console.ReadLine(), out double lado))
            {
                formas.Add(FormaGeometrica.GetFormaGeometrica((TipoForma)forma, (decimal)lado));
                Console.WriteLine($"{forma.ToString()} con lado {lado} agregado al reporte");
            }
            else
            {
                Console.WriteLine("Número inválido");
            }

            Console.WriteLine("Presione enter para volver");
            Console.ReadLine();
            break;
        case "2":
            Console.WriteLine(Reporte.Imprimir(formas, Idioma.Castellano));
            Console.WriteLine("Presione enter para volver");
            Console.ReadLine();
            break;
        case "3":
            Console.WriteLine(Reporte.Imprimir(formas, Idioma.Ingles));
            Console.WriteLine("Presione enter para volver");
            Console.ReadLine();
            break;
        case "4":
            Console.WriteLine(Reporte.Imprimir(formas, Idioma.Portugues));
            Console.WriteLine("Presione enter para volver");
            Console.ReadLine();
            break;
        case "5":
            exit= true;
            break;
        default:
            Console.WriteLine("Invalid option, please try again.");
            break;
    }


}
Console.Write($"{Environment.NewLine}Press any key to exit...");
Console.ReadKey(true);