using System;
using System.Collections.Generic;
using System.Linq;
using GameCore.New;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace GameCore.Specs
{
    [Binding]
    public class PlayerCharacterStepDefinitions
    {
        private readonly PlayerCharacterStepsContext _context;

        public PlayerCharacterStepDefinitions(PlayerCharacterStepsContext context)
        {
            _context = context;
        }

        [When(@"I take (.*) damage")]
        public void WhenITake_number_damage(int number)
        {
            _context.Player.Hit(number);
        }

        [Then(@"My health should be (.*)")]
        public void ThenMyHealthShouldBe(int health)
        {
            Assert.Equal(health, _context.Player.Health);
        }


        [Then(@"I should be dead")]
        public void ThenIShouldBeDead()
        {
            Assert.True(_context.Player.IsDead);
        }

        [Given(@"I have a damage resistance of (.*)")]
        public void GivenIHaveADamageResistanceOf(int resistance)
        {
            _context.Player.DamageResistance = resistance;
        }

        [Given(@"I'm an Elf")]
        public void GivenImAnElf()
        {
            _context.Player.Race = CharacterRace.Elf;
        }

        //[Given(@"I have the following attributes")]
        //public void GivenIHaveTheFollowingAttributes(Table table)
        //{
        //    var race = table.Rows.First(r => r["attribute"] == "Race")["value"];
        //    var damageResistance = table.Rows.First(r => r["attribute"] == "DamageResistance")["value"];

        //    _context.Player.DamageResistance = int.Parse(damageResistance);
        //    _context.Player.Race = Enum.Parse<CharacterRace>(race);
        //}

        //[Given(@"I have the following attributes")]
        //public void GivenIHaveTheFollowingAttributes(Table table)
        //{
        //    var attributes = table.CreateInstance<PlayerAttributes>();

        //    _context.Player.DamageResistance = attributes.DamageResistance;
        //    _context.Player.Race = attributes.Race;
        //}


        [Given(@"I have the following attributes")]
        public void GivenIHaveTheFollowingAttributes(Table table)
        {
            dynamic attributes = table.CreateDynamicInstance();

            _context.Player.DamageResistance = attributes.DamageResistance;
            _context.Player.Race = Enum.Parse<CharacterRace>(attributes.Race);
        }

        [Given(@"My character class is set to (.*)")]
        public void GivenMyCharacterClassIsSetToHealer(CharacterClass characterClass)
        {
            _context.Player.Class = characterClass;
        }

        [When(@"Cast a healing spell")]
        public void WhenCastAHealingSpell()
        {
            _context.Player.CastHealingSpell();
        }

        [Given(@"I have the following magical items")]
        public void GivenIHaveTheFollowingMagicalItems(Table table)
        {
            var items = table.CreateDynamicSet();

            _context.Player.MagicalItems.AddRange(items.Select(i => new MagicalItem
            {
                Name = i.name,
                Value = i.value,
                Power = i.power
            }));
        }

        //[Given(@"I have the following magical items")]
        //public void GivenIHaveTheFollowingMagicalItems(Table table)
        //{
        //    var items = table.CreateSet<MagicalItem>();

        //    _context.Player.MagicalItems.AddRange(items);
        //}

        [Then(@"My total magical power should be (.*)")]
        public void ThenMyTotalMagicalPowerShouldBe(int expectedMagicalPower)
        {
            Assert.Equal(expectedMagicalPower, _context.Player.MagicalPower);
        }

        [Given(@"I last slept (.* days ago)")]
        public void GivenILastSleptDaysAgo(DateTime lastSlept)
        {
            _context.Player.LastSleepTime = lastSlept;
        }

        [When(@"I read a restore health scroll")]
        public void WhenIReadARestoreHealthScroll()
        {
            _context.Player.ReadHealthScroll();
        }

        [Given(@"I have the following weapons")]
        public void GivenIHaveTheFollowingWeapons(IEnumerable<WeaponClass> weapons)
        {
            _context.Player.Weapons.AddRange(weapons);
        }

        [Then(@"my weapons should be worth (.*)")]
        public void ThenMyWeaponsShouldBeWorth(int value)
        {
            Assert.Equal(value, _context.Player.WeaponsValue);
        }

        [Given(@"I have an (.*) with a power of (.*)")]
        public void GivenIHaveAnAmuletWithAPowerOf(string name, int power)
        {
            _context.Player.MagicalItems.Add(new MagicalItem
            {
                Name = name,
                Power = power
            });

            _context.StartingMagicalPower = power;
        }

        [When(@"I use a magical (.*)")]
        public void WhenIUseAMagicalAmulet(string name)
        {
            _context.Player.UseMagicalItem(name);
        }

        [Then(@"My (.*) power should not be reduced")]
        public void ThenMyAmuletPowerShouldNotBeReduced(string name)
        {
            Assert.Equal(_context.StartingMagicalPower, _context.Player.MagicalItems.First(m => m.Name == name).Power);
        }

    }
}
