using RPGCombat;
using Xunit;

namespace UnitTests;

public class HealCharacterShould
{
    [Fact]
    public void RaiseHealthOfInjuredCharacter()
    {
        var player = new Character();
        var characterToHeal = new Character { Health = 10 };

        player.HealCharacter(characterToHeal, 10);
        Assert.Equal(20, characterToHeal.Health);
    }

    [Fact]
    public void NotHealDeadCharacter()
    {
        var player = new Character();
        var deadCharacter = new Character { Health = 0, IsAlive = false };
        
        player.HealCharacter(deadCharacter, 100);
        
        Assert.Equal(0, deadCharacter.Health);
        Assert.False(deadCharacter.IsAlive);
    }

    [Fact]
    public void NeverHealAboveInitialHealth()
    {
        var player = new Character();
        var characterToHeal = new Character();
        
        player.HealCharacter(characterToHeal, 100);
        
        Assert.Equal(Character.INITIAL_HEALTH, characterToHeal.Health);
    }
}