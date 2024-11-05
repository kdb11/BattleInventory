using BattleInventory.Core;

public class Weapon : Item
{
    public int Damage { get; set; }
    public override int Function()
    {
        Console.WriteLine($"You dealt {Damage}");
        return Damage;
    }
}