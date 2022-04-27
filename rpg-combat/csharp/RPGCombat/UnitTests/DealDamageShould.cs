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
}