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
    /// Pruebas sobre la clase Inserción.
    /// </summary>
    [TestFixture]
    public class InserciónTest : OrdenaciónTest
    {
        #region variables

        /// <summary>
        /// Objeto Inserción Tipo int.
        /// </summary>
        Inserción InserciónInt;


        #endregion

        /// <summary>
        /// Test que valida el funcionamiento del constructor.
        /// </summary>
        [Test]
        public override void constructorCorrecto()
        {
            Orden ordenAsc = Orden.Ascendente;
            InserciónInt = new Inserción(Orden.Ascendente);
            Assert.AreEqual(ordenAsc, InserciónInt.Orden);
            Orden ordenDesc = Orden.Descendente;
            InserciónInt = new Inserción(Orden.Descendente);
            Assert.AreEqual(ordenDesc, InserciónInt.Orden);
        }

        /// <summary>
        /// Test que valida el fucionamiento de la propiedad Orden.
        /// </summary>
        [Test]
        public override void TestOrden()
        {
            Orden ascendente = Orden.Ascendente;
            Orden descendente = Orden.Descendente;
            InserciónInt = new Inserción(Orden.Ascendente);
            Assert.AreEqual(InserciónInt.Orden, ascendente);
            InserciónInt.Orden = descendente;
            Assert.AreEqual(InserciónInt.Orden, descendente);
        }

        /// <summary>
        /// Test que verifica la ordenación de un vector de 10 elementos con datos int  
        /// en orden ascendente.
        /// </summary>
        [Test]
        public override void TestCorrectoAscendenteInt10()
        {
            InserciónInt = new Inserción(Orden.Ascendente);
            datosInt10.insertaAleatorio();
            InserciónInt.Ordenar((int[])datosInt10.Vector);
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
            InserciónInt = new Inserción(Orden.Ascendente);
            datosInt1000.insertaAleatorio();
            InserciónInt.Ordenar((int[])datosInt1000.Vector);
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
            InserciónInt = new Inserción(Orden.Descendente);
            datosInt10.insertaAleatorio();
            InserciónInt.Ordenar((int[])datosInt10.Vector);
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
            InserciónInt = new Inserción(Orden.Descendente);
            datosInt1000.insertaAleatorio();
            InserciónInt.Ordenar((int[])datosInt1000.Vector);
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
            InserciónInt = new Inserción(Orden.Ascendente);
            datosIntAscendente.insertaAleatorio();
            InserciónInt.Ordenar((int[])datosIntAscendente.Vector);
            InserciónInt.Orden = Orden.Descendente;
            InserciónInt.Ordenar((int[])datosIntAscendente.Vector);
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
            InserciónInt = new Inserción(Orden.Descendente);
            datosIntDescendente.insertaAleatorio();
            InserciónInt.Ordenar((int[])datosIntDescendente.Vector);
            InserciónInt.Orden = Orden.Ascendente;
            InserciónInt.Ordenar((int[])datosIntDescendente.Vector);
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
            InserciónInt = new Inserción(Orden.Ascendente);
            InserciónInt.Ordenar(vectorOrdenado);
            Assert.True(InserciónInt.NIntercambios == 0);
        }

        /// <summary>
        /// Test que verifica que no se realiza ningún intercambio cuando un vector int
        /// está ordenado en orden descendente.
        /// </summary>
        [Test]
        public override void nIntercambiosVectorOrdenadoDescendenteInt()
        {
            int[] vectorOrdenado = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            InserciónInt = new Inserción(Orden.Descendente);
            InserciónInt.Ordenar(vectorOrdenado);
            Assert.True(InserciónInt.NIntercambios == 0);
        }


        /// <summary>
        /// Test que verifica que se realizan más comparaciones en un vector de 1000 datos
        /// int que en otro de 10 en orden ascendente.
        /// </summary>
        [Test]
        public override void nComparacionesVectoresIntAscendente()
        {
            InserciónInt = new Inserción(Orden.Ascendente);
            datosInt10.insertaAleatorio();
            InserciónInt.Ordenar((int[])datosInt10.Vector);
            int numComparaciones10 = InserciónInt.NComparaciones;
            datosInt1000.insertaAleatorio();
            InserciónInt.Ordenar((int[])datosInt1000.Vector);
            int numComparaciones1000 = InserciónInt.NComparaciones;
            Assert.True(numComparaciones1000 > numComparaciones10);
        }

        /// <summary>
        /// Test que verifica que se realizan más comparaciones en un vector de 1000 datos
        /// int que en otro de 10 en orden descendente.
        /// </summary>
        [Test]
        public override void nComparacionesVectoresIntDescendente()
        {
            InserciónInt = new Inserción(Orden.Descendente);
            datosInt10.insertaAleatorio();
            InserciónInt.Ordenar((int[])datosInt10.Vector);
            int numComparaciones10 = InserciónInt.NComparaciones;
            datosInt1000.insertaAleatorio();
            InserciónInt.Ordenar((int[])datosInt1000.Vector);
            int numComparaciones1000 = InserciónInt.NComparaciones;
            Assert.True(numComparaciones1000 > numComparaciones10);
        }
   
    }
}
