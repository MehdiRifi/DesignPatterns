using System;
using DesignPatterns.Behavioral.Command.Model;
using DesignPatterns.Behavioral.Command.Repository;

namespace DesignPatterns.Behavioral.Command
{
    /// <summary>
    /// Concrete Command : add task
    /// </summary>
    public class AddTaskCommand:ICommand
    {
        private readonly ITaskReceiver _taskReceiver;
        private string _title;
        public AddTaskCommand(ITaskReceiver taskReceiver,string title)
        {
            _taskReceiver = taskReceiver;
            _title = title ;
        }

        public void Execute()
        {
            //Call the receiver
            _taskReceiver.AddTask(_title);
        }
    }
}
