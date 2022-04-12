using System.Diagnostics;
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

        [When]
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
    }
}
