namespace Warrior
{
    public interface IFight
    {
        void Joust();
    }

    public static class KnightOnHorseback
    {
        public static void Fight()
        {
            // Do Something...
        }
    }

    public class JoustWrapper : IFight
    {
        public void Joust()
        {
            KnightOnHorseback.Fight();
        }
    }
    
    public static class Battle
    {
        public static void Start()
        {
            Start(new JoustWrapper());
        }  
        
        public static void Start(IFight fight)
        {
            fight.Joust();
        }
    }
}