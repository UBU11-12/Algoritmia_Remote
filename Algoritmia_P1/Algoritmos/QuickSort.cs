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
    /// Clase QuickSort.
    /// </summary>
    /// <typeparam name="T">To genérico de datos.</typeparam>
    public class QuickSort : Ordenación 
    {

        /// <summary>
        /// ArrayList con los índices de los datos ya ordenados.
        /// </summary>
        ArrayList datosOrdenados = new ArrayList();

        /// <summary>
        /// ArrayList con los índices de los datos ya ordenados.
        /// </summary>
        ArrayList datosComparados = new ArrayList();

        /// <summary>
        /// Variable que los estados de ordenación asignados.
        /// </summary>
        public int posición;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="orden">Criterio de ordenación.</param>
        public QuickSort(Orden orden) : base(orden) {  }

        /// <summary>
        /// Ordena el vector mediante QuickSort.
        /// </summary>
        /// <param name="vector">Vector a ordenar.</param>
        public override void Ordenar(int[] vector)
        {
            tiempoEjecución = new NanoTemporizador();
            tiempoEjecución.Start();
            OrdenarAux(vector, 0, vector.Length - 1);
        }
        
        /// <summary>
        /// Función auxiliar del método ordenar.
        /// </summary>
        /// <param name="vector">Vector a ordenar.</param>
        /// <param name="izda">Límite inferior del vector.</param>
        /// <param name="drcha">Límite superior del vector.</param>
        public void OrdenarAux(int[] vector, int izda, int drcha)
        {            
            int i = izda, j = drcha;
            int pivote = vector[(izda + drcha) / 2];
            do
            {
                if (orden.Equals(Orden.Ascendente))
                {
                    while (vector[i].CompareTo(pivote) < 0)
                    {
                        i++;
                        nComparaciones++;
                    }
                    while (vector[j].CompareTo(pivote) > 0)
                    {
                        j--;
                        nComparaciones++;
                    }

                    int aux = vector[i];
                    if (i <= j)
                    {
                        if (vector[i].CompareTo(vector[j])>0)
                            nIntercambios++;
                        vector[i] = vector[j];
                        vector[j] = aux;
                        i++;
                        j--;
                        
                    }
                }
                else
                {
                    while (vector[i].CompareTo(pivote) >0)
                    {
                        i++;
                        nComparaciones++;
                    }
                    while (vector[j].CompareTo(pivote) < 0)
                    {
                        j--;
                        nComparaciones++;
                    }
                    int aux = vector[i];
                    if (i <= j)
                    {
                        if (vector[i].CompareTo(vector[j])<0)
                            nIntercambios++;
                        vector[i] = vector[j];
                        vector[j] = aux;
                        i++;
                        j--;                        
                    }
                }
            } while (i <= j);
            if (izda < j) OrdenarAux(vector, izda, j);
            if (drcha > i) OrdenarAux(vector, i, drcha);
            if(izda==0&&drcha==vector.Length-1)
              tiempoEjecución.Stop();
        }


   
    }
}
