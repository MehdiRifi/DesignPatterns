using System;
namespace DesignPatterns.Behavioral.Command.Model
{
    public class Task
    {
        /// <summary>
        /// title is unique
        /// </summary>
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public Task(string title)
        {
            Title = title;
        }
    }
}
