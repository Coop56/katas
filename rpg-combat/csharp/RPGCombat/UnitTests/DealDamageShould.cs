using RPGCombat;
using Xunit;

namespace UnitTests;

public class DealDamageShould
{
    [Fact]
    public void SubtractFromEnemyHealth()
    {
        var player = new Character();
        var enemy = new Character();

        player.DealDamageTo(enemy, 100);
        
        Assert.Equal(Character.INITIAL_HEALTH - 100, enemy.Health);
    }
    
    [Fact]
    public void MakeCharacterDead_GivenEnoughDamageDone()
    {
        var player = new Character();
        var enemy = new Character();

        player.DealDamageTo(enemy, 9001);
        Assert.False(enemy.IsAlive);
    }
    
    [Fact]
    public void HealthFloorAtZero()
    {
        var player = new Character();
        var enemy = new Character();

        player.DealDamageTo(enemy, 9001);
        Assert.Equal(0, enemy.Health);
    }

    [Fact]
    public void NotDealDamageToSelf()
    {
        var player = new Character();
        
        player.DealDamageTo(player, 100);

        Assert.Equal(Character.INITIAL_HEALTH, player.Health);
    }

    [Fact]
    public void HalveDamageWhenTargetIsFiveLevelsHigher()
    {
        var player = new Character { Level = 1 };
        var enemy = new Character { Level = 6 };
        var baseDamage = 100;
        var damageReduction = 2;
        
        player.DealDamageTo(enemy, baseDamage);
        Assert.Equal(Character.INITIAL_HEALTH - (baseDamage / damageReduction), enemy.Health);
    }
    
    [Fact]
    public void DoubleDamageWhenTargetIsFiveLevelsHigher()
    {
        var player = new Character { Level = 6 };
        var enemy = new Character { Level = 1 };
        var baseDamage = 100;
        var damageMultiplier = 2;
        
        player.DealDamageTo(enemy, baseDamage);
        Assert.Equal(Character.INITIAL_HEALTH - (baseDamage * damageMultiplier), enemy.Health);
    }
}