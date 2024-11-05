namespace BattleInventory.Core;

public class HealthPotion : Item
{
    public HealthPotion(int healAmount, string name = "Health Potion")
    {
        Value = healAmount;
        Name = name;
    }

    public override int Function()
    {
        Console.WriteLine($"You healed yourself with {Value} health");
        return Value;
    }
}
