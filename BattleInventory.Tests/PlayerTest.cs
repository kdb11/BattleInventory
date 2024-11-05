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

        player.HealDamage(player.Inventory[0].Value);       

        player.Health.ShouldBe(player.MaxHealth);
    }
}