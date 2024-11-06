using BattleInventory.Core;

public class Weapon : Item
{
    public Weapon (int dmg, string name = "Sword")
    {
        Value = dmg;
        Name = name;
        ItemType = TypeOfItem.Damage;
    }

    public override int Function()
    {
        Console.WriteLine($"You dealt {Value}");
        return Value;
    }
}