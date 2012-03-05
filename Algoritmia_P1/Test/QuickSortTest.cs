using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Algoritmos;
using Utilidades;

namespace Test
{
    /// <summary>
    /// Pruebas sobre la clase QuickSort.
    /// </summary>
    [TestFixture]
    public class QuickSortTest : OrdenaciónTest
    {
        #region variables

        /// <summary>
        /// Objeto QuickSort Tipo int.
        /// </summary>
        QuickSort QuickSortInt;


        #endregion


        /// <summary>
        /// Test que valida el funcionamiento del constructor.
        /// </summary>
        [Test]
        public override void constructorCorrecto()
        {
            Orden ordenAsc = Orden.Ascendente;
            QuickSortInt = new QuickSort(Orden.Ascendente);
            Assert.AreEqual(ordenAsc, QuickSortInt.Orden);
            Orden ordenDesc = Orden.Descendente;
            QuickSortInt = new QuickSort(Orden.Descendente);
            Assert.AreEqual(ordenDesc, QuickSortInt.Orden);
        }

        /// <summary>
        /// Test que valida el fucionamiento de la propiedad Orden.
        /// </summary>
        [Test]
        public override void TestOrden()
        {
            Orden ascendente = Orden.Ascendente;
            Orden descendente = Orden.Descendente;
            QuickSortInt = new QuickSort(Orden.Ascendente);
            Assert.AreEqual(QuickSortInt.Orden, ascendente);
            QuickSortInt.Orden = descendente;
            Assert.AreEqual(QuickSortInt.Orden, descendente);
        }

        /// <summary>
        /// Test que verifica la ordenación de un vector de 10 elementos con datos int  
        /// en orden ascendente.
        /// </summary>
        [Test]
        public override void TestCorrectoAscendenteInt10()
        {
            QuickSortInt = new QuickSort(Orden.Ascendente);
            datosInt10.insertaAleatorio();
            QuickSortInt.Ordenar((int[])datosInt10.Vector);
            for (int i = 1; i < datosInt10.Vector.Length; i++)
            {
                Assert.True((int)datosInt10.Vector.GetValue(i) >=
                    (int)datosInt10.Vector.GetValue(i - 1));
            }
        }

        /// <summary>
        /// Test que verifica la ordenación de un vector de 1000 elementos con datos int
        /// en orden ascendente.
        /// </summary>
        [Test]
        public override void TestCorrectoAscendenteInt1000()
        {
            QuickSortInt = new QuickSort(Orden.Ascendente);
            datosInt1000.insertaAleatorio();
            QuickSortInt.Ordenar((int[])datosInt1000.Vector);
            for (int i = 1; i < datosInt1000.Vector.Length; i++)
            {
                Assert.True((int)datosInt1000.Vector.GetValue(i) >=
                    (int)datosInt1000.Vector.GetValue(i - 1));
            }
        }


        /// <summary>
        /// Test que verifica la ordenación de un vector de 10 elementos con datos int
        /// en orden descendente.
        /// </summary>
        [Test]
        public override void TestDescendenteInt10()
        {
            QuickSortInt = new QuickSort(Orden.Descendente);
            datosInt10.insertaAleatorio();
            QuickSortInt.Ordenar((int[])datosInt10.Vector);
            for (int i = 1; i < datosInt10.Vector.Length; i++)
            {
                Assert.True((int)datosInt10.Vector.GetValue(i) <=
                    (int)datosInt10.Vector.GetValue(i - 1));
            }
        }

        /// <summary>
        /// Test que verifica la ordenación de un vector de 1000 elementos con datos int
        /// en orden descendente.
        /// </summary>
        [Test]
        public override void TestDescendenteInt1000()
        {
            QuickSortInt = new QuickSort(Orden.Descendente);
            datosInt1000.insertaAleatorio();
            QuickSortInt.Ordenar((int[])datosInt1000.Vector);
            for (int i = 1; i < datosInt1000.Vector.Length; i++)
            {
                Assert.True((int)datosInt1000.Vector.GetValue(i) <=
                    (int)datosInt1000.Vector.GetValue(i - 1));
            }
        }


