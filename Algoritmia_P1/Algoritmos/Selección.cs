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
    /// Clase Selección.
    /// </summary>
    /// <typeparam name="T">To genérico de datos.</typeparam>
    public class Selección : Ordenación 
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="orden">Criterio de ordenación.</param>
        public Selección(Orden orden) : base(orden) { }

        /// <summary>
        /// Ordena el vector recibido mediante Selección.
        /// </summary>
        /// <param name="vector">Vector que se va a ordenar.</param>
        public override void Ordenar(int[] vector)
        {
            int min;
            int temp;
            int sup = vector.Length - 1;
            tiempoEjecución = new NanoTemporizador();
            tiempoEjecución.Start();
            for (int i = 0; i <= sup; i++)
            {
                min = i;
                for (int j = i + 1; j <= sup; j++)
                {
                    if (orden.Equals(Orden.Ascendente))
                    {
                        if (vector[j].CompareTo(vector[min]) < 0)
                        {
                            min = j;
                            nIntercambios++;
                        }
                    }
                    else
                    {
                        if (vector[j].CompareTo(vector[min]) > 0)
                        {
                            min = j;
                            nIntercambios++;
                        }
                    }
                    nComparaciones++;
                }
                temp = vector[i];
                vector[i] = vector[min];
                vector[min] = temp;
            }
            tiempoEjecución.Stop();
        }


       
    }
}

