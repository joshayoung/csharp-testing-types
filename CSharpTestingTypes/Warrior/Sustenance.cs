namespace Warrior
{
    public class Sustenance
    {
        private int foodLevel = 10;

        public virtual int EnergyLevel()
        {
            return foodLevel * 10;
        }
    }
}