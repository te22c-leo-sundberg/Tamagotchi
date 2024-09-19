public class Tamagotchi
{
    private Random rnd = new Random();
    public string Name;
    private int hunger;
    private int boredom;
    private int money = 100;
    private int betMoney;
    private int winMultiplier;
    private List<string> words = new List<string>();
    private bool isAlive;
    public bool hasGambling = false;
    public bool hasNFT = false;
    public bool hasBitcoin = false;
    public Tamagotchi(string name)
    {
        Name = "";
    }
    public void PrintStats()
    { Console.WriteLine($" || {Name} || Hunger: {hunger} || Boredom: {boredom} || Money: ${money} || Alive: {isAlive}"); }

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
        if (toTeach.ToUpper() == "GAMBLING")
        {
            hasGambling = true;
            words.Add(toTeach);
        }
        else if (toTeach.ToUpper() == "NFT")
        {
            hasNFT = true;
            words.Add(toTeach);
        }
        else if (toTeach.ToUpper() == "BITCOIN")
        {
            hasBitcoin = true;
            words.Add(toTeach);
        }
        else
        {
            words.Add(toTeach);
        }

        Console.WriteLine($"{Name} learned about {toTeach}, {Name} seems happier than before.");

        if (boredom > 5) { Console.WriteLine($"{Name}: {toTeach.ToLower()}! {toTeach.ToLower()}! "); }

        else { Console.WriteLine($"{Name}: {toTeach.ToUpper()}! {toTeach.ToUpper()}! "); }

        ReduceBoredom();
    }
    public void Hi()
    {
        Console.WriteLine(words[Random.Shared.Next(0, words.Count)]);
        ReduceBoredom();
    }

    public void Gambling()
    {
        Console.WriteLine($"{Name} is feeling lucky! They have ${money}.");
        Console.WriteLine("How much do they want to bet?");
        int betMoney = Convert.ToInt32(Console.ReadLine());  
        if (betMoney > money)
        {
            Console.WriteLine($"I'm sorry, {Name} doesn't seem to know about the conept of money, bet a smaller amount.");
        }
        else 
        {
            money = money - betMoney;
            Console.WriteLine($"They bet ${betMoney}");
            Console.WriteLine("What color would they like to bet on? RED, BLACK or GREEN");
            string gamblingColor = Console.ReadLine().ToUpper();
            Console.WriteLine($"{Name} bets ${betMoney} on {gamblingColor}! Let's get gambling!");
            int chance = rnd.Next(1, 37);
            if (gamblingColor == "BLACK")
            {
                winMultiplier = 2;
                if (chance > 1 && chance < 18)
                {
                    GamblingWon();
                }
                else 
                {
                    Console.WriteLine("Lost");
                }
            }
            else if (gamblingColor == "RED")
            {
                winMultiplier = 2;
                if (chance > 17 && chance < 35)
                {
                    GamblingWon();
                }
                else 
                {
                    Console.WriteLine("Lost");
                }
            }
            else if (gamblingColor == "GREEN")
            {
                winMultiplier = 15;
                if (chance == 35)
                {
                    GamblingWon();
                }
                else 
                {
                    Console.WriteLine("Lost");
                }
            }
        }
        

    }
    public void GamblingWon()
    {
        Console.WriteLine($"{Name} won {betMoney * winMultiplier}! They're brimming with joy!");
        money = betMoney * winMultiplier + money;
        ReduceBoredom();
    }
    public bool GetAlive()
    {
        return isAlive;
    }
}