using ConsoleApp1.Models;

namespace ConsoleApp1;

public static class Database
{
    public static List<Animal> Animals = new List<Animal>()
    {
        new Animal(1, "Reksio", "pies", 12.5, "brązowy"),
        new Animal(2, "Mruczek", "kot", 5.3, "biały"),
        new Animal(3, "Mruczek", "kot", 5, "czarny")
    };

    public static List<Visit> Visits = new List<Visit>()
    {
        new Visit(1, 1, DateTime.Now.AddDays(-10), "Szczepienie", 100),
        new Visit(2, 2, DateTime.Now.AddDays(-5), "Kontrola ogólna", 80)
    };

}