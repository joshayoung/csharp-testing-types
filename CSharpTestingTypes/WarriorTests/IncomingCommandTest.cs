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
            
            sustenance.IncreaseEnergy();

            sustenance.EnergyLevel.Should().Be(10);
        }
        
        [Fact]
        public void DecreaseEnergy_Called_ExpectFoodLevelChanged()
        {
            var sustenance = Substitute.ForPartsOf<Sustenance>();
            sustenance.IncreaseEnergy(20);
            
            sustenance.DecreaseEnergy();

            sustenance.EnergyLevel.Should().Be(10);
        }

        [Fact]
        public void SetBladeLength_Called_ExpectBladeLengthPropertySet()
        {
            var sustenance = Substitute.ForPartsOf<Sustenance>();
            var knight = new Knight(sustenance);
            var swordLength = 10;
            
            knight.SetBladeLength(swordLength);

            knight.BladeLength.Should().Be(swordLength);
        }
    }
}