using System;
using System.Threading;
using System.Threading.Tasks;
using DesignPatterns.Behavioral.Command;
using DesignPatterns.Behavioral.Command.Repository;
using DesignPatterns.Behavioral.Mediator;

namespace ConsoleApp
{
    class Program
    {
        private static Timer timer;
        static async Task Main(string[] args)
        {

            CommandTest();
        }

        /// <summary>
        /// generate random number between 1 - 100
        /// </summary>
        /// <returns></returns>
        private static int GetRandomNumber()
        {
            var random = new Random();
            return random.Next(1, 100);
        }

        /// <summary>
        /// Test for the implementation of the mediator pattern
        /// </summary>
        private async static void MediatorTest()
        {
            //create mediator
            Cordinator cordinator = new Cordinator();

            //create colleagues
            Drone raven = new FWD("Raven");
            Drone martin = new SRD("Martin");
            Drone hope = new MRD("Hope");

            //register colleagues
            cordinator.Register(raven, martin, hope);

            //test => fake movement (press escape to exit)
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                //send the new cordinates
                raven.Send(GetRandomNumber(), GetRandomNumber());

                //sleep for 1 second
                await Task.Delay(1000);
            }
        }

        private static void CommandTest()
        {
            ITaskReceiver taskRepository = new TaskReceiver();
            TaskInvoker taskManager = new TaskInvoker();

            ICommand addTaskCommand1 = new AddTaskCommand(taskRepository, "Read Qurran 30min");
            ICommand addTaskCommand2 = new AddTaskCommand(taskRepository, "Read book 30min");
            ICommand addTaskCommand3 = new AddTaskCommand(taskRepository, "Sport 20min");

            ICommand markTaskCompletedCommand = new MarkTaskCompleteCommand(taskRepository, "Read Qurran 30min");
            ICommand displayAllTasks = new DisplayAllTasksDetailsCommand(taskRepository);

            taskManager.Execute(addTaskCommand1);
            taskManager.Execute(addTaskCommand2);
            taskManager.Execute(addTaskCommand3);
            taskManager.Execute(markTaskCompletedCommand);
            taskManager.Execute(displayAllTasks);


        }
    }
}
