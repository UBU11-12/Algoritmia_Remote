using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Algoritmos
{
    /// <summary>
    /// Enumeración del To de Orden.
    /// </summary>
    public enum Orden
    {
        /// <summary>
        /// Si el criterio de ordenación es Ascendente.
        /// </summary>
        Ascendente,

        /// <summary>
        /// Si el criterio de ordenación es Descendente.
        /// </summary>
        Descendente,
    }

    /// <summary>
    /// Muestra una colección de elementos genéricos distribuidos en una ordenación. 
    /// </summary>
    /// <typeparam name="T">Tipo de datos genérico.</typeparam>
    interface IOrdenación 
    {
        /// <summary>
        /// Ordena el vector recibido.
        /// </summary>
        /// <param name="vector">Vector que ordena el método.</param>
        void Ordenar(int[] vector);


    }
}
