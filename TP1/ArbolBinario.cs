using System;

namespace TP1
{
	public class ArbolBinario<T>
	{
		
		private T dato;
		private ArbolBinario<T> hijoIzquierdo;
		private ArbolBinario<T> hijoDerecho;
	
		
		public ArbolBinario(T dato) {
			this.dato = dato;
		}
	
		public T getDatoRaiz() {
			return this.dato;
		}
	
		public ArbolBinario<T> getHijoIzquierdo() {
			return this.hijoIzquierdo;
		}
	
		public ArbolBinario<T> getHijoDerecho() {
			return this.hijoDerecho;
		}
	
		public void agregarHijoIzquierdo(ArbolBinario<T> hijo) {
			this.hijoIzquierdo = hijo;
		}
	
		public void agregarHijoDerecho(ArbolBinario<T> hijo) {
			this.hijoDerecho = hijo;
		}
	
		public void eliminarHijoIzquierdo() {
			this.hijoIzquierdo = null;
		}
	
		public void eliminarHijoDerecho() {
			this.hijoDerecho = null;
		}
	
		public bool esHoja() {
			return this.hijoIzquierdo == null && this.hijoDerecho == null;
		}

        //----------------------------------------------------------------
        //Agrego el metodo esVacio()
        //Para que funcione tengo que verificar que el dato no sea nulo
        //pero TAMBIEN debo verificar si los hijos son nuloos
        //sino da el error: System.NullReferenceException
        public bool esVacio()
		{
            return this.dato == null && this.hijoIzquierdo == null && this.hijoDerecho == null;
        }
		
		//----------------------------------------------------------------
		//Primero el hijo izquierdoo
		//Luego la raiz
		//Por últimoo el hijoo derecho
		public void inorden() 
		{
			if(!this.esVacio())
			{
                //Llamada hijo izquierdo
                if (this.getHijoIzquierdo() != null && !this.getHijoIzquierdo().esVacio())
                    this.getHijoIzquierdo().inorden();

                //Proceso de la raiz
                Console.Write(this.getDatoRaiz() + " ");

                //Llamada hijo derecho
                if (this.getHijoDerecho() != null && !getHijoDerecho().esVacio())
                    this.getHijoDerecho().inorden();
            }
		}

        //----------------------------------------------------------------
		//Primero la raiz
		//Luego los hijos
        public void preorden() 
		{
			if (!this.esVacio())
			{
				//Proceso de la raiz
				Console.Write(this.getDatoRaiz() + " ");

				//Llamada hijo izquierdo
				if (this.getHijoIzquierdo() != null && !this.getHijoIzquierdo().esVacio())
					this.getHijoIzquierdo().preorden();

				//Llamada hijo derecho
				if (this.getHijoDerecho() != null && !getHijoDerecho().esVacio())
					this.getHijoDerecho().preorden();
			}
		}

        //----------------------------------------------------------------
		//Primero los hijos
		//Luego la raiz
        public void postorden()
		{
            if (!this.esVacio())
            {
                //Llamada hijo izquierdo
                if (this.getHijoIzquierdo() != null && !this.getHijoIzquierdo().esVacio())
                    this.getHijoIzquierdo().postorden();

                //Llamada hijo derecho
                if (this.getHijoDerecho() != null && !getHijoDerecho().esVacio())
                    this.getHijoDerecho().postorden();

                //Proceso de la raiz
                Console.Write(this.getDatoRaiz() + " ");
            }
        }

        //----------------------------------------------------------------
		//FALTA LA CLASE COLA
        public void recorridoPorNiveles() 
		{

		}

        //----------------------------------------------------------------
		//Si es vacio devuelve -1
		//Sino hace un recorrido similar al potorden
		//Solo que la recursividad se utiliza como contador
        public int contarHojas() {
			
			int vacio = -1;
			int hojas_izquierda = 0, hojas_derecha = 0;
			
			if (!this.esVacio())
			{
                //Si el nodo actual es una hoja devuelve 1
                if (this.esHoja())
                    return 1;

                //Cuenta las hojas izquierdas
                if (this.getHijoIzquierdo() != null)
                    hojas_izquierda += this.getHijoIzquierdo().contarHojas();
            
                //Cuenta las hojas derechas
                if (this.getHijoDerecho() != null)
                    hojas_derecha += this.getHijoDerecho().contarHojas();
               
                //Devuelve la suma
                return hojas_izquierda + hojas_derecha;
            }
			return vacio;
		}

        //----------------------------------------------------------------
        public void recorridoEntreNiveles(int n,int m) 
		{
            //FALTA LA CLASE COLA
        }

        //----------------------------------------------------------------

        public ArbolBinario<int> nuevo(ArbolBinario<int> arbol)
        {
            if (arbol == null)
                return null;

            // Crear el nuevo árbol con el mismo dato raíz del árbol dado.
            ArbolBinario<int> nuevo_arbol = new ArbolBinario<int>(arbol.getDatoRaiz());

            // Verificar si el árbol dado tiene hijo izquierdo.
            if (arbol.getHijoIzquierdo() != null)
            {
                //Calculo el valor del nuevo hijo como la suma de la raiz actual y la raiz del hijoo izquierdo
                int nuevo_izquierdo = arbol.getDatoRaiz() + arbol.getHijoIzquierdo().getDatoRaiz();
                
				//Creo el nuevo hijo izquierdo
                ArbolBinario<int> nuevo_hijo_izquierdo = new ArbolBinario<int>(nuevo_izquierdo);

                //Lo vinculo al primer arbol instanciado
                nuevo_arbol.agregarHijoIzquierdo(nuevo_hijo_izquierdo);

                //En la recursividad
                //Del hijo izquierdo tomo su izquierdo (IZQUIERDA)
                //Del hijo izquierdo tomo su derecho (DERECHA)
                nuevo_hijo_izquierdo.agregarHijoIzquierdo(nuevo(arbol.getHijoIzquierdo().getHijoIzquierdo()));
                nuevo_hijo_izquierdo.agregarHijoDerecho(nuevo(arbol.getHijoIzquierdo().getHijoDerecho()));
            }

            //No modifico el hijo derecho
            if (arbol.getHijoDerecho() != null)
                nuevo_arbol.agregarHijoDerecho(nuevo(arbol.getHijoDerecho()));

            return nuevo_arbol;
        }

    }
}
