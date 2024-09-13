public class Tamagotchi
{
    private Random rnd = new Random();
    public string Name;
    private int hunger;
    private int boredom;
    private int money = 100;
    private List<string> words = new List<string>();
    private bool isAlive;
    public bool hasGambling = false;
    public Tamagotchi(string name)
    {
        Name = "";
    }
    public void PrintStats()
    { Console.WriteLine($" || {Name} || Hunger: {hunger} || Boredom: {boredom} || Money: {money} || Alive: {isAlive}"); }

    public void Feed()
    {
        hunger -= 3;
    }
    public void ReduceBoredom()
    {
        boredom -= 3;
    }
    public void Tick()
    {
        hunger += 1;
        boredom += 1;
        if (hunger < 0)
        {
            hunger = 0;
        }
        if (boredom < 0)
        {
            boredom = 0;
        }

        

        isAlive = hunger < 10 && boredom < 10;
    }
    public void Teach()
    {
        Console.WriteLine($"What do you want to teach {Name}");
        string toTeach = Console.ReadLine();
        if (toTeach == "gambling")
        {
            hasGambling = true;
            words.Add(toTeach);
        }
        else
        {
            words.Add(toTeach);
        }

        Console.WriteLine($"{Name} learned about {toTeach}, {Name} seems happier than before.");

        if (boredom > 5) { Console.WriteLine($"{Name}: {toTeach.ToLower()}! {toTeach.ToLower()}! "); }

        else { Console.WriteLine($"{Name}: {toTeach.ToUpper()}! {toTeach.ToUpper()}! "); }
    }

    public void Gambling()
    {
        Console.WriteLine($"{Name} is feeling lucky! They have ${money}.");
        Console.WriteLine("How much do they want to bet?");
        int betMoney = Console.ReadLine().IndexOf("");
        if (betMoney > money)
        {
            Console.WriteLine($"I'm sorry, {Name} doesn't seem to know about the conept of money, bet a smaller amount.");
        }
        else 
        {
            money =- betMoney;
            Console.WriteLine("They bet ${money}");
            Console.WriteLine("What color would you like to bet on? RED, BLACk or GREEN");
            string gamblingColor = Console.ReadLine().ToUpper();
            if (gamblingColor == "BLACK" || gamblingColor == "RED")
            {
                Console.WriteLine($"{Name} bets ${money} on {gamblingColor}! Let's get gambling!");
                int chance = rnd.Next(1, 2);
                if (chance > 1)
                {
                    Console.WriteLine("Won");
                    money = betMoney * 2 + money;
                }
                else 
                {
                    Console.WriteLine("Lost");
                }
            }
            else if (gamblingColor == "GREEN")
            {
                Console.WriteLine($"{Name} is feeling ballsy and bets ${money} on {gamblingColor}! Let's get gambling!");
                int chance = rnd.Next(1, 15);
                if (chance > 14)
                {
                    Console.WriteLine("Won");
                    money = betMoney * 15 + money;
                }
                else 
                {
                    Console.WriteLine("Lost");
                }
            }
        }
        

    }
    public bool GetAlive()
    {
        return isAlive;
    }
}