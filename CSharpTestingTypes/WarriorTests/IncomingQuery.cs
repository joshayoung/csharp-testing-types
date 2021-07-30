using FluentAssertions;
using NSubstitute;
using Warrior;
using Xunit;

namespace WarriorTests
{
    public class KnightTest
    {
        // Incoming Query Message:
        [Fact]
        public void StrengthLevel_Called_ExpectProperReturnValue()
        {
            var knight = new Knight(new Sustenance());

            var result = knight.StrengthLevel();

            result.Should().Be(100);
        }
        
        // Do not test the internal implementation.
        // Here if I change the internal implementation, but not the return value, this test will fail.
        [Fact]
        public void StrengthLevel_Called_ExpectSustenanceToCallCorrectMethod()
        {
            var sustenance = Substitute.ForPartsOf<Sustenance>();
            var knight = new Knight(sustenance);

            knight.StrengthLevel();

            sustenance.Received().EnergyLevel();
        }
    }
}