// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

List<string> ToDoList = [];

mainMenu();

void mainMenu(){
    Console.Clear();
    Console.Write("\n    To-Do List\n\n    1. Add Task \n    2. Remove Task  \n    3. View To-Do List \n    4. Exit\n\n    ");
    try {
        int select = Convert.ToInt32(Console.ReadLine());
        if (select == 1){
            addTask();
        } else if (select == 2) {
            removeTask();
        } else if (select == 3) {
            viewTask();
        } else if (select == 4) {
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
        ToDoList.Add(task);
        Console.Clear();
        Console.WriteLine("\n    To-Do List\n\n    Task was successfully added.");
        Console.ReadKey();
        mainMenu();
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
        for (int i = 0; i < ToDoList.Count; i++){
            Console.WriteLine("    " + (i+1) + ". " + ToDoList[i]);
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
            Console.WriteLine("\n    To-Do List\n\n    That is not an option. Please Try Again. ");
            Console.ReadKey();
            removeTask();
        } else {
            ToDoList.RemoveAt(taskRemove-1);
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n\n    Task was successfully removed.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n    To-Do List\n ");
            if (ToDoList.Count == 0) {
                Console.WriteLine("    This list is currently empty. ");
                Console.ReadKey();
                mainMenu();
            } else {
                for (int i = 0; i < ToDoList.Count; i++){
                    Console.WriteLine("    " + (i+1) + ". " + ToDoList[i]);
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
    if (ToDoList.Count == 0) {
        Console.WriteLine("    This list is currently empty. ");
        Console.ReadKey();
        mainMenu();
    } else {
        for (int i = 0; i < ToDoList.Count; i++){
            Console.WriteLine("     " + (i+1) + ". " + ToDoList[i]);
        }
        Console.WriteLine("\n    Press any button to go back.");
        Console.ReadKey();
        mainMenu();
    }
    
}

//Add functionality like Priority, Completed tasks and adding decription