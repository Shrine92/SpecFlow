using GameCore.New;
using TechTalk.SpecFlow;

namespace GameCore.Specs
{
    [Binding]
    public class CommonPlayerCharacterSteps
    {
        private readonly PlayerCharacterStepsContext _context;

        public CommonPlayerCharacterSteps(PlayerCharacterStepsContext context)
        {
            _context = context;
        }

        [Given(@"I'm a new Player")]
        public void GivenImANewPlayer()
        {
            _context.Player = new PlayerCharacter();
        }
    }
}
