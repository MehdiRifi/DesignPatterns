using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DesignPatterns.Behavioral.Command;
using DesignPatterns.Behavioral.Command.Repository;
using DesignPatterns.Behavioral.Iterator;
using DesignPatterns.Behavioral.Mediator;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //CommandTest();
            //await MediatorTest();
            IteratorTest();
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
        private async static Task MediatorTest()
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
        /// <summary>
        /// Test for the implementation of the command pattern
        /// </summary>
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

        private static void IteratorTest()
        {
            //create tree
            var tree = new List<TreeItem>();
            var d = new TreeItem("D");
            var e = new TreeItem("E");
            var f = new TreeItem("F");
            var c = new TreeItem("C", f);
            var b = new TreeItem("B", c, d);
            var a = new TreeItem("A", b, e);

            b.Parent = a;
            c.Parent = b;
            f.Parent = c;
            d.Parent = b;
            e.Parent = a;

            tree.Add(a);
            tree.Add(b);
            tree.Add(c);
            tree.Add(d);
            tree.Add(e);
            tree.Add(f);
            /*
            *               1- A
            *                 / \
            *                /   \
            *            2- B     E -6
            *              / \
            *             /   \ 
            *         3- C     D -5
            *           /   
            *          /
            *      4- F 
             */

            //create collection
            ITreeCollection treeCollection = new Tree(tree);

            //create iterator
            IIterator<TreeItem> iterator = treeCollection.GetDepthFirstIterator();

            while (iterator.HasMore())
            {
                var item = iterator.Next();
                Console.WriteLine(item.Name);
            }
        }
    }
}
