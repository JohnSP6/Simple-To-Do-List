using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;

List<TaskWithPriority> ToDoList = [];
List<TaskWithPriority> ToDoComp = [];

mainMenu();

void mainMenu(){
    
    Console.Clear();
    Console.Write("\n    To-Do List\n\n    1. Add Task \n    2. Remove Task  \n    3. View To-Do List \n    4. Completed Tasks\n    5. Exit\n\n    ");
    try {
        int select = Convert.ToInt32(Console.ReadLine());
        if (select == 1){
            addTask();
        } else if (select == 2) {
            removeTask();
        } else if (select == 3) {
            viewTask();
        } else if (select == 4) {
            completeTask();
        }else if (select == 5) {
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n\n    The program is now Closed.");
            Console.ReadKey();
        } else {
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n\n    Incorrect option selected. Please Try Again.\n\n    ");
            Console.ReadKey();
            mainMenu();
        }
    } catch (Exception){
        Console.Clear();
        Console.WriteLine("\n    To-Do List\n\n    Incorrect input has been inputted. Please Try Again.\n\n    ");
        Console.ReadKey();
        mainMenu();
    }
    
}

void addTask(){

    Console.Clear();
    Console.Write("\n    To-Do List\n\n    What task would you like to add? \n\n    ");
    string? task = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(task)) {
        Console.Clear();
        Console.Write("\n    To-Do List\n\n    Task cannot be null.\n\n    ");
        Console.ReadKey();
        addTask();
    } else {
        Console.Clear();
        Console.Write("\n    To-Do List\n\n    What is the priority level of this task? \n\n    1. High \n    2. Medium  \n    3. Low \n\n    ");
        int taskLevel = Convert.ToInt32(Console.ReadLine());
        if (taskLevel > 3) {
            Console.Clear();
            Console.Write("\n    To-Do List\n\n    Incorrect option selected. Please Try Again.\n\n    ");
            Console.ReadKey();
            addTask();
        }
        Console.Clear();
        Console.Write("\n    To-Do List\n\n    Would you like to add a decription for the task? (Y/N) \n\n    ");
        string? taskdesc = Console.ReadLine();
        if (taskdesc == "Y" || taskdesc == "y") {
            Console.Clear();
            Console.Write("\n    To-Do List\n\n    What is the decription? \n\n    ");
            string? desc = Console.ReadLine();
            ToDoList.Add(new TaskWithPriority(task, desc, taskLevel));
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n\n    Task was successfully added. \n\n    ");
            Console.ReadKey();
            mainMenu();
        } else {
            ToDoList.Add(new TaskWithPriority(task, "No Description", taskLevel));
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n\n    Task was successfully added. \n\n    ");
            Console.ReadKey();
            mainMenu();
        }
    }
}

void removeTask(){
    Console.Clear();
    Console.WriteLine("\n    To-Do List\n ");
    if (ToDoList.Count == 0) {
        Console.WriteLine("    This list is currently empty. ");
        Console.ReadKey();
        mainMenu();
    } else {
        int i = 0;
        ToDoList.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        foreach (var item in ToDoList)
        {
            i++;
            Console.WriteLine($"    {i}. {item.TaskName} \n       - {item.TaskDesc}");
        }
    }
    Console.Write("\n    Which task would you like to remove? \n    If you want to go back, type 'Back'\n    ");
    string? backCheck = Console.ReadLine();
    if (backCheck == "Back" || backCheck == "back") {
        mainMenu();
    } else {
        int taskRemove = Convert.ToInt32(backCheck);
        if (taskRemove > ToDoList.Count) {
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n\n    That is not an option. Please Try Again.\n\n    ");
            Console.ReadKey();
            removeTask();
        } else {
            ToDoList.Remove(ToDoList.ElementAt(taskRemove-1));
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n\n    Task was successfully removed. \n\n    ");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n ");
            if (ToDoList.Count == 0) {
                Console.WriteLine("    This list is currently empty. ");
                Console.ReadKey();
                mainMenu();
            } else {
                int i = 0;
                ToDoList.Sort((x, y) => x.Priority.CompareTo(y.Priority));
                foreach (var item in ToDoList)
                {
                    i++;
                    Console.WriteLine($"    {i}. {item.TaskName} \n       - {item.TaskDesc}");
                }
            }
            Console.WriteLine("\n    If you would like to remove another task, Please type 'R'. ");
            Console.WriteLine("\n    Press any other button to go back.\n\n    ");
            string? again = Console.ReadLine();
            if(again == "R" || again == "r") {
                removeTask();
            } else {
                mainMenu();
            }           
        }
    }
}

