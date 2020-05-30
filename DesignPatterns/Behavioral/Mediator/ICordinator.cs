using System;
namespace DesignPatterns.Behavioral.Mediator
{
    public interface ICordinator
    {

        public abstract void Send(int x, int y,Drone drone);
    }
}
