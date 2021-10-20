using NSubstitute;
using Warrior;
using Xunit;

namespace WarriorTests
{
    public class StaticMethodExampleTest
    {
        [Fact]
        public void Start_Invokes_Joust()
        {
            var mock = Substitute.For<IFight>();
            
            Battle.Start(mock);
            
            mock.Received().Joust();
        }
    }
}