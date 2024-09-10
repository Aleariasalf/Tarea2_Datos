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
    }
}
