public class Weapon
{
    public string Name;
    public int MinDamage;
    public int MaxDamage;

    public Weapon(string name)
    {
        Name = "Axe";
        MinDamage = Random.Shared.Next(8, 12);
        MaxDamage = Random.Shared.Next(18, 25);
    }
    public int Attack()
    {
        Console.WriteLine($"Attacking with {Name}");

        return Random.Shared.Next(MinDamage, MaxDamage);
    }
}
