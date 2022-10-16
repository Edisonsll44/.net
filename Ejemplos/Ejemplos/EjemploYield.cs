using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos
{
    public class EjemploYield
    {
        public IEnumerable<int> ObtenerDatosCarga(int tope)
        {
            var lista = new List<int>();
            if (tope > 0)
            {
                for (int i = 0; i <= tope; i++)
                {
                    Console.WriteLine("Carga por lista => {0}", i);
                    lista.Add(i);
                }
                return lista;
            }
            return null;
        }

        public IEnumerable<int> ObtenerDatosCargaYield(int tope)
        {
            if (tope > 0)
            {
                for (int i = 0; i <= tope; i++)
                {
                    Console.WriteLine("Carga por yield => {0}", i);
                    yield return i;
                }
            }
        }
    }
}
