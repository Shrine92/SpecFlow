using System;
using System.Collections.Generic;
using System.Linq;

namespace GameCore.New;

public class PlayerCharacter
{
    public int Health { get; private set; } = 100;
    public bool IsDead { get; private set; }
    public int DamageResistance { get; set; }
    public CharacterRace Race { get; set; }

    public CharacterClass Class { get; set; }

    public DateTime LastSleepTime { get; set; }

    public int MagicalPower => MagicalItems.Sum(x => x.Power);
    public int WeaponsValue => Weapons.Sum(w => w.Value);

    public List<MagicalItem> MagicalItems { get; set; } = new ();

    public List<WeaponClass> Weapons { get; set; } = new();

    public void Hit(int damage)
    {
        var damageTaken = damage - DamageResistance - (Race == CharacterRace.Elf ? 20 : 0);

        Health -= damageTaken > 0 ? damageTaken : 0;

        IsDead = Health <= 0;
    }

    public void CastHealingSpell()
    {
        Health += Class == CharacterClass.Healer ? 100 - Health : 10;
    }

    public void ReadHealthScroll()
    {
        if (DateTime.Now.Subtract(LastSleepTime).Days <= 2)
        {
            Health = 100;
        }
    }

    public void UseMagicalItem(string itemName)
    {
        var itemToReduce = MagicalItems.First(i => i.Name == itemName);

        if (Race != CharacterRace.Elf)
        {
            itemToReduce.Power -= 10;
        }
    }
}