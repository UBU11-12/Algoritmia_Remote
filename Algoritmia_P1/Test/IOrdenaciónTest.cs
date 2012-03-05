using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Test
{

    /// <summary>
    /// Interfaz IOrdenaciónTest.
    /// </summary>
    public interface IOrdenaciónTest
    {
        /// <summary>
        /// Inicialización previa.
        /// </summary>
        void Inciar();

        /// <summary>
        /// Test que valida el funcionamiento del constructor.
        /// </summary>
        void constructorCorrecto();

        /// <summary>
        /// Test que valida el fucionamiento de la propiedad Orden.
        /// </summary>
        void TestOrden();

        /// <summary>
        /// Test que verifica la ordenación de un vector de 10 elementos con datos int  
        /// en orden ascendente.
        /// </summary>
        void TestCorrectoAscendenteInt10();

        /// <summary>
        /// Test que verifica la ordenación de un vector de 1000 elementos con datos int
        /// en orden ascendente.
        /// </summary>
        void TestCorrectoAscendenteInt1000();

        /// <summary>
        /// Test que verifica la ordenación de un vector de 10 elementos con datos int
        /// en orden descendente.
        /// </summary>
        void TestDescendenteInt10();

        /// <summary>
        /// Test que verifica la ordenación de un vector de 1000 elementos con datos int
        /// en orden descendente.
        /// </summary>
        void TestDescendenteInt1000();

        

      

        /// <summary>
        /// Test que verifica la ordenación en orden descendente de un vector con datos
        /// int previamente ordenado en orden ascendente.
        /// </summary>
        void TestOrdenaInversoAscToDescInt();

        /// <summary>
        /// Test que verifica la ordenación en orden asscendente de un vector con datos
        /// int previamente ordenado en orden descendente.
        /// </summary>
        void TestOrdenaInversoDescToAscInt();

        /// <summary>
        /// Test que verifica que no se realiza ningún intercambio cuando un vector int
        /// está ordenado en orden ascendente.
        /// </summary>
        void nIntercambiosVectorOrdenadoAscendenteInt();

        /// <summary>
        /// Test que verifica que no se realiza ningún intercambio cuando un vector int
        /// está ordenado en orden descendente.
        /// </summary>
        void nIntercambiosVectorOrdenadoDescendenteInt();

        /// <summary>
        /// Test que verifica que se realizan más comparaciones en un vector de 1000 datos
        /// int que en otro de 10 en orden ascendente.
        /// </summary>
        void nComparacionesVectoresIntAscendente();

        /// <summary>
        /// Test que verifica que se realizan más comparaciones en un vector de 1000 datos
        /// int que en otro de 10 en orden descendente.
        /// </summary>
        void nComparacionesVectoresIntDescendente();

    
    
    }
}
