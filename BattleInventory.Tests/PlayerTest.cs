using System.Security;
using BattleInventory.Core;
using Shouldly;

namespace BattleInventory.Tests;

public class PlayerTest
{

    [Fact]
    public void Test_Player_Take_Damage()
    {
        var player = new Player(100, 0, 0);
        player.TakeDamage(10);
        player.Health.ShouldBeLessThan(player.MaxHealth);
    }

    [Fact]
    public void Test_Player_Heal()
    {
        var player = new Player(100, 0, 0);
        player.TakeDamage(1);
        player.HealDamage(1);

        player.Health.ShouldBe(player.MaxHealth);
    }

    [Fact]
    public void Test_Player_Overheal()
    {
        var player = new Player(100, 0, 0);
        player.TakeDamage(1);
        player.HealDamage(1000);

        player.Health.ShouldBe(player.MaxHealth);
    }

    [Fact]
    public void Test_Player_Alive()
    {
        var player = new Player(10, 0, 0);
        player.IsAlive().ShouldBeTrue();
    }

    [Fact]
    public void Test_Player_NotAlive()
    {
        var player = new Player(10, 0, 0);
        player.TakeDamage(10);
        player.IsAlive().ShouldBeFalse();
    }

    [Fact]
    public void Test_Player_HealthPotion()
    {
        var player = new Player(100, 0, 0);
        var healthPotion = new HealthPotion(10);
        healthPotion.Value = 10;

        player.TakeDamage(10);
        player.HealDamage(healthPotion.Value);

        player.Health.ShouldBe(player.MaxHealth);
    }

    [Fact]
    public void Test_Adding_To_Player_Inventory()
    {
        var player = new Player(100, 0, 0);
        var hPotion = new HealthPotion(10);

        player.AddToInventory(hPotion);

        player.Inventory.Contains(hPotion).ShouldBeTrue();
    }

    [Fact]
    public void Test_Player_HealtPotion_From_Inventory()
    {
        var player = new Player(100, 0, 0);
        var hPotion = new HealthPotion(10);

        player.AddToInventory(hPotion);
        player.TakeDamage(10);

        player.UseItem(player.Inventory[0]);

        player.Health.ShouldBe(player.MaxHealth);
    }

    [Fact]
    public void Test_Player_Deal_Damage()
    {
        var player = new Player(10, 5, 0);
        var monster = new Monster(10, 5, 0, 0);

        player.DealDamage(monster);

        monster.Health.ShouldBe(5);
    }

    [Fact]
    public void Test_Player_Level_Up()
    {
        var player = new Player(10, 10, 0);

        player.GetXP(20);

        player.Experience.ShouldBe(10);
        player.Level.ShouldBe(2);
    }

    [Fact]
    public void Test_Player_Get_XP_From_Monsters()
    {
        var player = new Player(10, 1, 0);
        var monster = new Monster(0, 1, 0, 10);

        if (!monster.IsAlive())
        {
            player.GetXP(monster.XPValue);
        }

        player.Level.ShouldBe(2);
    }
}