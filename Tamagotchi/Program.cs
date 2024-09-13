Tamagotchi tama = new("");
tama.Tick();
Console.WriteLine("What do you want your Tamagotchi to be called?");
tama.Name = Console.ReadLine();
Console.WriteLine($"{tama.Name} is such a cute name!");
while (tama.GetAlive() == true)
{
    tama.PrintStats();
    Console.WriteLine($"What do you want to do with {tama.Name}");
    Console.WriteLine($"1. Feed {tama.Name}!");
    Console.WriteLine($"2. Play with {tama.Name}!");
    Console.WriteLine($"3. Teach {tama.Name} a new word!");
    Console.WriteLine($"4. Sit still with {tama.Name}!");
    if (tama.hasGambling == true)
    {
        Console.WriteLine($"5. Gamble with {tama.Name}!");
    }
    int action = Console.ReadLine().IndexOf("");
    if (action == 1) { tama.Feed(); tama.Tick(); }
    else if (action == 2) { tama.ReduceBoredom(); tama.Tick(); }
    else if (action == 3) { tama.Teach(); tama.Tick(); }
    else if (action == 4) { tama.Tick(); }
    else if (action == 5 && tama.hasGambling == true) { tama.Gambling(); }
}
Console.ReadLine();