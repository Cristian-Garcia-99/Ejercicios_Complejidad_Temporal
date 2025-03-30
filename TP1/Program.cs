using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Intancio Arbol raiz nivel 0
            ArbolBinario<int> arbolRaiz = new ArbolBinario<int>(1);

            //Instancio Subarboles nivel 1 y sus hijos nivel 2
            ArbolBinario<int> subArbolIzquierdo = new ArbolBinario<int>(2);
            subArbolIzquierdo.agregarHijoIzquierdo(new ArbolBinario<int>(4));
            subArbolIzquierdo.agregarHijoDerecho(new ArbolBinario<int>(5));

            ArbolBinario<int> subArbolDerecho = new ArbolBinario<int>(3);
            subArbolDerecho.agregarHijoIzquierdo(new ArbolBinario<int>(6));
            subArbolDerecho.agregarHijoDerecho(new ArbolBinario<int>(7));

            //Vinculo los subarboles al arbol raiz
            arbolRaiz.agregarHijoIzquierdo(subArbolIzquierdo);
            arbolRaiz.agregarHijoDerecho(subArbolDerecho);

            //--------------------------------------------------------------------------
            
            //Forma del arbol
            Console.WriteLine("   1    ");
            Console.WriteLine("  2 3   ");
            Console.WriteLine("4 5 6 7 ");

            //Pruebo los recorridos

            Console.WriteLine();
            Console.WriteLine("Preorden");
            arbolRaiz.preorden();

            Console.WriteLine();
            Console.WriteLine("Inoorden");
            arbolRaiz.inorden();

            Console.WriteLine();
            Console.WriteLine("Postorden");
            arbolRaiz.postorden();

            Console.WriteLine();
            Console.WriteLine("Contar hojas");
            if (arbolRaiz.contarHojas() == -1)
                Console.WriteLine("Está vacío");
            else
                Console.WriteLine("Hojas: {0}", arbolRaiz.contarHojas());

            //--------------------------------------------------------------------------

            Console.WriteLine();
            Console.WriteLine("Para verificar el metodo nuevoo arbol");
            Console.WriteLine("muestro el preorden de cada uno");
            ArbolBinario<int> nuevo_arbol;
            nuevo_arbol = arbolRaiz.nuevo(arbolRaiz);
            arbolRaiz.preorden();
            Console.WriteLine();
            nuevo_arbol.preorden();


            Console.WriteLine();
            Console.WriteLine("Seleccione cualquier letra para terminar");
            Console.ReadKey(true);
        }
    }
}
