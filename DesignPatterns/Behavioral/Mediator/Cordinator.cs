using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Behavioral.Mediator
{
    /// <summary>
    /// [Concreate Cordinator]
    /// Cordinator, handle the communication (interaction)
    /// between components (colleagues)
    /// </summary>
    public class Cordinator : ICordinator
    {
        private IList<Drone> drones;

        /// <summary>
        /// Register drones
        /// </summary>
        /// <param name="drone"></param>
        public void Register(params Drone[] dronesList)
        {
            if (drones == null) InitDronesList();
            foreach (var drone in dronesList)
            {
                drones.Add(drone);
                drone.Cordinator = this;
            }
        }

        public Cordinator()
        {
            InitDronesList();
        }
        /// <summary>
        /// Init drones list
        /// </summary>
        private void InitDronesList()
        {
            drones = new List<Drone>();
        }
        /// <summary>
        /// Dispatch the message to the appropriate receiver
        /// </summary>
        public void Send(int x, int y, Drone drone)
        {
            drones.Where(d => d != drone).ToList().ForEach((d) =>
            {
                d.Handle(x, y, drone.Name);
            });
        }
    }
}
