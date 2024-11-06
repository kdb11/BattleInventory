using BattleInventory.Core;

var monster = new Monster(10, 1, 1, 5);
var player = new Player(100, 10, 0);
Console.WriteLine(monster.AttackPower);
runGame();
void runGame()
{

    Console.WriteLine("You awaken in a dark forest, your armor heavy and your sword at your side. A strange wind rustles the leaves, and you can sense danger nearby. You must prepare yourself for battle and gather supplies to survive. The path ahead is uncertain, filled with both peril and opportunity.");

    continueOptions();

    Console.WriteLine("You begin to walk along the winding forest path, the sunlight filtering through the trees. Suddenly, you hear rustling in the bushes. A wild Goblin emerges, snarling, its yellow eyes gleaming in the shadows. It’s armed with a jagged knife and looks ready to fight.");

    Console.WriteLine("You move deeper into the forest, passing over a babbling creek and winding through dense thickets. Eventually, you come across an abandoned campfire. A Treasure Chest rests by the fire.");

    Console.WriteLine("As you continue down the forest path, the trees thin out and you find yourself in a clearing. In front of you stands a massive Forest Troll. Its green skin is covered in thick moss, and its red eyes lock onto you. It roars, shaking the ground beneath your feet.");

    Console.WriteLine("As you continue your journey, you encounter more challenges and stories unfold. Will you uncover the secrets of the forest, defeat even more powerful enemies, or find the legendary treasure hidden deep within? The path is yours to decide.");

}

void continueOptions()
{

    while (true)
    {


        Console.WriteLine(" Press 1 to Explore\n Press 2 to open Inventory");
        var userInput = Console.ReadLine();
        if (userInput == "1")
        {
            break;
        } else if (userInput == "2")
        {
            for (int i = 0; i < player.Inventory.Count(); i++)
            {
                Console.WriteLine($"{i}: {player.Inventory[i]}");
            }
        } else {
            Console.WriteLine("Please enter 1 or 2");
        }
    }
}