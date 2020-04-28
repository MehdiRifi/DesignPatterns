using System;
namespace DesignPatterns.Behavioral.Mediator
{
    /// <summary>
    /// type of drone => concreate colleague
    /// </summary>
    public class MRD : Drone
    {
        private readonly int minLongtitudeDistance = 20;
        private readonly int minLatitudeDistance = 30;

        public MRD(string name) : base(name)
        {
        }
        public override void Handle(int x, int y,string droneName)
        {
            if (Math.Abs(longitude - x) < minLongtitudeDistance || Math.Abs(latitude-y) < minLatitudeDistance)
                Console.WriteLine($"[{nameof(MRD)}] {Name} : watch out {droneName} you're so close!!");
        }
    }
}
