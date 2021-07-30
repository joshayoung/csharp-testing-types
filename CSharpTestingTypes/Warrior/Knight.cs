namespace Warrior
{
    public class Knight
    {
        private readonly Sustenance sustenance;

        public ISward Sward { get; set; }
        
        public Knight(Sustenance sustenance)
        {
            this.sustenance = sustenance;
        }

        public int StrengthLevel()
        {
            return sustenance.EnergyLevel();
        }

        public void SetSword(ISward sword)
        {
            Sward = sword;
        }
    }
}