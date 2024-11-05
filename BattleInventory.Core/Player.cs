

namespace BattleInventory.Core;

public class Player : Character
{
    public int MaxHealth { get; private set; }


    public Player(int health, int attack, int defence, string name = "Player")
    {
        MaxHealth = health;

        Name = name;
        Health = MaxHealth;
        AttackPower = attack;
        Defence = defence;
    }

    public void TakeDamage(int dmg)
    {
        Health -= dmg;
    }

    public void HealDamage(int healAmount)
    {
        Health += healAmount;

        if (Health > MaxHealth) Health = MaxHealth;
    }

    public bool IsAlive() => Health > 0;

    public void AddToInventory(HealthPotion hPotion)
    {
        Inventory.Add(hPotion);
    }

    public List<Item> GetItems() => Inventory;
}