using Soulsplit.Api.Utilitarios.Enumeraciones;
using Soulsplit.Api.Utilitarios.Enumeraciones.Configuraciones;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Soulsplit.Api.Utilitarios
{
    public static class ConfiguracionUsuario
    {
        public static string CrearClaveUsuario(string nombre, string apellido)
        {
            var codigoGenerado = string.Empty;
            Random aleatorio = new();
            for (int i = 0; i < 4; i++)
            {
                int numerosAleatorios = aleatorio.Next(0, 9);
                codigoGenerado += numerosAleatorios.ToString();
            }
            return string.Concat(CrearUsuario(nombre, apellido), codigoGenerado);
        }

        public static string CrearCodigoReferencia(string nombre)
        {
            var codigoGenerado = string.Empty;
            Random aleatorio = new();
            for (int i = 0; i < 4; i++)
            {
                int numerosAleatorios = aleatorio.Next(0, 100);
                codigoGenerado += numerosAleatorios.ToString();
            }
            return string.Concat(nombre.Substring(0, 3).ToUpper(), codigoGenerado);
        }

        public static string GenerarCodigoRandomico(short longitud)
        {
            string[] letras = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            var codigoGenerado = string.Empty;
            Random aleatorio = new();

            for (int i = 0; i < longitud; i++)
            {
                int letrasAleatorias = aleatorio.Next(0, 100);
                int numerosAleatorios = aleatorio.Next(0, 9);

                if (letrasAleatorias < letras.Length)
                {
                    codigoGenerado += letras[letrasAleatorias];
                }
                else
                {
                    codigoGenerado += numerosAleatorios.ToString();
                }
            }
            return codigoGenerado;
        }
        public static string CrearUsuario(string nombre, string apellido)
        => string.Concat(nombre, ".", apellido).ToLower();

        public static double ValidarCaducidadCodigoIngreso(DateTime fechaCodigoGenerado)
        {
            TimeSpan span = DateTime.Now - fechaCodigoGenerado;
            return span.TotalMinutes;
        }

        public static string CreateMD5Hash(string input)
        {
            // Step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static bool ValidarIdentificacion(string idenficacion, string tipoDocumento, string pais)
        {
            if (tipoDocumento.Equals(ExtensionEnum.ObtenerDescripcion(TipoDocumentoIdentificacion.PASAPORTE)))
                return true;
            if (pais.Equals(ExtensionEnum.ObtenerDescripcion(CodigoPais.ECUADOR)))
                return ValidarIdentificacionEcuador(idenficacion, tipoDocumento);
            return true;
        }

        static bool ValidarIdentificacionEcuador(string idenficacion, string tipoDocumento)
        {
            int indice = 0, suma = 0, residuo = 0, verificador = 0, num, numProvincias = 24;
            int[] peso_natural = new int[] { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int[] peso_juridica = new int[] { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int[] peso_publica = new int[] { 3, 2, 7, 6, 5, 4, 3, 2 };
            char tipoPersona = 'C';
            idenficacion = idenficacion?.Trim();

            if (string.IsNullOrEmpty(tipoDocumento))
                return false;

            if (string.IsNullOrEmpty(idenficacion) || !idenficacion.All(char.IsDigit))
                return false;

            if (!int.TryParse(idenficacion.Substring(2, 1), out num))
                return false;
            if (tipoDocumento.Equals(ExtensionEnum.ObtenerDescripcion(TipoDocumentoIdentificacion.CEDULA)) || tipoDocumento.Equals(ExtensionEnum.ObtenerDescripcion(TipoDocumentoIdentificacion.RUC)))
            {
                if (num < 6)
                    tipoPersona = 'N';
                if (num == 6)
                {
                    tipoPersona = 'P';
                    if (idenficacion?.Trim().Length == 10)
                        tipoPersona = 'N';
                }
                if (num == 9)
                    tipoPersona = 'J';

                if (tipoPersona.Equals('N'))
                {
                    num = int.Parse(idenficacion.Substring(0, 2));
                    if (num == 0)
                        return false;
                    for (int i = 0; i < 9; i++)
                    {
                        num = int.Parse(idenficacion.Substring(i, 1));
                        indice = num * peso_natural[i];
                        if (indice >= 10)
                            indice -= 9;
                        suma += indice;
                    }
                    residuo = suma % 10;
                    verificador = residuo == 0 ? 0 : 10 - residuo;
                    if (idenficacion.Length == 10 && verificador == int.Parse(idenficacion.Substring(9, 1)))
                    {
                        return true;
                    }
                    if (idenficacion.Length == 13)
                    {
                        num = int.Parse(idenficacion.Substring(10, 3));
                        if (num == 1 && verificador == int.Parse(idenficacion.Substring(9, 1)))
                        {
                            return true;
                        }
                    }
                }
                if (tipoPersona.Equals('P'))
                {
                    num = int.Parse(idenficacion.Substring(0, 2));
                    if (num == 0 || num > numProvincias)
                        return false;
                    for (int i = 0; i < 8; i++)
                    {
                        num = int.Parse(idenficacion.Substring(i, 1));
                        indice = num * peso_publica[i];
                        suma += indice;
                    }
                    residuo = suma % 11;
                    verificador = residuo == 0 ? 0 : 11 - residuo;
                    if (idenficacion.Length == 13)
                    {
                        num = int.Parse(idenficacion.Substring(9, 4));
                        if (num == 1 && verificador == int.Parse(idenficacion.Substring(8, 1)))
                            throw new Exception($"El documento {idenficacion} pertenece a una persona Jurídica");
                    }
                }
                if (tipoPersona.Equals('J'))
                {
                    num = int.Parse(idenficacion.Substring(0, 2));
                    if (num == 0 || num > numProvincias)
                        return false;
                    for (int i = 0; i < 9; i++)
                    {
                        num = int.Parse(idenficacion.Substring(i, 1));
                        indice = num * peso_juridica[i];
                        suma += indice;
                    }
                    residuo = suma % 11;
                    verificador = residuo == 0 ? 0 : 11 - residuo;
                    if (idenficacion.Length == 13)
                    {
                        num = int.Parse(idenficacion.Substring(10, 3));
                        if (num == 1 && verificador == int.Parse(idenficacion.Substring(9, 1)))
                            throw new Exception($"El documento {idenficacion} pertenece a una persona Jurídico");
                    }
                }
                return false;
            }
            else
                return true;
        }

    }
}
