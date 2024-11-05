using System.Security;
using BattleInventory.Core;
using Shouldly;

namespace BattleInventory.Tests;

public class BattleInventoryTest
{
    [Fact]
    public void TestCharacter()
    {
        var character = new Character();
        
        character.Name = "Aragon";
        character.Health = 100;
        character.AttackPower = 5;
        character.Defence = 5;
        character.Inventory?.Add(new HealthPotion());

        character.Name.ShouldBe("Aragon");
        character.Health.ShouldBe(100);
        character.AttackPower.ShouldBe(5);
        character.Defence.ShouldBe(5);
        character.Inventory?.Count.ShouldBe(1);
    }

    [Fact]
    public void Test_Player_Take_Damage()
    {
        var player = new Player(100, 10, 0);

        player.TakeDamage(10);

        player.Health.ShouldBeLessThan(player.MaxHealth);
    }
}