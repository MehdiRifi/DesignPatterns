using System;
using DesignPatterns.Behavioral.Command.Model;
using DesignPatterns.Behavioral.Command.Repository;

namespace DesignPatterns.Behavioral.Command
{
    public class MarkTaskCompleteCommand : ICommand
    {
        private readonly ITaskReceiver _taskReceiver;
        private string _title;
        public MarkTaskCompleteCommand(ITaskReceiver taskReceiver, string title)
        {
            _taskReceiver = taskReceiver;
            _title = title;
        }


        public void Execute()
        {
            //Call the receiver
            _taskReceiver.MarkTaskCompleted(_title);
        }
    }
}
