using RPGCombat;
using Xunit;

namespace UnitTests;

public class HealCharacterShould
{
    [Fact]
    public void RaiseHealthOfInjuredCharacter()
    {
        var player = new Character { Health = 10 };

        player.HealCharacter(player, 10);
        Assert.Equal(20, player.Health);
    }

    [Fact]
    public void NotHealDeadCharacter()
    {
        var player = new Character { Health = 0, IsAlive = false };

        player.HealCharacter(player, 100);
        
        Assert.Equal(0, player.Health);
        Assert.False(player.IsAlive);
    }

    [Fact]
    public void NeverHealAboveInitialHealth()
    {
        var player = new Character();

        player.HealCharacter(player, 100);
        
        Assert.Equal(Character.INITIAL_HEALTH, player.Health);
    }

    [Fact]
    public void DoNothingWhenTryingToHealOtherCharacter()
    {
        var player = new Character();
        var characterToHeal = new Character { Health = 100 };
        
        player.HealCharacter(characterToHeal, 100);
        
        Assert.Equal(100, characterToHeal.Health);
    }
}