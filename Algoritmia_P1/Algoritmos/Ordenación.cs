using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilidades;

namespace Algoritmos
{
    /// <summary>
    /// Clase ancestro de los distintos métodos de ordenación.
    /// </summary>
    /// <typeparam name="T">To genérico de datos.</typeparam>
    public abstract class Ordenación: IOrdenación
    {

        /// <summary>
        /// Número de comparaciones que realiza un método.
        /// </summary>
        protected int nComparaciones;

        /// <summary>
        /// Número de intercambios que realiza un método.
        /// </summary>
        protected int nIntercambios;

        /// <summary>
        /// Tiempo que tarda en ejecutarse un determinado algoritmo.
        /// </summary>
        protected NanoTemporizador tiempoEjecución;


        /// <summary>
        /// Criterio de ordenación con el que se ordenará el vector.
        /// </summary>
        protected Orden orden;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="orden">Criterio de ordenación.</param>
        public Ordenación(Orden orden)
        {
            nComparaciones = 0;
            nIntercambios = 0;
            this.orden = orden;
            tiempoEjecución = new NanoTemporizador();
        }

        /// <summary>
        /// Ordena el vector que recibe.
        /// </summary>
        /// <param name="vector">Vector a ordenar.</param>
        public abstract void Ordenar(int[] vector);


        /// <summary>
        /// Propiedad que establece y devuelve el criterio de ordenación de un vector.
        /// </summary>
        public Orden Orden
        {
            get
            {
                return this.orden;
            }
            set
            {
                this.orden = value;
            }
        }


        /// <summary>
        /// Propiedad que devuelve el número de intercambios realizados en la ordenación.
        /// </summary>
        public int NIntercambios 
        {
            get
            {
                return this.nIntercambios;
            }
        }

        /// <summary>
        /// Propiedad que devuelve el número de comparaciones realizadas en la ordenación.
        /// </summary>
        public int NComparaciones
        {
            get
            {
                return this.nComparaciones;
            }
        }

        /// <summary>
        /// Propiedad para obtener el tiempo de ejecución.
        /// </summary>
        public NanoTemporizador TiempoEjecución
        {
            get
            {
                return this.tiempoEjecución;
            }
        }

    }
}
