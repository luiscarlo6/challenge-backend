using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Interfaces;
using System.Text;

var formas = new List<IFormaGeometrica>
            {
                FormaGeometrica.getFormaGeometrica(Forma.Cuadrado, 5),
                FormaGeometrica.getFormaGeometrica(Forma.Circulo, 3),
                FormaGeometrica.getFormaGeometrica(Forma.TrianguloEquilatero, 4),
                FormaGeometrica.getFormaGeometrica(Forma.Cuadrado, 2),
                FormaGeometrica.getFormaGeometrica(Forma.TrianguloEquilatero, 9),
                FormaGeometrica.getFormaGeometrica(Forma.Circulo, 2.75m),
                FormaGeometrica.getFormaGeometrica(Forma.TrianguloEquilatero, 4.2m)
            };
bool exit = false;
while (!exit)
{
    Console.Clear();
    Console.WriteLine("Reporte Interactivo de Formas Geometricas");
    Console.WriteLine("1) Add Element to List");
    Console.WriteLine("2) Print List");
    Console.WriteLine("3) Exit");
    Console.WriteLine("Por favor elija una opción");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.WriteLine("Elija una forma geometrica");
            Console.WriteLine("1) Circulo");
            Console.WriteLine("2) Cuadrado");
            Console.WriteLine("3) Triangulo Equilatero");
            Console.Write("Choose an option: ");
            string? formaElegida = Console.ReadLine();

            Forma? forma= formaElegida switch
            {
                "1" => Forma.Circulo,
                "2" => Forma.Cuadrado,
                "3" => Forma.TrianguloEquilatero,
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
                formas.Add(FormaGeometrica.getFormaGeometrica((Forma)forma, (decimal)lado));
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
            var sb = Reporte.Imprimir(formas, Idioma.Castellano);
            Console.WriteLine(sb.ToString());
            Console.WriteLine("Presione enter para volver");
            Console.ReadLine();
            break;
        case "3":
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid option, please try again.");
            break;
    }


}
Console.Write($"{Environment.NewLine}Press any key to exit...");
Console.ReadKey(true);