        /// <summary>
        /// Test que verifica la ordenación en orden descendente de un vector con datos
        /// int previamente ordenado en orden ascendente.
        /// </summary>
        [Test]
        public override void TestOrdenaInversoAscToDescInt()
        {
            QuickSortInt = new QuickSort(Orden.Ascendente);
            datosIntAscendente.insertaAleatorio();
            QuickSortInt.Ordenar((int[])datosIntAscendente.Vector);
            QuickSortInt.Orden = Orden.Descendente;
            QuickSortInt.Ordenar((int[])datosIntAscendente.Vector);
            for (int i = 1; i < datosIntAscendente.Vector.Length; i++)
            {
                Assert.True((int)datosIntAscendente.Vector.GetValue(i) <=
                     (int)datosIntAscendente.Vector.GetValue(i - 1));
            }
        }

        /// <summary>
        /// Test que verifica la ordenación en orden asscendente de un vector con datos
        /// int previamente ordenado en orden descendente.
        /// </summary>
        [Test]
        public override void TestOrdenaInversoDescToAscInt()
        {
            QuickSortInt = new QuickSort(Orden.Descendente);
            datosIntDescendente.insertaAleatorio();
            QuickSortInt.Ordenar((int[])datosIntDescendente.Vector);
            QuickSortInt.Orden = Orden.Ascendente;
            QuickSortInt.Ordenar((int[])datosIntDescendente.Vector);
            for (int i = 1; i < datosIntDescendente.Vector.Length; i++)
            {
                Assert.True((int)datosIntDescendente.Vector.GetValue(i) >=
                    (int)datosIntDescendente.Vector.GetValue(i - 1));
            }
        }

 

        /// <summary>
        /// Test que verifica que no se realiza ningún intercambio cuando un vector int
        /// está ordenado en orden ascendente.
        /// </summary>
        [Test]
        public override void nIntercambiosVectorOrdenadoAscendenteInt()
        {
            int[] vectorOrdenado = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            QuickSortInt = new QuickSort(Orden.Ascendente);
            QuickSortInt.Ordenar(vectorOrdenado);
            Assert.True(QuickSortInt.NIntercambios == 0);
        }

        /// <summary>
        /// Test que verifica que no se realiza ningún intercambio cuando un vector int
        /// está ordenado en orden descendente.
        /// </summary>
        [Test]
        public override void nIntercambiosVectorOrdenadoDescendenteInt()
        {
            int[] vectorOrdenado = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            QuickSortInt = new QuickSort(Orden.Descendente);
            QuickSortInt.Ordenar(vectorOrdenado);
            Assert.True(QuickSortInt.NIntercambios == 0);
        }

 

        /// <summary>
        /// Test que verifica que se realizan más comparaciones en un vector de 1000 datos
        /// int que en otro de 10 en orden ascendente.
        /// </summary>
        [Test]
        public override void nComparacionesVectoresIntAscendente()
        {
            QuickSortInt = new QuickSort(Orden.Ascendente);
            datosInt10.insertaAleatorio();
            QuickSortInt.Ordenar((int[])datosInt10.Vector);
            int numComparaciones10 = QuickSortInt.NComparaciones;
            datosInt1000.insertaAleatorio();
            QuickSortInt.Ordenar((int[])datosInt1000.Vector);
            int numComparaciones1000 = QuickSortInt.NComparaciones;
            Assert.True(numComparaciones1000 > numComparaciones10);
        }

        /// <summary>
        /// Test que verifica que se realizan más comparaciones en un vector de 1000 datos
        /// int que en otro de 10 en orden descendente.
        /// </summary>
        [Test]
        public override void nComparacionesVectoresIntDescendente()
        {
            QuickSortInt = new QuickSort(Orden.Descendente);
            datosInt10.insertaAleatorio();
            QuickSortInt.Ordenar((int[])datosInt10.Vector);
            int numComparaciones10 = QuickSortInt.NComparaciones;
            datosInt1000.insertaAleatorio();
            QuickSortInt.Ordenar((int[])datosInt1000.Vector);
            int numComparaciones1000 = QuickSortInt.NComparaciones;
            Assert.True(numComparaciones1000 > numComparaciones10);
        }
    }
}
