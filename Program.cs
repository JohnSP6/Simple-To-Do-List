using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;

Dictionary<string, string> ToDoDict = [];
Dictionary<string, string> ToDoComp = [];

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
            Console.WriteLine("\n    To-Do List\n\n    Incorrect option selected. Please Try Again. ");
            Console.ReadKey();
            mainMenu();
        }
    } catch (Exception){
        Console.Clear();
        Console.WriteLine("\n    To-Do List\n\n    Incorrect input has been inputted. Please Try Again. ");
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
        Console.Write("\n    To-Do List\n\n    Would you like to add a decription for the task? (Y/N) \n\n    ");
        string? taskdesc = Console.ReadLine();
        if (taskdesc == "Y" || taskdesc == "y") {
            Console.Clear();
            Console.Write("\n    To-Do List\n\n    What is the decription? \n\n    ");
            string? desc = Console.ReadLine();
            ToDoDict.Add(task, desc);
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n\n    Task was successfully added.");
            Console.ReadKey();
            mainMenu();
        } else {
            ToDoDict.Add(task, "No Description");
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n\n    Task was successfully added.");
            Console.ReadKey();
            mainMenu();
        }
    }
}

void removeTask(){
    Console.Clear();
    Console.WriteLine("\n    To-Do List\n ");
    if (ToDoDict.Count == 0) {
        Console.WriteLine("    This list is currently empty. ");
        Console.ReadKey();
        mainMenu();
    } else {
        for (int i = 0; i < ToDoDict.Count; i++){
            Console.WriteLine("    " + (i+1) + ". " + ToDoDict.ElementAt(i).Key + "\n       - " + ToDoDict.ElementAt(i).Value);
        }
    }
    Console.Write("\n    Which task would you like to remove? \n    If you want to go back, type 'Back'\n    ");
    string? backCheck = Console.ReadLine();
    if (backCheck == "Back" || backCheck == "back") {
        mainMenu();
    } else {
        int taskRemove = Convert.ToInt32(backCheck);
        if (taskRemove > ToDoDict.Count) {
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n\n    That is not an option. Please Try Again. ");
            Console.ReadKey();
            removeTask();
        } else {
            ToDoDict.Remove(ToDoDict.ElementAt(taskRemove-1).Key);
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n\n    Task was successfully removed.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n ");
            if (ToDoDict.Count == 0) {
                Console.WriteLine("    This list is currently empty. ");
                Console.ReadKey();
                mainMenu();
            } else {
                for (int i = 0; i < ToDoDict.Count; i++){
                    Console.WriteLine("    " + (i+1) + ". " + ToDoDict.ElementAt(i).Key + "\n       - " + ToDoDict.ElementAt(i).Value);
                }
            }
            Console.WriteLine("\n    If you would like to remove another task, Please type 'R'. ");
            Console.WriteLine("\n    Press any other button to go back.");
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
    if (ToDoDict.Count == 0) {
        Console.WriteLine("    This list is currently empty. \n    ");
    } else {
        for (int i = 0; i < ToDoDict.Count; i++){
            Console.WriteLine("    " + (i+1) + ". " + ToDoDict.ElementAt(i).Key + "\n       - " + ToDoDict.ElementAt(i).Value);
        }
    }
    Console.WriteLine("\n\n    Completed Tasks\n ");
    if (ToDoComp.Count == 0) {
        Console.WriteLine("    This list is currently empty. \n    ");
        Console.ReadKey();
        mainMenu();
    } else {
        for (int i = 0; i < ToDoComp.Count; i++){
            Console.WriteLine("    " + (i+1) + ". " + ToDoComp.ElementAt(i).Key + "\n       - " + ToDoComp.ElementAt(i).Value);
        }
        Console.WriteLine("\n    Press any button to go back.");
        Console.ReadKey();
        mainMenu();
    }
    
}

void completeTask(){
    Console.Clear();
    Console.WriteLine("\n    To-Do List\n ");
    if (ToDoDict.Count == 0) {
        Console.WriteLine("    This list is currently empty. ");
        Console.ReadKey();
        mainMenu();
    } else {
        for (int i = 0; i < ToDoDict.Count; i++){
            Console.WriteLine("    " + (i+1) + ". " + ToDoDict.ElementAt(i).Key + "\n       - " + ToDoDict.ElementAt(i).Value);
        }
    }
    Console.Write("\n    Which task would you like to set as completed? \n    If you want to go back, type 'Back'\n    ");
    string? backCheck = Console.ReadLine();
    if (backCheck == "Back" || backCheck == "back") {
        mainMenu();
    } else {
        int taskRemove = Convert.ToInt32(backCheck);
        if (taskRemove > ToDoDict.Count) {
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n\n    That is not an option. Please Try Again. ");
            Console.ReadKey();
            removeTask();
        } else {
            ToDoComp.Add(ToDoDict.ElementAt(taskRemove-1).Key, ToDoDict.ElementAt(taskRemove-1).Value);
            ToDoDict.Remove(ToDoDict.ElementAt(taskRemove-1).Key);
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n\n    Task was successfully completed.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n ");
            if (ToDoDict.Count == 0) {
                Console.WriteLine("    This list is currently empty. ");
                Console.ReadKey();
                mainMenu();
            } else {
                for (int i = 0; i < ToDoDict.Count; i++){
                    Console.WriteLine("    " + (i+1) + ". " + ToDoDict.ElementAt(i).Key + "\n       - " + ToDoDict.ElementAt(i).Value);
                }
            }
            Console.WriteLine("\n    If you would like to complete another task, Please type 'R'. ");
            Console.WriteLine("\n    Press any other button to go back.");
            string? again = Console.ReadLine();
            if(again == "R" || again == "r") {
                completeTask();
            } else {
                mainMenu();
            }
            
        }
    }
}


//Functions to add
// Add Tasks [Done]
// Remove Tasks [Done]
// View Tasks [Done]
// Add Description for Tasks [Done]
// Add Completed Tasks [Done]
// Add Priority
