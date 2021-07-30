using FluentAssertions;
using NSubstitute;
using Warrior;
using Xunit;

namespace WarriorTests
{
    public class IncomingCommandTest
    {
        [Fact]
        public void IncreaseEnergy_Called_ExpectFoodLevelChanged()
        {
            var sustenance = Substitute.ForPartsOf<Sustenance>();
            
            sustenance.IncreaseEnergy(10);

            sustenance.FoodLevel.Should().Be(10);
        }

        [Fact]
        public void SetSword_Called_ExpectSwardPropertySet()
        {
            var sustenance = Substitute.ForPartsOf<Sustenance>();
            var sward = Substitute.For<ISward>();
            var knight = new Knight(sustenance);
            
            // Pass in a stub:
            knight.SetSword(sward);

            knight.Sward.Should().Be(sward);
        }
    }
}