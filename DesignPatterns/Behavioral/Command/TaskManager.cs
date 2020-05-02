using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Command
{
    /// <summary>
    /// Play the role of the invoker 
    /// </summary>
    public class TaskInvoker
    {
        /// <summary>
        /// command pool
        /// </summary>
        private  Queue<ICommand> _commands;

        /// <summary>
        /// Constructor
        /// </summary>
        public TaskInvoker()
        {
            _commands = new Queue<ICommand>();
        }

        /// <summary>
        /// add the command to the command pool
        /// </summary>
        /// <param name="command"></param>
        public void Execute(ICommand command)
        {
            _commands.Enqueue(command);
            command.Execute();
        }
    }
}
