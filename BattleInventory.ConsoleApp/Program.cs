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

    Console.WriteLine("\n-- THE ADVENTURE BEGINS --\n");

    Console.WriteLine(" You awaken in a dark forest, your armor heavy and your sword at your side.\n A strange wind rustles the leaves, and you can sense danger nearby.\n You must prepare yourself for battle and gather supplies to survive.\n The path ahead is uncertain, filled with both peril and opportunity.");

    continueOptions();

    Console.WriteLine(" You begin to walk along the winding forest path, the sunlight filtering through the trees.\n Suddenly, you hear rustling in the bushes.\n A wild Goblin emerges, snarling, its yellow eyes gleaming in the shadows.\n It's armed with a jagged knife and looks ready to fight.");

    Combat(goblin);
    if (!player.IsAlive()) return;

    Console.WriteLine(" You move deeper into the forest, passing over a babbling creek and winding through dense thickets.\n Eventually, you come across an abandoned campfire. A Treasure Chest rests by the fire.\n");

    OpenTreasure();
    continueOptions();

    Console.WriteLine(" As you continue down the forest path, the trees thin out and you find yourself in a clearing.\n In front of you stands a massive Forest Troll.\n Its green skin is covered in thick moss,\n and its red eyes lock onto you.\n It roars, shaking the ground beneath your feet.");

    Combat(troll);
    if (!player.IsAlive()) return;

    Console.WriteLine(" As you continue your journey, you encounter more challenges and stories unfold.\n Will you uncover the secrets of the forest,\n defeat even more powerful enemies,\n or find the legendary treasure hidden deep within?\n The path is yours to decide.");

}

void continueOptions()
{

    while (true)
    {
        Console.WriteLine();

        TextFormat.WriteYellow(" Press 1 to Explore\n Press 2 to open Inventory\n");
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
                TextFormat.WriteYellow($"      {i}: {player.Inventory[i].Name}\n");
            }

            if (int.TryParse(Console.ReadLine(), out int input) && input < player.Inventory.Count)
            {
                if (player.Inventory[input].ItemType == TypeOfItem.Healing)
                {
                    // Do healing here!
                    player.HealDamage(player.Inventory[input].Value);
                    TextFormat.WriteGreen($"You recovered {player.Inventory[input].Value} life!\n");
                    player.Inventory.RemoveAt(input);
                }

                else if (player.Inventory[input].ItemType == TypeOfItem.Damage)
                {
                    // Equip weapon!
                    player.AttackPower = player.Inventory[input].Value;
                    TextFormat.WriteGreen($"You equiped the {player.Inventory[input].Name}, your attack power is now {player.Inventory[input].Value}!\n");
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
            TextFormat.WriteRed($"{player.Name} was defeated!\n\n");
            break;
        }

        Console.Write($"You have "); TextFormat.WriteRed($"{player.Health}"); Console.WriteLine(" HP.");
        Console.WriteLine("Choose an action:");
        TextFormat.WriteYellow("   0: Fight!\n");
        TextFormat.WriteYellow("   1: Use an item!\n");
        TextFormat.WriteYellow("   2: Converse!\n");

        switch (Console.ReadLine())
        {
            case "0":
                Console.WriteLine($"You strike the {monster.Name}, dealing {player.AttackPower} damage!\n");
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
            TextFormat.WriteGreen($"{monster.Name} is defeated!\n\n");
            break;
        }

        Console.WriteLine($"{monster.Name} attacks you, dealing {monster.AttackPower} damage!\n");
        monster.DealDamage(player);
    }
}

void OpenTreasure()
{
    Console.WriteLine("Choose your action");
    TextFormat.WriteYellow("   0: Open Treasure\n");
    TextFormat.WriteYellow("   1: Continue Exploring\n");

    switch (Console.ReadLine())
    {

        case "0":
            var shinySword = new Weapon(15, "Shiny Sword");
            player.Inventory.Add(shinySword);
            Console.WriteLine($"You found a {shinySword.Name}");
            break;

        case "1":
            break;
    }
}