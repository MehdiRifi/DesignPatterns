using System;
namespace DesignPatterns.Behavioral.Mediator
{
    /// <summary>
    /// type of drone => concreate colleague
    /// </summary>
    public class FWD:Drone
    {
        private readonly int minLongtitudeDistance = 50;
        private readonly int minLatitudeDistance = 50;

        public FWD(string name):base(name)
        {
        }

        public override void Handle(int x, int y, string droneName)
        {
            if ((longitude - x) < minLongtitudeDistance || (latitude - y) < minLatitudeDistance)
                Console.WriteLine($"[{nameof(FWD)}] {Name} : watch out {droneName} you're so close!!");
        }
    }
}
