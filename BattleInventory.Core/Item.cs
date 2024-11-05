namespace BattleInventory.Core;

public enum TypeOfItem
{
    Healing,
    Damage
}

public abstract class Item
{
    public string? Name { get; set; }
    public int Value { get; set; }
    public abstract int Function();
    public int _Index {get; set; }
    public TypeOfItem ItemType { get; protected set; }
}