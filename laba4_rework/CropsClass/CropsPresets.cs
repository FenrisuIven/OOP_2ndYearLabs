namespace CropsClass;

public static class CropsPresets
{
    private static Random _rnd = new();
    public static string GetRandomName() => names[_rnd.Next(names.Length - 1)];
    public static string GetRandomCountry() => countries[_rnd.Next(countries.Length - 1)];
    public static Season GetRandomSeason() => (Season)_rnd.Next(3);
    
    
    public static string[] names =
    {
        "Carrot", "Beet Root", "Sunflower Seeds", "Corn", "Cucumber"
    };
    public static string[] countries =
    {
        "Ukraine", "Spain", "Netherlands", "Poland", "Czech"
    };
}