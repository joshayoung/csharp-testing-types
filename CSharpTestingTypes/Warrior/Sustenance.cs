namespace Warrior
{
    public abstract class Sustenance
    {
        public virtual int EnergyLevel { get; private set; }
        private int ReserveEnergy = 3;
        
        // Incoming Command (has side effects)
        // Test the side effect
        public void IncreaseEnergy(int energy = 10)
        {
            EnergyLevel += energy;
        }

        // Incoming Command (has side effects)
        // Test the side effect
        public void DecreaseEnergy(int energy = 2)
        {
            EnergyLevel /= energy;
        }

        // Incoming Query (no side effect)
        // Test the return value
        public virtual int Endurance()
        {
            return EnergyLevel * 10;
        }
        
        // Private Command Message (do not test):
        private void IncreaseReserveEnergy()
        {
            ReserveEnergy += 1;
        }

        // Private Query Message (do not test):
        private int SupplyReserveEnergy()
        {
            return ReserveEnergy;
        }
    }
}