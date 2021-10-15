using NSubstitute;
using Warrior;
using Xunit;

namespace WarriorTests
{
    public class ImplementationDetailsTest
    {
        // This is an example of a test that should not be written (implementation detail):
        [Fact]
        public void GetEnergyLevelAndDoSomething_Called_CallsEnergyLevelOnSustenance()
        {
            var sustenance = Substitute.ForPartsOf<Sustenance>();
            var implementationDetails = new ImplementationDetails(sustenance);
            
            implementationDetails.GetEnergyAndBumpLevel();

            // Bad practise, testing an implementation detail:
            sustenance.Received().GetEnergyLevel();
        }

        // We should not care how the string is formatted, just about the return value of this method:
        [Fact]
        public void GetKnightLevel_Called_CallsSplitString()
        {
            var level = "super knight";
            var sustenance = Substitute.ForPartsOf<Sustenance>();
            // I should not be stubbing my object under test, but
            // it was necessary to get this example to work:
            var implementationDetails = Substitute.ForPartsOf<ImplementationDetails>(sustenance);
            
            implementationDetails.GetKnightLevel(level);
            
            // Bad practise, testing an implementation detail:
            implementationDetails.Received().SplitString(Arg.Is<string>(level));
        }
    }
}