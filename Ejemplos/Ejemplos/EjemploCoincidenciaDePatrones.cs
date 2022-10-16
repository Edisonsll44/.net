using System;

namespace Ejemplos
{

    public class EjemploCoincidenciaDePatrones
    {

        public string ObtenerPropiedadesPais()
        {
            var pais = new Pais { Id = 1, Nombre = "Ecuador", Nacionalidad = "Ecuatoriana", TieneBandera = true, Continente = "América", Poblacion = 10000 };
            //return IdentificarNivelPoblacionPais(pais);
            return IdentificarNivelPoblacionDeUnPais(null);
        }

        string IdentificarNivelPoblacionPais(Pais pais) => pais.Poblacion switch
        {
            < 1000 => "Menos poblado",
            >= 10000 and <= 40000 => "Población normal",
            > 40000 => "Sobre población",
            _ => "Error de búsqueda"
        };


        string IdentificarNivelPoblacionDeUnPais(object pais) =>
            pais switch
            {
                Pais p => p.Poblacion switch
                {
                    < 1000 => "Menos poblado",
                    >= 10000 and <= 40000 => "Población normal",
                    > 40000 => "Sobre población",
                    _ => "Error de búsqueda"
                },
                not null => throw new ArgumentException("Not a known place type", nameof(pais)),
                null => throw new ArgumentNullException(nameof(pais))
            };

        public static Quadrant ValidarPatronPosicional(Point point) => point switch
        {
            (0, 0) => Quadrant.Origin,
            var (x, y) when x > 0 && y > 0 => Quadrant.One,
            var (x, y) when x < 0 && y > 0 => Quadrant.Two,
            var (x, y) when x < 0 && y < 0 => Quadrant.Three,
            var (x, y) when x > 0 && y < 0 => Quadrant.Four,
            var (_, _) => Quadrant.OnBorder,
            _ => Quadrant.Unknown
        };

        public static string EjecutarPatronTupla(string first, string second) => (first, second)
        switch
        {
            ("rock", "paper") => "rock is covered by paper. Paper wins.",
            ("rock", "scissors") => "rock breaks scissors. Rock wins.",
            ("paper", "rock") => "paper covers rock. Paper wins.",
            ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
            ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
            ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
            (_, _) => "tie"
        };


        public static decimal EjecutarPatronespropiedad(Pais location, decimal salePrice) => location switch
        {
            { Continente: "WA" } => salePrice * 0.06M,
            { Continente: "MN" } => salePrice * 0.075M,
            { Continente: "MI" } => salePrice * 0.05M,
            _ => 0M
        };
    }
}
