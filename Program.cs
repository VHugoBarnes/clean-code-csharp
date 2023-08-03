List<string> TaskList = new List<string>();

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

/// <summary>
/// Show the options to use the ToDo App.
/// Options:
/// 1. New task
/// 2. Remove task
/// 3. Pending tasks
/// 4. Exit
/// </summary>
/// <returns>Returns option selected by user</returns>
int ShowMainMenu()
{
  Console.WriteLine("----------------------------------------");
  Console.WriteLine("Ingrese la opción a realizar: ");
  Console.WriteLine("1. Nueva tarea");
  Console.WriteLine("2. Remover tarea");
  Console.WriteLine("3. Tareas pendientes");
  Console.WriteLine("4. Salir");

  string userResponse = Console.ReadLine();
  return Convert.ToInt32(userResponse);
}

void RemoveTaskMenu()
{
  try
  {
    Console.WriteLine("Ingrese el número de la tarea a remover: ");
    ShowTasks();

    string userResponse = Console.ReadLine();

    // Remove one position because the array starts in 0
    int indexToRemove = Convert.ToInt32(userResponse) - 1;

    if (indexToRemove > (TaskList.Count - 1) || indexToRemove <= 0)
    {
      Console.WriteLine("El numero seleccionado no es valido");
      Console.WriteLine();
      return;
    }

    if (indexToRemove > -1 && TaskList.Count > 0)
    {
      string taskToRemove = TaskList[indexToRemove];
      TaskList.RemoveAt(indexToRemove);
      Console.WriteLine($"Tarea {taskToRemove} eliminada");
      Console.WriteLine();
    }
  }
  catch (Exception)
  {
    Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
    Console.WriteLine();
  }
}

void AddTaskMenu()
{
  try
  {
    Console.WriteLine("Ingrese el nombre de la tarea: ");
    string taskToAdd = Console.ReadLine().Trim();

    if (taskToAdd == "")
    {
      Console.WriteLine("Escribe una tarea valida");
      Console.WriteLine();
      return;
    }

    TaskList.Add(taskToAdd);
    Console.WriteLine("Tarea registrada");
    Console.WriteLine();
  }
  catch (Exception)
  {
    Console.WriteLine("No se pudo agregar la tarea");
    Console.WriteLine();
  }
}

void ShowTasksMenu()
{
  ShowTasks();
}

void ShowTasks()
{
  if (TaskList?.Count > 0)
  {
    Console.WriteLine("----------------------------------------");
    var indexTask = 0;
    TaskList.ForEach(task => Console.WriteLine($"{++indexTask}. {task}"));
    Console.WriteLine("----------------------------------------");
    Console.WriteLine();
  }
  else
  {
    Console.WriteLine("No hay tareas por realizar");
  }
}


enum Menu
{
  Add = 1,
  Remove = 2,
  List = 3,
  Exit = 4,
}

