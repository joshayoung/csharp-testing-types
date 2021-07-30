namespace Warrior
{
    public class Knight
    {
        private readonly Sustenance sustenance;

        public Knight(Sustenance sustenance)
        {
            this.sustenance = sustenance;
        }

        public int StrengthLevel()
        {
            return sustenance.EnergyLevel();
        }
    }
}