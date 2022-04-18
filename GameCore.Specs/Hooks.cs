using TechTalk.SpecFlow;

namespace GameCore.Specs
{
    [Binding]
    public class Hooks : Steps
    {
        [BeforeScenario(Order = 100)]
        public void BeforeScenario1()
        {

        }

        [BeforeScenario(Order = 200)]
        public void BeforeScenario2()
        {

        }

        [AfterScenario]
        public void AfterScenario()
        {

        }
    }
}
