using System.Diagnostics;
using System.Linq;
using GameCore.New;
using TechTalk.SpecFlow;
using Xunit;

namespace GameCore.Specs
{
    [Binding]
    public class PlayerCharacterStepDefinitions
    {
        private PlayerCharacter _player;

        [Given(@"I'm a new Player")]
        public void GivenImANewPlayer()
        {
            _player = new PlayerCharacter();
        }

        [When(@"I take (.*) damage")]
        public void WhenITake_number_damage(int number)
        {
            _player.Hit(number);
        }

        [Then(@"My health should be (.*)")]
        public void ThenMyHealthShouldBe(int health)
        {
            Assert.Equal(health, _player.Health);
        }


        [Then(@"I should be dead")]
        public void ThenIShouldBeDead()
        {
            Assert.True(_player.IsDead);
        }

        [Given(@"I have a damage resistance of (.*)")]
        public void GivenIHaveADamageResistanceOf(int resistance)
        {
            _player.DamageResistance = resistance;
        }

        [Given(@"I'm an Elf")]
        public void GivenImAnElf()
        {
            _player.Race = "Elf";
        }

        [Given(@"I have the following attributes")]
        public void GivenIHaveTheFollowingAttributes(Table table)
        {
            var race = table.Rows.First(r => r["attribute"] == "Race")["value"];
            var damageResistance = table.Rows.First(r => r["attribute"] == "DamageResistance")["value"];

            _player.DamageResistance = int.Parse(damageResistance);
            _player.Race = race;
        }

    }
}
