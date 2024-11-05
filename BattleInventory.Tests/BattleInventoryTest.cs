using BattleInventory.Core;

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
        
    }
}