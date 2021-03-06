using FluentAssertions;
using NSubstitute;
using Warrior;
using Xunit;

namespace WarriorTests
{
    public class IncomingQueryTest
    {
        private readonly Sustenance sustenance;
        
        public IncomingQueryTest()
        {
            sustenance = Substitute.ForPartsOf<Sustenance>();
        }

        [Fact]
        public void HasSword_BladeLengthGreaterThanTen_ExpectReturnsTrue()
        {
            var knight = new Knight(sustenance) { BladeLength = 11 };

            var results = knight.HasSword();

            results.Should().BeTrue();
        }
        
        [Fact]
        public void HasSword_BladeLengthLessThanTen_ExpectReturnsFalse()
        {
            var knight = new Knight(sustenance) {BladeLength = 5};

            var results = knight.HasSword();

            results.Should().BeFalse();
        }
        
        [Fact]
        public void StrengthLevel_Called_ExpectProperReturnValue()
        {
            var knight = new Knight(sustenance);

            var result = knight.GetStrengthLevel();

            result.Should().Be(10);
        }
        
        [Fact(Skip = "This test is bad practise, skipping for that reason.")]
        public void StrengthLevel_Called_ExpectSustenanceToCallCorrectMethodAndReturnCorrectValue()
        {
            var knight = new Knight(sustenance);

            var result = knight.GetStrengthLevel();
            
            result.Should().Be(10);

            // Do not test the internal implementation
            // Changing the internal implementation will cause the test to fail
            sustenance.Received().Endurance();
        }

        [Fact]
        public void Endurance_Called_ExpectCorrectReturnValue()
        {
            var result = sustenance.Endurance();

            result.Should().Be(0);
        }
    }
}