void viewTask(){
    Console.Clear();
    Console.WriteLine("\n    To-Do List\n ");
    if (ToDoList.Count == 0) {
        Console.WriteLine("    This list is currently empty. \n    ");
    } else {
        int i = 0;
        ToDoList.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        foreach (var item in ToDoList)
        {
            i++;
            Console.WriteLine($"    {i}. {item.TaskName} \n       - {item.TaskDesc}");
        }
    }
    Console.WriteLine("\n\n    Completed Tasks\n ");
    if (ToDoComp.Count == 0) {
        Console.WriteLine("    This list is currently empty. \n    ");
        Console.ReadKey();
        mainMenu();
    } else {
        int i = 0;
        ToDoComp.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        foreach (var item in ToDoComp)
        {
            i++;
            Console.WriteLine($"    {i}. {item.TaskName} \n       - {item.TaskDesc}");
        }
        Console.WriteLine("\n    Press any button to go back.\n\n    ");
        Console.ReadKey();
        mainMenu();
    }
    
}

void completeTask(){
    Console.Clear();
    Console.WriteLine("\n    To-Do List\n ");
    if (ToDoList.Count == 0) {
        Console.WriteLine("    This list is currently empty. ");
        Console.ReadKey();
        mainMenu();
    } else {
        int i = 0;
        ToDoList.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        foreach (var item in ToDoList)
        {
            i++;
            Console.WriteLine($"    {i}. {item.TaskName} \n       - {item.TaskDesc}");
        }
    }
    Console.Write("\n    Which task would you like to set as completed? \n    If you want to go back, type 'Back'\n    ");
    string? backCheck = Console.ReadLine();
    if (backCheck == "Back" || backCheck == "back") {
        mainMenu();
    } else {
        int taskRemove = Convert.ToInt32(backCheck);
        if (taskRemove > ToDoList.Count) {
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n\n    That is not an option. Please Try Again.\n\n    ");
            Console.ReadKey();
            completeTask();
        } else {
            ToDoComp.Add(ToDoList.ElementAt(taskRemove-1));
            ToDoList.Remove(ToDoList.ElementAt(taskRemove-1));
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n\n    Task was successfully completed.\n\n    ");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n ");
            if (ToDoList.Count == 0) {
                Console.WriteLine("    This list is currently empty.\n\n    ");
                Console.ReadKey();
                mainMenu();
            } else {
                int i = 0;
                ToDoList.Sort((x, y) => x.Priority.CompareTo(y.Priority));
                foreach (var item in ToDoList)
                {
                    i++;
                    Console.WriteLine($"    {i}. {item.TaskName} \n       - {item.TaskDesc}");
                }
            }
            Console.WriteLine("\n    If you would like to complete another task, Please type 'R'. ");
            Console.WriteLine("\n    Press any other button to go back. \n\n    ");
            string? again = Console.ReadLine();
            if(again == "R" || again == "r") {
                completeTask();
            } else {
                mainMenu();
            }
            
        }
    }
}

public class TaskWithPriority
{
    public string TaskName { get; set; }
    public string TaskDesc { get; set; }
    public int Priority { get; set; }

    public TaskWithPriority(string TaskName, string TaskDesc, int priority)
    {
        this.TaskName = TaskName;
        this.TaskDesc = TaskDesc;
        Priority = priority;
    }
}

//Functions to add
// Add Tasks [Done]
// Remove Tasks [Done]
// View Tasks [Done]
// Add Description for Tasks [Done]
// Add Completed Tasks [Done]
// Add Priority [Done]
