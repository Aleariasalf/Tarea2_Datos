// Tarea 2 Datos I Alejandro Arias Alfaro
using System;
using System.ComponentModel;

namespace Tarea2_Datos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ListaDoble listA = new ListaDoble();
            listA.Add(1);
            listA.Add(2);
            listA.Add(4);
            listA.Add(5);

            ListaDoble listB = new ListaDoble();
            listB.Add(8);
            listB.Add(9);
            listB.Add(11);
            listB.Add(12);


            listA.Mostrar();  // Debería imprimir: 1 2 3
            
            listB.Mostrar();  // Debería imprimir: 3 2 1


            ListaDoble listaunida = ListaDoble.MergeSorted(listA, listB, "asc");

            listaunida.Mostrar();
        }
    }



}

