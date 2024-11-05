namespace BattleInventory.Core;

public class HealthPotion : Item
{
    public HealthPotion(int healAmount, string name = "Health Potion")
    {
        Value = healAmount;
        Name = name;
        ItemType = TypeOfItem.Healing;
    }

    public override int Function()
    {
        Console.WriteLine($"You healed yourself with {Value} health");
        return Value;
    }
}
