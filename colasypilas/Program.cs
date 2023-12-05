Queue<string> queueTasks = new Queue<string>();
Stack<string> stackTasks = new Stack<string>();
LinkedList<string> linkedListCompletedTasks = new LinkedList<string>();
int a = 1;
while (a==1)
{
    Console.WriteLine("\n===== Gestión de Tareas =====");
    Console.WriteLine("1. Agregar tarea");
    Console.WriteLine("2. Completar tarea");
    Console.WriteLine("3. Deshacer tarea");
    Console.WriteLine("4. Mostrar tareas completadas");
    Console.WriteLine("5. Salir");
    Console.Write("Ingrese su opción: ");

    int choice;
    if (int.TryParse(Console.ReadLine(), out choice))
    {
        Console.Clear();
        switch (choice)
        {
            case 1:
                Console.Write("Ingrese la nueva tarea: ");
                string newTask = Console.ReadLine();
                queueTasks.Enqueue(newTask);
                Console.WriteLine($"Tarea '{newTask}' agregada a la cola.");
                break;

            case 2:
                if (queueTasks.Count > 0)
                {
                    string completedTask = queueTasks.Dequeue();
                    stackTasks.Push(completedTask);
                    linkedListCompletedTasks.AddLast(completedTask);
                    Console.WriteLine($"Tarea '{completedTask}' completada.");
                }
                else
                {
                    Console.WriteLine("No hay tareas pendientes para completar.");
                }
                break;

            case 3:
                if (stackTasks.Count > 0)
                {
                    string undoneTask = stackTasks.Pop();
                    queueTasks.Enqueue(undoneTask);
                    linkedListCompletedTasks.RemoveLast();
                    Console.WriteLine($"Tarea '{undoneTask}' deshecha.");
                }
                else
                {
                    Console.WriteLine("No hay tareas completadas para deshacer.");
                }
                break;

            case 4:
                Console.WriteLine("\n===== Tareas Completadas =====");
                foreach (var completedTask in linkedListCompletedTasks)
                {
                    Console.WriteLine(completedTask);
                }
                break;

            case 5:
                Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                a = 2;
                return;

            default:
                Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
    }
}