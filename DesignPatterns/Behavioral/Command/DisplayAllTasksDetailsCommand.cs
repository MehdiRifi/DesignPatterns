using System;
using DesignPatterns.Behavioral.Command.Repository;

namespace DesignPatterns.Behavioral.Command
{
    /// <summary>
    /// Concrete Command : 
    /// </summary>
    public class DisplayAllTasksDetailsCommand:ICommand
    {
        private readonly ITaskReceiver _taskReceiver;
        public DisplayAllTasksDetailsCommand(ITaskReceiver taskReceiver)
        {
            _taskReceiver = taskReceiver;
        }

        public void Execute()
        {
            //Call the receiver
            _taskReceiver.DisplayAllTasks();
        }
    }
}
