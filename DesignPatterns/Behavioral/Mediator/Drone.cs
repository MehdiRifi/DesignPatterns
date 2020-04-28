using System;
namespace DesignPatterns.Behavioral.Mediator
{
    /// <summary>
    /// abstract drone => abstract colleague
    /// </summary>
    public abstract class Drone
    {
        public AbstractCordinator Cordinator { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// X cordinate
        /// </summary>
        protected int longitude { get; set; }
        /// <summary>
        /// Y cordinate
        /// </summary>
        protected int latitude {get;set;}

        /// <summary>
        /// change drone's cordinates and notify everyone
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Send(int x,int y)
        {
            longitude = x;
            latitude = y;
            Cordinator.Send(x,y,this);
        }
        public abstract void Handle(int x,int y,string droneName);

        public Drone(string name)
        {
            Name = name;
            var random = new Random();
            longitude = random.Next(1, 100);
            latitude = random.Next(1, 100);
        }
    }
}
