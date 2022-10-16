using System;
using System.Diagnostics;

namespace Ejemplos
{
    public class EjemploConstructorStatico
    {
        public EjemploConstructorStatico()
        {
            Stopwatch sw = new Stopwatch(); // Creación del Stopwatch.
            sw.Start(); // Iniciar la medición.
            sw.Stop(); // Detener la medición.
            Console.WriteLine("Time elapsed: {0}", sw.Elapsed.ToString("hh\\:mm\\:ss\\.fff")); // Mostrar el tiempo transcurriodo con un formato hh:mm:ss.000
            Console.WriteLine("Inicialización de objetos");
        }

        static EjemploConstructorStatico()
        {
            Stopwatch sw = new Stopwatch(); // Creación del Stopwatch.
            sw.Start(); // Iniciar la medición.
            sw.Stop(); // Detener la medición.
            Console.WriteLine("Time elapsed: {0}", sw.Elapsed.ToString("hh\\:mm\\:ss\\.fff")); // Mostrar el tiempo transcurriodo con un formato hh:mm:ss.000
            Console.WriteLine("Inicialización de tipo (static)");
        }
    }
}
