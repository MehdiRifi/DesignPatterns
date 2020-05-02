using System;
using System.Collections.Generic;
using DesignPatterns.Behavioral.Command.Model;

namespace DesignPatterns.Behavioral.Command.Repository
{
    public interface ITaskReceiver
    {
        void AddTask(string title);
        void DisplayAllTasks();
        void MarkTaskCompleted(string title);
    }
}
