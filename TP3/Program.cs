using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashPersonalizado hash = new HashPersonalizado(11);
            Console.WriteLine("Tabla nueva");
            Console.WriteLine();
            hash.Mostrar();

            Console.WriteLine("Inserto valores");
            Console.WriteLine();
            hash.Insertar(22);
            hash.Mostrar();
            hash.Insertar(35);
            hash.Mostrar();
            hash.Insertar(48);
            hash.Mostrar();
            hash.Insertar(15);
            hash.Mostrar();
            hash.Insertar(26);
            hash.Mostrar();

            Console.WriteLine("Elimino el 22");
            Console.WriteLine();
            hash.Eliminar(22);
            hash.Mostrar();

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey(true);
        }
    }
}
