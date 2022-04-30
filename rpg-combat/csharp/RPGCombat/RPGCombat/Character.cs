namespace RPGCombat;

public class Character
{
    public const int INITIAL_HEALTH = 1000;
    public int Health { get; set; } = INITIAL_HEALTH;
    public int Level { get; set; } = 1;
    public bool IsAlive { get; set; } = true;

    public void DealDamageTo(Character character, int damage)
    {
        if (character == this)
            return;

        if (character.Level - Level >= 5)
            damage /= 2;
        
        if (Level - character.Level >= 5)
            damage *= 2;
        
        character.Health = Math.Max(0, character.Health - damage);
        if (character.Health == 0)
        {
            character.IsAlive = false;
        }
    }

    public void HealCharacter(Character characterToHeal, int amountToHeal)
    {
        if (characterToHeal != this)
            return;
        
        if (characterToHeal.IsAlive)
        {
            characterToHeal.Health = Math.Min(INITIAL_HEALTH, characterToHeal.Health + amountToHeal);
        }
    }
}
