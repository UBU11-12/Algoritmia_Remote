using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Utilidades
{
    /// <summary>
    /// Clase para medir el tiempo de ejecución de los métodos de ordenación.
    /// </summary>
    public class NanoTemporizador
    {
        /// <summary>
        /// Obtiene la frecuencia del procesador 
        /// </summary>
        /// <param name="frequency">variable donde retorna la frecuencia</param>
        /// <returns>True si el procesador tiene contador de frecuencia, false sino</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool QueryPerformanceFrequency(out long frequency);

        /// <summary>
        /// Obtiene l evalor actual del contador de alto rendimiento del ptrocesador
        /// </summary>
        /// <param name="lpPerformanceCount">variable donde retorna el valor</param>
        /// <returns>True si todo salio OK, false sino</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        /// <summary>
        /// Almacena la frecuencia del contador de alto rendimiento.
        /// </summary>
        private static long _frecuencia;

        /// <summary>
        /// Almacena el valor de conteo inicial.
        /// </summary>
 
        private long _conteoInicial;

        /// <summary>
        /// Almacena el valor de conteo final.
        /// </summary>
        private long _conteoFinal;

        /// <summary>
        /// Indica si ya se ha inicializado el timer.
        /// </summary>
        private bool _isRunning = false;

        /// <summary>
        /// Indica si ya se ha inicializado el timer.
        /// </summary>
        public bool IsRunning { get { return _isRunning; } }

        /// <summary>
        /// Valor por el cual se mulTlican segundos para pasarlos a nanosegundos.
        /// </summary>
        private const long NANOSEGUNDOS = 1000000000L;

        /// <summary>
        /// Valor por el cual se mulTlican segundos para pasarlos a milisegundos.
        /// </summary>
        private const long MILISEGUNDOS = 1000L;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        static NanoTemporizador()
        {
            if (!QueryPerformanceFrequency(out _frecuencia))
                throw new NullReferenceException(
                   "Este componente se hizo para utilizar contadores de alto rendimiento. Como no los hay mejor utiliza StopWatch."
                );
        }

        /// <summary>
        /// Inicia el conteo del temporizador.
        /// </summary>
        public void Start()
        {
            if (!_isRunning)
            {
                QueryPerformanceCounter(out _conteoInicial);
                _isRunning = true;
            }
        }

        /// <summary>
        /// Detiene el conteo del temporizador.
        /// </summary>
        public void Stop()
        {
            if (_isRunning)
            {
                QueryPerformanceCounter(out _conteoFinal);
                _isRunning = false;
            }
        }

        /// <summary>
        /// Retorna la cantidad de nanosegundos contados.
        /// </summary>
        public double ElapsedNanoseconds
        {
            get
            {
                return (_conteoFinal - _conteoInicial) * NANOSEGUNDOS
                       / (double)_frecuencia;
            }
        }

        /// <summary>
        /// Retorna la cantidad de milisegundos contados.
        /// </summary>
        public double ElapsedMilliseconds
        {
            get
            {
                return (_conteoFinal - _conteoInicial) * MILISEGUNDOS
                       / (double)_frecuencia;
            }
        }

        /// <summary>
        /// Retorna la cantidad de segundos contados.
        /// </summary>
        public double ElapsedSeconds
        {
            get
            {
                return (_conteoFinal - _conteoInicial) / (double)_frecuencia;
            }
        }
    }



}
