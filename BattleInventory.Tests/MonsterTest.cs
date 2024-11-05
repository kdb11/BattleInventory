using System.Security;
using BattleInventory.Core;
using Shouldly;


public class MonsterTest
{
    [Fact]
    public void Test_Moster_Deal_Damage()
    {
        var monster = new Monster(10, 5, 0, 0);
        var player = new Player(100, 0, 0);

        monster.DealDamage(player);

        player.Health.ShouldBeLessThan(player.MaxHealth);
    }

    [Fact]
    public void Test_Moster_Take_Damage()
    {
        var monster = new Monster(10, 5, 0, 0);

        monster.TakeDamage(5);
        monster.Health.ShouldBe(5);
    }

    [Fact]
    public void Test_Monster_Alive()
    {
        var monster = new Monster(10, 0, 0, 0);
        monster.IsAlive().ShouldBeTrue();
    }

    [Fact]
    public void Test_Monster_NotAlive()
    {
        var monster = new Player(10, 0, 0);
        monster.TakeDamage(10);
        monster.IsAlive().ShouldBeFalse();
    }
}