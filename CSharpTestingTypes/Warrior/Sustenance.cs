namespace Warrior
{
    public class Sustenance
    {
        public int FoodLevel { get; set; }

        public virtual int EnergyLevel()
        {
            FoodLevel *= 10;
            return FoodLevel;
        }

        public void IncreaseEnergy(int food)
        {
            FoodLevel += food;
        }
    }
}