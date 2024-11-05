

namespace BattleInventory.Core;

public class Player : Character
{
    public int Level { get; private set; } = 1;

    public int MaxHealth { get; private set; }
    public int Experience { get; private set; }


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

    public void AddToInventory(HealthPotion hPotion)
    {
        Inventory.Add(hPotion);
    }

    public void UseItem(Item item)
    {
        if (item.ItemType == TypeOfItem.Healing)
        {
            HealDamage(item.Value);
        }
        else if (item.ItemType == TypeOfItem.Damage)
        {
            throw new NotImplementedException();
        }
    }

    public void DealDamage(Monster monster)
    {
        monster.TakeDamage(AttackPower);
    }

    public void GetXP(int xp)
    {
        Experience += xp;

        while (Experience >= Level * 10)
        {
            Experience -= Level * 10;
            Level++;
        }
    }

    public List<Item> GetItems() => Inventory;

    public bool IsAlive() => Health > 0;


}