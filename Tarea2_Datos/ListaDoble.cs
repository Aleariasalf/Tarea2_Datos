using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2_Datos
{
    internal class ListaDoble
    {
        private Nodo cabeza;
        private Nodo cola;
        private Nodo medio;
        private int contador;

        public ListaDoble() 
        {
            cabeza = null;
            cola = null;
            medio = null;
            
            contador = 0;
        }

        // Metodo que agrega un nodo al final
        public void Add(int valor)
        {
            Nodo nuevoNodo = new Nodo(valor);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
                medio = nuevoNodo;
                cabeza.Siguiente = cabeza;
                cabeza.Anterior = cabeza;
            }
            else
            {
                nuevoNodo.Anterior = cola;
                nuevoNodo.Siguiente = cabeza;
                cola.Siguiente = nuevoNodo;
                cabeza.Anterior = nuevoNodo;
                cola = nuevoNodo;
            }
            ActualizarMedioAdd();
            contador++;
        }

        // Metodo actualia el medio despues de anadir elemento
        private void ActualizarMedioAdd()
        {
            if (contador == 1) // Primer elemento
            {
                medio = cabeza;
            }
            else if (contador % 2 == 0) // Si el conteo es par, medio debe avanzar un nodo
            {
                medio = medio.Siguiente;
            }
        }

        // Metodo actualiza el medio despues de eliminar elemento
        private void ActualizarMedioDel()
        {
            if (contador % 2 != 0) // Si el conteo es impar, medio retrocede un nodo
            {
                medio = medio.Anterior;
            }
        }

        // Metodo elimina el primer elemento de la lista
        public void DeleteFirst()
        {
            if (cabeza == null) // Verifica si la lista está vacía
            {
                return;
            }

            if (cabeza.Siguiente == null) // Solo hay un elemento en la lista
            {
                cabeza = null;
                cola = null;
            }
            else // Más de un elemento en la lista
            {
                cabeza = cabeza.Siguiente;
                cabeza.Anterior = null;
            }
            ActualizarMedioDel();
        }

        // Metodo elimina el ultimo elemento de la lista
        public void DeleteLast()
        {
            if (cola == null) // Verifica si la lista está vacía
            {
                return;
            }

            if (cabeza.Anterior == null) // Solo hay un elemento en la lista
            {
                cabeza = null;
                cola = null;
            }
            else // Más de un elemento en la lista
            {
                cola = cola.Anterior;
                cabeza.Siguiente = null;
            }
            ActualizarMedioDel();
        }

        // Metodo elimina elemento de la lista
        public bool DeleteValue(int valor)
        {
            if (cabeza == null)
            {
                return false;
            }

            Nodo actual = cabeza;
            do
            {
                if (actual.Valor.Equals(valor))
                {
                    if (actual == cabeza)
                    {
                        cabeza = cabeza.Siguiente;
                    }

                    if (actual == cola)
                    {
                        cola = cola.Anterior;
                    }

                    actual.Anterior.Siguiente = actual.Siguiente;
                    actual.Siguiente.Anterior = actual.Anterior;


                    contador--;
                    ActualizarMedioDel();

                    return true;
                }
                actual = actual.Siguiente;
            } while (actual != cabeza);

            return false;
        }

        // Metodo que invierte la lista
        public void Invert() 
        {
            Nodo actual = cabeza;
            Nodo temp = null;

            for (int i = 0; i < contador; i++)
            {
                // Intercambiar los punteros Siguiente y Anterior del nodo actual
                temp = actual.Siguiente;
                actual.Siguiente = actual.Anterior;
                actual.Anterior = temp;

                // Avanzar al siguiente nodo en la lista original
                actual = temp;
            }

            // Intercambiar cabeza y cola
            temp = cabeza;
            cabeza = cola;
            cola = temp;
        }

        // Método para imprimir los valores de la lista
        public void Mostrar()
        {
            Nodo actual = cabeza;
            if (cabeza == null)
            {
                Console.WriteLine("Lista vacia");
            }
            else 
            {
                for (int i = 0; i < contador; i++)
                {
                    Console.Write(actual.Valor + " ");
                    actual = actual.Siguiente;
                }
                
            }
            Console.WriteLine();
        }

        // Metodo devuelve el valor del medio
        public void GetMiddle() 
        {
            Console.Write("Elemento central " + medio.Valor + "\n");
        }

        // Metodo que inserta un elemento ordenado en forma ascendente
        public void InsertInOrder(int valor)
        {
            Nodo nuevoNodo = new Nodo(valor);
            contador++;

            // Caso 1: Si la lista está vacía o el valor es menor que el de la cabeza, insertar al inicio
            if (cabeza == null || valor < cabeza.Valor)
            {
                nuevoNodo.Siguiente = cabeza;
                if (cabeza != null)
                    cabeza.Anterior = nuevoNodo;
                cabeza = nuevoNodo;
                if (cola == null) // Si la lista estaba vacía, ahora el nuevo nodo es también la cola
                    cola = nuevoNodo;
                return;
            }

            // Caso 2: Buscar el lugar adecuado para insertar el nuevo nodo en el medio
            Nodo actual = cabeza;
            while (actual.Siguiente != null && actual.Siguiente.Valor < valor)
            {
                actual = actual.Siguiente;
            }

            // Insertar el nuevo nodo en la posición adecuada

            // Si el nodo debe insertarse al final de la lista
            if (actual.Siguiente == null)
            {
                actual.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = actual;
                cola = nuevoNodo;  // Actualizar la cola si es el último
            }
            else
            {
                // Si el nodo debe insertarse entre dos nodos
                nuevoNodo.Siguiente = actual.Siguiente;
                nuevoNodo.Anterior = actual;
                actual.Siguiente.Anterior = nuevoNodo; // Actualizar el nodo siguiente para apuntar al nuevo nodo
                actual.Siguiente = nuevoNodo;
            }
        }
    }
}
