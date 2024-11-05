namespace BattleInventory.Core;

public class HealthPotion : Item
{
    public int HealAmount { get; set; }
    public override int Function()
    {
        Console.WriteLine($"You healed yourself with {HealAmount} health");
        return HealAmount;
    }
}
