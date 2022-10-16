namespace Ejemplos
{
    class EjemploNullCoalescingOperator
    {
        public int RevisarValoresNulos(int? a, int b)
        {
            return a ?? b;
        }

        public int RevisarValoresDeObjetosNulos(int? a)
        {
            return a.GetValueOrDefault();
        }
    }
}
