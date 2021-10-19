using System;

public interface IBoat
{ 
    void Paddle();
}

public static class Boat
{
    public static void Paddle()
    {
        // Implementation does not matter for this example.
    }
}

// Example below:

// Original Class that Called to Static Method:
// public class Travel
// {
//     public void Move()
//     {
//         Boat.Paddle();
//     }
// }

public class BoatWrapper : IBoat
{
    public void Paddle()
    {
        Boat.Paddle();
    }
}

public class Travel
{
    private readonly IBoat _boat;  
    
    // Default no-param constructor calls our constructor
    // which accepts an interface:
    public Travel() : this(new BoatWrapper())
    {
    }  
    
    public Travel(IBoat boat)
    {
        _boat = boat;
    }  
    
    public void Move()
    {
        _boat.Paddle();
    }
}