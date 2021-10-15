namespace Warrior
{
    public class ImplementationDetails
    {
        private readonly Sustenance sustenance;

        public int ImplementationLevel;
        
        public ImplementationDetails(Sustenance sustenance)
        {
            this.sustenance = sustenance;
        }
        
        public void GetEnergyAndBumpLevel()
        {
            // Outgoing Query (implementation detail):
            int energyLevel = sustenance.GetEnergyLevel();

            // This part should be tested however (side-effect) (incoming command):
            ImplementationLevel = energyLevel + 10;
        }

        // This just serves as an example of implementation detail testing:
        public string GetKnightLevel(string currentLevel)
        {
            // Implementation Detail:
            var levels = SplitString(currentLevel);
            var level1 = levels[0];
            var level2 = levels[1];

            return $"{level1} - {level2}";
        }

        public virtual string[] SplitString(string value)
        {
            return value.Split(" ");
        }
    }
}