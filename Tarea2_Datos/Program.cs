// Tarea 2 Datos I Alejandro Arias Alfaro
using System;
using System.ComponentModel;

namespace Tarea2_Datos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ListaDoble lista1 = new ListaDoble();
            lista1.Add(1);
            lista1.Add(2);
            lista1.Add(3);
            lista1.Add(4);

            lista1.Mostrar();  // Debería imprimir: 1 2 3
            lista1.GetMiddle();

            lista1.Invert();

            lista1.Mostrar();  // Debería imprimir: 3 2 1

        }
    }



}

