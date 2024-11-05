
using Microsoft.VisualBasic;

namespace BattleInventory.Core;

public class Monster : Character
{
    public int XPValue { get; protected set; }

    public Monster(int health, int attack, int defence, int xpValue, string name = "Monster")
    {
        Name = name;
        Health = health;
        AttackPower = attack;
        Defence = defence;
        XPValue = xpValue;
    }

    public void DealDamage(Player player)
    {
        player.TakeDamage(AttackPower);
    }

    public void TakeDamage(int dmg)
    {
        Health -= dmg;
    }

    public bool IsAlive() => Health > 0;
}
