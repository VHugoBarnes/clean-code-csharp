using System;
using System.Collections.Generic;

namespace ToDo
{
  internal class ToDoProgram
  {
    public static List<string> TaskList { get; set; }

    static void Main(string[] args)
    {
      TaskList = new List<string>();
      int userSelection = 0;
      do
      {
        userSelection = ShowMainMenu();
        if ((Menu)userSelection == Menu.Add)
        {
          AddTaskMenu();
        }
        else if ((Menu)userSelection == Menu.Remove)
        {
          RemoveTaskMenu();
        }
        else if ((Menu)userSelection == Menu.List)
        {
          ShowTasksMenu();
        }
      } while ((Menu)userSelection != Menu.Exit);
    }

    /// <summary>
    /// Show the main menu 
    /// </summary>
    /// <returns>Returns option indicated by user</returns>
    public static int ShowMainMenu()
    {
      Console.WriteLine("----------------------------------------");
      Console.WriteLine("Ingrese la opción a realizar: ");
      Console.WriteLine("1. Nueva tarea");
      Console.WriteLine("2. Remover tarea");
      Console.WriteLine("3. Tareas pendientes");
      Console.WriteLine("4. Salir");

      // Read line
      string userResponse = Console.ReadLine();
      return Convert.ToInt32(userResponse);
    }

    public static void RemoveTaskMenu()
    {
      try
      {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        // Show current taks
        ShowTasks();

        string userResponse = Console.ReadLine();
        // Remove one position
        int indexToRemove = Convert.ToInt32(userResponse) - 1;
        if (indexToRemove > -1)
        {
          if (TaskList.Count > 0)
          {
            string taskToRemove = TaskList[indexToRemove];
            TaskList.RemoveAt(indexToRemove);
            Console.WriteLine("Tarea " + taskToRemove + " eliminada");
          }
        }
      }
      catch (Exception)
      {
      }
    }

    public static void AddTaskMenu()
    {
      try
      {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string taskToAdd = Console.ReadLine();
        TaskList.Add(taskToAdd);
        Console.WriteLine("Tarea registrada");
      }
      catch (Exception)
      {
      }
    }

    public static void ShowTasksMenu()
    {
      ShowTasks();
    }

    private static void ShowTasks()
    {
      if (TaskList == null || TaskList.Count == 0)
      {
        Console.WriteLine("No hay tareas por realizar");
      }
      else
      {
        Console.WriteLine("----------------------------------------");
        for (int i = 0; i < TaskList.Count; i++)
        {
          Console.WriteLine((i + 1) + ". " + TaskList[i]);
        }
        Console.WriteLine("----------------------------------------");
      }
    }
  }

  public enum Menu
  {
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4,
  }
}
