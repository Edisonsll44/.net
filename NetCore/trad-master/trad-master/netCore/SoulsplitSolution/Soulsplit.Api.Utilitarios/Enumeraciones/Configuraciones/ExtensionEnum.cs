using System;
using System.Reflection;

namespace Soulsplit.Api.Utilitarios.Enumeraciones.Configuraciones
{
    public class ExtensionEnum : Attribute
    {
        internal ExtensionEnum(string descripcion, string codigo = "")
        {
            Codigo = codigo;
            Descripcion = descripcion;
        }
        public string Codigo { get; private set; }
        public string Descripcion { get; private set; }

        /// <summary>
        /// Obtiene el codigo de la enumeración
        /// </summary>
        /// <param name="value">enumeración</param>
        /// <returns>Codigo de la enumeración</returns>
        public static string ObtenerCodigo(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            ExtensionEnum[] attributes = (ExtensionEnum[])fi.GetCustomAttributes(typeof(ExtensionEnum), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Codigo;
            else
                return value.ToString();
        }

        /// <summary>
        /// Obtiene la descripción de la enumeración
        /// </summary>
        /// <param name="value">enumeración</param>
        /// <returns>Descripción de la enumeración</returns>
        public static string ObtenerDescripcion(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            ExtensionEnum[] attributes = (ExtensionEnum[])fi.GetCustomAttributes(typeof(ExtensionEnum), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Descripcion;
            else
                return value.ToString();
        }
    }
}
