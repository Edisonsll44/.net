using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos
{
    public class EjemploReflexion
    {
        public string MirarCaracteristicasDePais()
        {
            var resultado = string.Empty;
            var pais = new Pais { Id = 1, Nombre = "Ecuador", Nacionalidad = "Ecuatoriana", TieneBandera = true, Continente = "América" , Poblacion = 10000 };
            var propiedades = typeof(Pais).GetProperties();
            foreach (var propiedad in propiedades)
            {
                string nombrePropiedad = propiedad.Name;
                string tipoPropiedad = propiedad.PropertyType.ToString();
                string valor = propiedad.GetValue(pais).ToString();
                resultado += "Nombre: " + nombrePropiedad + " tipo: " + tipoPropiedad + " valor: " + valor + "\n";
            }
            return resultado;
        }
    }

    public class Pais
    {
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public bool TieneBandera { get; set; }
        public long Id { get; set; }
        public string Continente { get; set; }
        public int Poblacion { get; set; }
    }
}
