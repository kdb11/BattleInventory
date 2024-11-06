using BattleInventory.Core;

var goblin = new Monster(10, 1, 1, 10, "Goblin");
var troll = new Monster(70, 10, 0, 20, "Troll");

var player = new Player(100, 1, 0);

// Initial Inventory.
player.Inventory.Add(new HealthPotion(10, "Weak health potion"));
player.Inventory.Add(new Weapon(10, "Rusted sword"));

runGame();
void runGame()
{
    Console.Write("Name thy hero: ");
    player.Name = Console.ReadLine();

    Console.WriteLine("\n-- THE ADVENTURE BEGINS --");

    Console.WriteLine("You awaken in a dark forest, your armor heavy and your sword at your side. A strange wind rustles the leaves, and you can sense danger nearby. You must prepare yourself for battle and gather supplies to survive. The path ahead is uncertain, filled with both peril and opportunity.");

    continueOptions();

    Console.WriteLine("You begin to walk along the winding forest path, the sunlight filtering through the trees. Suddenly, you hear rustling in the bushes. A wild Goblin emerges, snarling, its yellow eyes gleaming in the shadows. It's armed with a jagged knife and looks ready to fight.");

    Combat(goblin);
    if (!player.IsAlive()) return;

    Console.WriteLine("You move deeper into the forest, passing over a babbling creek and winding through dense thickets. Eventually, you come across an abandoned campfire. A Treasure Chest rests by the fire.");

    OpenTreasure();
    continueOptions();

    Console.WriteLine("As you continue down the forest path, the trees thin out and you find yourself in a clearing. In front of you stands a massive Forest Troll. Its green skin is covered in thick moss, and its red eyes lock onto you. It roars, shaking the ground beneath your feet.");

    Combat(troll);
    if (!player.IsAlive()) return;

    Console.WriteLine("As you continue your journey, you encounter more challenges and stories unfold. Will you uncover the secrets of the forest, defeat even more powerful enemies, or find the legendary treasure hidden deep within? The path is yours to decide.");

}

void continueOptions()
{

    while (true)
    {
        Console.WriteLine();

        Console.WriteLine(" Press 1 to Explore\n Press 2 to open Inventory");
        var userInput = Console.ReadLine();
        if (userInput == "1")
        {
            break;
        }

        else if (userInput == "2")
        {
            if (player.Inventory.Count < 1)
            {
                Console.WriteLine("Your inventory is empty.\n");
            }

            Console.Write("Choose an item to use or press any other button to exit inventory..\n");

            for (int i = 0; i < player.Inventory.Count(); i++)
            {
                Console.WriteLine($"{i}: {player.Inventory[i].Name}");
            }

            if (int.TryParse(Console.ReadLine(), out int input) && input < player.Inventory.Count)
            {
                if (player.Inventory[input].ItemType == TypeOfItem.Healing)
                {
                    // Do healing here!
                    player.HealDamage(player.Inventory[input].Value);
                    Console.WriteLine($"You recovered {player.Inventory[input].Value} life!");
                    player.Inventory.RemoveAt(input);
                }

                else if (player.Inventory[input].ItemType == TypeOfItem.Damage)
                {
                    // Equip weapon!
                    player.AttackPower = player.Inventory[input].Value;
                    Console.WriteLine($"You equiped the {player.Inventory[input].Name}, your attack power is now {player.Inventory[input].Value}!");
                    player.Inventory.RemoveAt(input);
                }
            }
        }

        else
        {
            Console.WriteLine("Please enter 1 or 2");
        }
    }
}

void Combat(Monster monster)
{
    Random rand = new Random();
    List<string> introductions = [
        $"The {monster.Name} gives you an evil smirk",
        $"{monster.Name} hates you very much.",
        $"'I am {monster.Name}, and I will be your doom!'"
    ];

    Console.WriteLine();
    Console.WriteLine(introductions[rand.Next(0, introductions.Count)]);
    Console.WriteLine();

    while (true)
    {
        if (!player.IsAlive())
        {
            Console.WriteLine($"{player.Name} was defeated!");
            break;
        }

        Console.WriteLine($"You have {player.Health} HP.");
        Console.WriteLine("Choose an action:");
        Console.WriteLine("0: Fight!");
        Console.WriteLine("1: Use an item!");
        Console.WriteLine("2: Converse!");

        switch (Console.ReadLine())
        {
            case "0":
                Console.WriteLine($"You strike the {monster.Name}, dealing {player.AttackPower} damage!");
                player.DealDamage(monster);
                break;

            case "1":
                continueOptions();
                break;

            case "2":
                Console.WriteLine(introductions[rand.Next(0, introductions.Count)]);
                break;

            default:
                Console.WriteLine("Invalid choice.\n");
                continue;
        }

        if (!monster.IsAlive())
        {
            Console.WriteLine($"{monster.Name} is defeated!");
            break;
        }

        Console.WriteLine($"{monster.Name} attacks you, dealing {monster.AttackPower} damag!");
        monster.DealDamage(player);
    }
}

void OpenTreasure()
{
    Console.WriteLine("Choose your action");
    Console.WriteLine("0: Open Treasure");
    Console.WriteLine("1: Continue Exploring");

    switch (Console.ReadLine())
    {

        case "0":
            var shinySword = new Weapon(15, "Shiny Sword");
            player.Inventory.Add(shinySword);
            Console.WriteLine($"You found a {shinySword}");
            break;

        case "1":
            break;
    }
}