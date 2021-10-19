using NSubstitute;
using Xunit;

namespace WarriorTests
{
    public class WrapStaticMethodTest
    {
        [Fact]
        public void Move_Called_CallsStaticWrapperMethod()
        {
            var wrapper = Substitute.For<IBoat>();
            var travel = new Travel(wrapper);
            
            travel.Move();
            
            wrapper.Received().Paddle();
        }
    }
}