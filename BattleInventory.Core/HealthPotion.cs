namespace BattleInventory.Core;

public class HealthPotion : Item
{
    public HealthPotion(int healAmount)
    {
        Value = healAmount;
    }

    public override int Function()
    {
        Console.WriteLine($"You healed yourself with {Value} health");
        return Value;
    }
}
