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
    /// Pruebas sobre la clase Selección.
    /// </summary>
    [TestFixture]
    public class SelecciónTest : OrdenaciónTest
    {
        #region variables

        /// <summary>
        /// Objeto Selección Tipo int.
        /// </summary>
        Selección SelecciónInt;


        #endregion

        /// <summary>
        /// Test que valida el funcionamiento del constructor.
        /// </summary>
        [Test]
        public override void constructorCorrecto()
        {
            Orden ordenAsc = Orden.Ascendente;
            SelecciónInt = new Selección(Orden.Ascendente);
            Assert.AreEqual(ordenAsc, SelecciónInt.Orden);
            Orden ordenDesc = Orden.Descendente;
            SelecciónInt = new Selección(Orden.Descendente);
            Assert.AreEqual(ordenDesc, SelecciónInt.Orden);
        }

        /// <summary>
        /// Test que valida el fucionamiento de la propiedad Orden.
        /// </summary>
        [Test]
        public override void TestOrden()
        {
            Orden ascendente = Orden.Ascendente;
            Orden descendente = Orden.Descendente;
            SelecciónInt = new Selección(Orden.Ascendente);
            Assert.AreEqual(SelecciónInt.Orden, ascendente);
            SelecciónInt.Orden = descendente;
            Assert.AreEqual(SelecciónInt.Orden, descendente);
        }

        /// <summary>
        /// Test que verifica la ordenación de un vector de 10 elementos con datos int  
        /// en orden ascendente.
        /// </summary>
        [Test]
        public override void TestCorrectoAscendenteInt10()
        {
            SelecciónInt = new Selección(Orden.Ascendente);
            datosInt10.insertaAleatorio();
            SelecciónInt.Ordenar((int[])datosInt10.Vector);
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
            SelecciónInt = new Selección(Orden.Ascendente);
            datosInt1000.insertaAleatorio();
            SelecciónInt.Ordenar((int[])datosInt1000.Vector);
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
            SelecciónInt = new Selección(Orden.Descendente);
            datosInt10.insertaAleatorio();
            SelecciónInt.Ordenar((int[])datosInt10.Vector);
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
            SelecciónInt = new Selección(Orden.Descendente);
            datosInt1000.insertaAleatorio();
            SelecciónInt.Ordenar((int[])datosInt1000.Vector);
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
            SelecciónInt = new Selección(Orden.Ascendente);
            datosIntAscendente.insertaAleatorio();
            SelecciónInt.Ordenar((int[])datosIntAscendente.Vector);
            SelecciónInt.Orden = Orden.Descendente;
            SelecciónInt.Ordenar((int[])datosIntAscendente.Vector);
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
            SelecciónInt = new Selección(Orden.Descendente);
            datosIntDescendente.insertaAleatorio();
            SelecciónInt.Ordenar((int[])datosIntDescendente.Vector);
            SelecciónInt.Orden = Orden.Ascendente;
            SelecciónInt.Ordenar((int[])datosIntDescendente.Vector);
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
            SelecciónInt = new Selección(Orden.Ascendente);
            SelecciónInt.Ordenar(vectorOrdenado);
            Assert.True(SelecciónInt.NIntercambios == 0);
        }

        /// <summary>
        /// Test que verifica que no se realiza ningún intercambio cuando un vector int
        /// está ordenado en orden descendente.
        /// </summary>
        [Test]
        public override void nIntercambiosVectorOrdenadoDescendenteInt()
        {
            int[] vectorOrdenado = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            SelecciónInt = new Selección(Orden.Descendente);
            SelecciónInt.Ordenar(vectorOrdenado);
            Assert.True(SelecciónInt.NIntercambios == 0);
        }

        

        /// <summary>
        /// Test que verifica que se realizan más comparaciones en un vector de 1000 datos
        /// int que en otro de 10 en orden ascendente.
        /// </summary>
        [Test]
        public override void nComparacionesVectoresIntAscendente()
        {
            SelecciónInt = new Selección(Orden.Ascendente);
            datosInt10.insertaAleatorio();
            SelecciónInt.Ordenar((int[])datosInt10.Vector);
            int numComparaciones10 = SelecciónInt.NComparaciones;
            datosInt1000.insertaAleatorio();
            SelecciónInt.Ordenar((int[])datosInt1000.Vector);
            int numComparaciones1000 = SelecciónInt.NComparaciones;
            Assert.True(numComparaciones1000 > numComparaciones10);
        }

        /// <summary>
        /// Test que verifica que se realizan más comparaciones en un vector de 1000 datos
        /// int que en otro de 10 en orden descendente.
        /// </summary>
        [Test]
        public override void nComparacionesVectoresIntDescendente()
        {
            SelecciónInt = new Selección(Orden.Descendente);
            datosInt10.insertaAleatorio();
            SelecciónInt.Ordenar((int[])datosInt10.Vector);
            int numComparaciones10 = SelecciónInt.NComparaciones;
            datosInt1000.insertaAleatorio();
            SelecciónInt.Ordenar((int[])datosInt1000.Vector);
            int numComparaciones1000 = SelecciónInt.NComparaciones;
            Assert.True(numComparaciones1000 > numComparaciones10);
        }

        
    }
}
