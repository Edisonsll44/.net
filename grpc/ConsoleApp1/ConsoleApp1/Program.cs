

class Character
{
    public Character(string name, Category catg)
    {
        Name = name;
        Category = catg;
    }
    public string Name;
    public Category Category;
}
enum Category
{
    Knight, Archer, Thief, Mage
}

public class Execute
{
    static void Main()
    {
        List<Character> characters = new()
        {
            new Character("Arthur", Category.Knight),
            new Character("Lancelot", Category.Knight),
            new Character("Legolas", Category.Archer),
            new Character("Robin Hood", Category.Archer),
            new Character("Garrett", Category.Thief),
            new Character("Gandalf", Category.Mage),
            new Character("Merlin", Category.Mage)
        };
        ILookup<Category, Character> lookup = characters.ToLookup(x => x.Category);

        List<Character> knights = (List<Character>)lookup[Category.Knight];
        List<Character> archers = (List<Character>)lookup[Category.Archer];
        List<Character> thieves = (List<Character>)lookup[Category.Thief];
        List<Character> mages = (List<Character>)lookup[Category.Mage];
    }
}