namespace BattleInventory.Core;

public abstract class Item
{
    public string? Name { get; set; }
    public int Value { get; set; }
    public abstract int Function();
}