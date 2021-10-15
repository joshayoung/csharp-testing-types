namespace Warrior
{
    public class Knight
    {
        private readonly Sustenance sustenance;

        public int BladeLength { get; set; } = 5;
        
        public Knight(Sustenance sustenance)
        {
            this.sustenance = sustenance;
        }

        // Incoming Query (no side effects)
        // Test the return value
        public bool HasSword()
        {
            return BladeLength > 10;
        }

        // Incoming Query (no side effects)
        // Test the return value
        public int GetStrengthLevel()
        {
            return sustenance.Endurance() + 10;
        }

        // Outgoing Command:
        public void Hit() => sustenance.DecreaseEnergy();
        
        // Outgoing Query
        // Do not test (it is tested in sustenance)
        public void GetEnergyLevelAndDoSomething()
        {
            // Do not test this:
            var energyLevel = sustenance.EnergyLevel;
            
            // I do not want to add more messages that needs testing.
        }

        // Incoming Command (has side effects)
        // Test the side effect
        public void SetBladeLength(int length)
        {
            BladeLength = length;
        }
    }
}