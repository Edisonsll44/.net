namespace Soulsplit.Api.Utilitarios
{
    public static class SoulSplitConstantes
    {
        public const string RutaActivarUsuario = "register/validate/";
        public const string RutaCambioClave = "password/reset/";
        public const string UrlValidacionTelefono = "http://apilayer.net/api/";
        public const string ParametrosValidacionTelefono = "validate?access_key={0}&number={1}&country_code={2}&format=1"; //Key Numverify, Número Validar, Código Pais
    }
    public static class Funcionalidades
    {
        public const string FuncionalidadCodigoReferido = "Codigo_Referido";
    }
}
