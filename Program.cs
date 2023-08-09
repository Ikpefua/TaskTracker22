using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskLoader
{
    class Programmer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Level { get; set; }
    }

    class Tasks
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Dependency { get; set; }
        public string Comment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProgrammerId { get; set; }
        public Status Status { get; set; }
    }

    enum Status
    {
        New,
        OnHold,
        Inprogress,
        Recuring
    }

    internal class ProgramTask
    {
        static List<Tasks> tasks = new List<Tasks>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Add Programmer");
                Console.WriteLine("2. Add Task");
                Console.WriteLine("3. View Programmer's Tasks");
                Console.WriteLine("4. Update Task Status");
                Console.WriteLine("5. View All Tasks");
                Console.WriteLine("6. View All Programmers");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");

                // Added task, is the choice
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 2:
                        AddTask();
                        break;
                    case 3:
                        ViewProgrammersTask();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please put a valid intiger");
                        break;
                }
            }
        }

        private static void ViewProgrammersTask()
        {
            if (tasks.Count < 1)
            {
                Console.WriteLine("Task list is Empty");
            }
            else
            {
                Console.WriteLine("List of Task is ");
                Console.WriteLine("________________________________________________________"); Console.WriteLine();
                foreach (var item in tasks)
                {
                    Console.WriteLine("TaskId : " + item.TaskId + " TaskName : " + item.TaskName + " comment: " + item.Comment, item.ProgrammerId);
                }
                Console.WriteLine("________________________________________________________");
                Console.WriteLine();
            }
        }

        private static void AddTask()
        {
            //collect user input (TASK)
            Console.Write("Enter Task Name: ");
            string taskName = Console.ReadLine();
            Console.Write("Enter Dependency: ");
            string dependency = Console.ReadLine();
            Console.Write("Enter Comment: ");
            string comment = Console.ReadLine();
            Console.Write("Enter Start Date: ");
            string startDate = Console.ReadLine();
            Console.Write("Enter End Date: ");
            string endDate = Console.ReadLine();
            Console.Write("Enter Programmer Id: ");
            int programmerId = int.Parse(Console.ReadLine());

            int taskId = tasks.Count + 1;

            var taskList = new Tasks { TaskId = taskId, TaskName = taskName, Comment = comment, Dependency = dependency, ProgrammerId = programmerId };

            tasks.Add(taskList);
            Console.WriteLine("Task added successfully");
            Console.WriteLine("________________________________________________________");
            Console.WriteLine();
            //save
        }

    }
}  
