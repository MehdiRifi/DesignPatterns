using System;
namespace DesignPatterns.Behavioral.Mediator
{
    /// <summary>
    /// type of drone => concreate colleague
    /// </summary>
    public class SRD:Drone
    {
        private readonly int minLongtitudeDistance = 10;
        private readonly int minLatitudeDistance = 10;
        public SRD(string name) : base(name)
        {
        }
        public override void Handle(int x, int y, string droneName)
        {
            if ((longitude - x) < minLongtitudeDistance || (latitude - y) < minLatitudeDistance)
                Console.WriteLine($"[{nameof(SRD)}] {Name} : watch out {droneName} you're so close!!");
        }
    }
}
