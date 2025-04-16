using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3
{
    internal class HashPersonalizado
    {
        private int tamaño;
        private int?[] tabla;
        
        public HashPersonalizado(int tamaño)
        {
            this.tamaño = tamaño;
            this.tabla = new int?[tamaño];
        }

        //Función base de dispersión h(x)
        public int Dispersion(int clave)
        {
            return clave % this.tamaño;
        }

        //Mi función de dispersion es cuadrática pero no el caso base
        //Atiende a la expresion f(i) = i^2 + i
        //Siendo f(0) = 0 -> Cumple con la teoría
        public int Colision(int i)
        {
            return (i * i) + i;
        }

        //Para insertar según la teoría se tiene que:
        //d(x) = [h(x) + f(i)] % N, f(0) = 0
        //d -> pos, N -> tamaño
        //h(x) -> Dispersion()
        //f(i) -> Colision()
        public void Insertar(int clave)
        {
            int i = 0;
            int pos;

            do
            {
                pos = (Dispersion(clave) + Colision(i)) % this.tamaño;

                if (tabla[pos] == null)
                {
                    tabla[pos] = clave;
                    return;
                }
                i++;
            }
            while (i < this.tamaño);
            //Si sale del while no pudo insetar
            Console.WriteLine("ERROR");
            Console.WriteLine("Noo se pudo insertar la clave");     
        }

        //Para eliminar es la misma secuencia que insertar
        //Solo que reemplazamos el valor por NULL
        public void Eliminar(int clave)
        {
            int i = 0;
            int pos;

            do
            {
                pos = (Dispersion(clave) + Colision(i)) % this.tamaño;

                if (tabla[pos] == null) 
                    return;

                if (tabla[pos] == clave)
                {
                    tabla[pos] = null;
                    return;
                }

                i++;
            }
            while (i < tamaño);
        }

        //Método para mostrar el vector
        public void Mostrar()
        {
            string mensaje = "[";
            foreach (var valor in this.tabla)
            {
                if (valor != null)
                    mensaje += valor.ToString();
                else
                    mensaje += "VACIO";
                mensaje += ",";
            }
            string nuevoMensaje;
            nuevoMensaje = mensaje.Substring(0, mensaje.Length - 1) + "]";
            Console.WriteLine(nuevoMensaje);
            Console.WriteLine();
        }

    }
}
