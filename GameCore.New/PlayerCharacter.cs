namespace GameCore.New;

public class PlayerCharacter
{
    public int Health { get; private set; } = 100;
    public bool IsDead { get; private set; }
    public int DamageResistance { get; set; }
    public string Race { get; set; }

    public void Hit(int damage)
    {
        var damageTaken = damage - DamageResistance - (Race == "Elf" ? 20 : 0);

        Health -= damageTaken > 0 ? damageTaken : 0;

        IsDead = Health <= 0;
    }
}