using System;
using System.Collections.Generic;

namespace TP6
{
	/// <summary>
	/// Description of Grafo.
	/// </summary>
	public class Grafo<T>
	{
		public Grafo()
		{
		}
		
		private List<Vertice<T>>vertices = new List<Vertice<T>>();
	
		public void agregarVertice(Vertice<T> v) {
			v.setPosicion(vertices.Count + 1);
			vertices.Add(v);
		}

		public void eliminarVertice(Vertice<T> v) {
			vertices.Remove(v);
		}

		public void conectar(Vertice<T> origen, Vertice<T> destino, int peso) {
			origen.getAdyacentes().Add(new Arista<T>(destino,peso));
		}

		public void desConectar(Vertice<T> origen, Vertice<T> destino) {
			Arista<T> arista = origen.getAdyacentes().Find(a => a.getDestino().Equals(destino));
			origen.getAdyacentes().Remove(arista);
		}

	
		public List<Vertice<T>> getVertices() {
			return vertices;
		}

	
		public Vertice<T> vertice(int posicion) {
			return this.vertices[posicion];
		}
	
		//---------------------------------------------------------------------------
		public void DFS(Vertice<T> origen) 
		{
			bool[] visitados = new bool[this.vertices.Count];
			this._DFS(origen, visitados);
		}

		private void _DFS(Vertice<T> origen, bool[] visitados)
		{
			//Proceso del origen
			Console.WriteLine(origen.getDato() + " ");

			//Cambio el flag de visitados
			visitados[origen.getPosicion() - 1] = true;

			//Llamada recursiva en profundidad
			foreach(var adyacente in origen.getAdyacentes())
				if (!visitados[adyacente.getDestino().getPosicion() - 1])
					this._DFS(adyacente.getDestino(), visitados);
		}


        //---------------------------------------------------------------------------
        public void BFS(Vertice<T> origen) {

		}
		
		
	}
}
