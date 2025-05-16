using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP6
{
    public class MercadoDePilotos
    {
        public MercadoDePilotos() 
        {
            //Constructor default ya que no hay variables de instancia por enunciado
        }
        public List<string> PilotoQuePasoPorMasEscuderias(Grafo<string> escuderias)
        {
            Vertice<string> origen = escuderias.getVertices().Find(v => v.getDato() == "origen");

            //Lista con la ruta mas larga (mas elementos)
            List<string> mejorCamino = new List<string>();

            foreach (Arista<string> arista in origen.getAdyacentes())
            {
                //Lista para analizar la ruta actua
                List<string> caminoActual = new List<string>();
                Vertice<string> siguiente = arista.getDestino();
                caminoActual.Add(siguiente.getDato());

                DFS(siguiente, caminoActual, mejorCamino);
            }

            return mejorCamino;
        }

        //Este método es es el que hace posible la recursión y por lo tanto el análisis de la ruta
        //Es un método privado, ya que, los argumentos del método del enunciado son insuficientes
        //Corresponde al algoritmo DSF
        private void DFS(Vertice<string> actual, List<string> caminoActual, List<string> mejorCamino)
        {
            foreach (Arista<string> arista in actual.getAdyacentes())
            {
                Vertice<string> siguiente = arista.getDestino();

                //Verifica que el camino actual no se encuentre en la ruta
                //Evita usar el vector de Visitados
                if (caminoActual.Contains(siguiente.getDato()))
                    continue;

                caminoActual.Add(siguiente.getDato());

                if (caminoActual.Count > mejorCamino.Count)
                {
                    //Actualiza el mejor camino
                    mejorCamino.Clear();
                    mejorCamino.AddRange(caminoActual);
                }

                //Recursividad
                DFS(siguiente, caminoActual, mejorCamino);
            }
        }
    }
}

