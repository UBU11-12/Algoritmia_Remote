using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;


namespace Utilidades
{
    /// <summary>
    /// Procesa los datos con los que vamos a trabajar.
    /// </summary>
    public class EntradaDatos
    {
        /// <summary>
        /// Guarda los datos que usaremos.
        /// </summary>
        private Array vector;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="To">Tipo de datos que usaremos.</param>
        /// <param name="tam">Tamaño del vector.</param>
        public EntradaDatos(int tam)
        {
            this.vector = Array.CreateInstance(typeof(Int32), tam);
        }

        /// <summary>
        /// Genera los datos del vector de forma automática y aleatoria.
        /// </summary>
        public void insertaAleatorio()
        {
            int semilla = System.Convert.ToInt32(DateTime.Now.Millisecond);
            Random rnd = new Random(semilla);
            for (int i = 0; i < vector.Length; i++)
                vector.SetValue((int)(rnd.NextDouble() * 1000), i);
        }

        /// <summary>
        /// Genera los datos del vector de forma automática y ascendente.
        /// </summary>
        public void insertaAscendente()
        {
            int semilla = System.Convert.ToInt32(DateTime.Now.Millisecond);
            Random rnd = new Random(semilla);
            for (int i = 0; i < vector.Length; i++)
                vector.SetValue(i,i);
        }

        /// <summary>
        /// Genera los datos del vector de forma automática y descendente.
        /// </summary>
        public void insertaDescendente()
        {
            int semilla = System.Convert.ToInt32(DateTime.Now.Millisecond);
            Random rnd = new Random(semilla);
            int j = 0;
            for (int i = vector.Length; i > 0; i--)
            {
                vector.SetValue(i,j);
                j++;
            }
        }

        /// <summary>
        /// Propiedad que devuelve el vector.
        /// </summary>
        public Array Vector
        {
            get
            {
                return vector;
            }
            set
            {
                this.vector = value;
            }
        }
    }
}
