using NSubstitute;
using Warrior;
using Xunit;

namespace WarriorTests
{
    public class OutgoingCommandTest
    {
        [Fact]
        public void Hit_Called_ExpectDecreaseEnergyCalled()
        {
            var sustenance = Substitute.ForPartsOf<Sustenance>();
            var knight = new Knight(sustenance);
            
            knight.Hit();
            
            // Test that the call was made.
            // We do not test 'DecreaseEnergy' here, that is tested elsewhere.
            sustenance.Received().DecreaseEnergy();
        }
        
    }
}