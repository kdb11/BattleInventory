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
}