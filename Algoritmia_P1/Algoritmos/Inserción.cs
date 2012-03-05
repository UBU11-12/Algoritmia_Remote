using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using Utilidades;


namespace Algoritmos
{
    /// <summary>
    /// Clase Insercción.
    /// </summary>
    /// <typeparam name="T">To de datos genérico.</typeparam>
    public class Inserción : Ordenación 
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="orden">Criterio de ordenación del vector.</param>
        public Inserción(Orden orden):base(orden){}

        /// <summary>
        /// Ordena el vector recibido mediante Insercción.
        /// </summary>
        /// <param name="vector">Vector a ordenar por el método.</param>
        public override void Ordenar(int[] vector)
        {
            int temp;
            int i, sup = vector.Length - 1;
            tiempoEjecución = new NanoTemporizador();
            tiempoEjecución.Start();
            for (int outer = 1; outer <= sup; outer++)
            {
                temp = vector[outer];
                i = outer;
                if (orden.CompareTo(Orden.Ascendente) == 0)
                {
                    bool intercambio = false;
                    while (i > 0 && vector[i - 1].CompareTo(temp) >= 0)
                    {
                        intercambio = true;
                        vector[i] = vector[i - 1];
                        i -= 1;
                        nComparaciones++;
                    }
                    vector[i] = temp;
                    if(intercambio)
                        nIntercambios++;
                }
                else
                {
                    bool intercambio = false;
                    while (i > 0 && vector[i - 1].CompareTo(temp) <= 0)
                    {
                        intercambio = true;
                        vector[i] = vector[i - 1];
                        i -= 1;
                        nComparaciones++;
                    }
                    vector[i] = temp;
                    if(intercambio)
                        nIntercambios++;
                }
            }
            tiempoEjecución.Stop();
        }


       
    }
}