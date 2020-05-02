using System;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Behavioral.Command.Model;

namespace DesignPatterns.Behavioral.Command.Repository
{
    /// <summary>
    /// Play the role of receiver
    /// handle data manipulation (in memory test only)
    /// </summary>
    public class TaskReceiver : ITaskReceiver
    {
        private IList<Task> _tasks;
        public TaskReceiver()
        {
            _tasks = new List<Task>();
        }

        /// <summary>
        /// Add task to the list 
        /// </summary>
        /// <param name="title"></param>
        public void AddTask(string title)
        {
            //Check if task with the same name exists
            if (TaskExists(title))
            {
                Console.WriteLine($"Task with the same title ({title}) already exists");
                return;
            }
            //create new task
            var task = new Task(title);
            //add task to the list
            _tasks.Add(task);
            Console.WriteLine($"Task ({task.Title}) has been added successfully");
        }

        /// <summary>
        /// Display all Tasks
        /// </summary>
        public void DisplayAllTasks()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("******** Tasks List ********");
            foreach (var task in _tasks)
            {
                var state = "❌";
                if (task.IsComplete) state = "✅";
                Console.WriteLine($"{task.Title} : {state}");
            }
        }

        public void MarkTaskCompleted(string title)
        {
            var task = FindTaskWithTitle(title);
            if (task == null)
            {
                Console.WriteLine($"Task with id {title} does not exists");
                return;
            }
            task.IsComplete = true;
            Console.WriteLine($"Task {task.Title} marked as completed");
        }

        private Task FindTaskWithTitle(string title)
        {
            return _tasks.FirstOrDefault(t => t.Title == title);
        }

        private bool TaskExists(string title)
        {
            return _tasks.Any(t => t.Title == title);
        }
    }
}
