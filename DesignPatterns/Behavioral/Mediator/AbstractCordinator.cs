using System;
namespace DesignPatterns.Behavioral.Mediator
{
    public abstract class AbstractCordinator
    {

        public abstract void Send(int x, int y,Drone drone);
    }
}
