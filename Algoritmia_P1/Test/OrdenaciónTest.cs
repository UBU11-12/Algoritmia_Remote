using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilidades;
using NUnit.Framework;
using Algoritmos;

namespace Test
{
    /// <summary>
    /// Clase que testea los diferentes métodos de ordenación.
    /// </summary>
    public abstract class OrdenaciónTest
    {

        #region variables

        /// <summary>
        /// Objeto para procesar datos int de longitud 10.
        /// </summary>
        public EntradaDatos datosInt10;

        /// <summary>
        /// Objeto para procesar datos int de longitud 1000.
        /// </summary>
        public EntradaDatos datosInt1000;


        /// <summary>
        /// Objeto para procesar datos int en orden ascendente.
        /// </summary>
        public EntradaDatos datosIntAscendente;

        /// <summary>
        /// Objeto para procesar datos int en orden descendente.
        /// </summary>
        public EntradaDatos datosIntDescendente;


        #endregion

        /// <summary>
        /// Inicialización previa.
        /// </summary>
        [SetUp]
        public void Inciar()
        {

            datosInt10 = new EntradaDatos( 10);
            datosInt1000 = new EntradaDatos(1000);
            datosIntAscendente = new EntradaDatos(1000);
            datosIntDescendente = new EntradaDatos(1000);
        }


        /// <summary>
        /// Test que valida el funcionamiento del constructor.
        /// </summary>
        public abstract void constructorCorrecto();

        /// <summary>
        /// Test que valida el fucionamiento de la propiedad Orden.
        /// </summary>
        public abstract void TestOrden();

        /// <summary>
        /// Test que verifica la ordenación de un vector de 10 elementos con datos int  
        /// en orden ascendente.
        /// </summary>
        public abstract void TestCorrectoAscendenteInt10();

        /// <summary>
        /// Test que verifica la ordenación de un vector de 1000 elementos con datos int
        /// en orden ascendente.
        /// </summary>
        public abstract void TestCorrectoAscendenteInt1000();

        /// <summary>
        /// Test que verifica la ordenación de un vector de 10 elementos con datos int
        /// en orden descendente.
        /// </summary>
        public abstract void TestDescendenteInt10();

        /// <summary>
        /// Test que verifica la ordenación de un vector de 1000 elementos con datos int
        /// en orden descendente.
        /// </summary>
        public abstract void TestDescendenteInt1000();


        /// <summary>
        /// Test que verifica la ordenación en orden descendente de un vector con datos
        /// int previamente ordenado en orden ascendente.
        /// </summary>
        public abstract void TestOrdenaInversoAscToDescInt();

        /// <summary>
        /// Test que verifica la ordenación en orden asscendente de un vector con datos
        /// int previamente ordenado en orden descendente.
        /// </summary>
        public abstract void TestOrdenaInversoDescToAscInt();

       

        /// <summary>
        /// Test que verifica que no se realiza ningún intercambio cuando un vector int
        /// está ordenado en orden ascendente.
        /// </summary>
        public abstract void nIntercambiosVectorOrdenadoAscendenteInt();

        /// <summary>
        /// Test que verifica que no se realiza ningún intercambio cuando un vector int
        /// está ordenado en orden descendente.
        /// </summary>
        public abstract void nIntercambiosVectorOrdenadoDescendenteInt();

       

        /// <summary>
        /// Test que verifica que se realizan más comparaciones en un vector de 1000 datos
        /// int que en otro de 10 en orden ascendente.
        /// </summary>
        public abstract void nComparacionesVectoresIntAscendente();

        /// <summary>
        /// Test que verifica que se realizan más comparaciones en un vector de 1000 datos
        /// int que en otro de 10 en orden descendente.
        /// </summary>
        public abstract void nComparacionesVectoresIntDescendente();

    }
}
