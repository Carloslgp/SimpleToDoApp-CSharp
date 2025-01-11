void PrintSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}


string PrintOptionAndRead()
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all todos");
    Console.WriteLine("[A]dd a todo");
    Console.WriteLine("[R]emove a todo");
    Console.WriteLine("[E]xit");
    string userChoice = Console.ReadLine();
    return userChoice;
}


string ReceiveAToDo()
{
    string toDo = Console.ReadLine();
    return toDo;
}


void PrintTodos(List<string> toDos)
{
    if(toDos.Count > 0)
    {
        for (int i = 0; i < toDos.Count; i++)
        {
            Console.WriteLine($"{i + 1} - " + toDos[i]);           
        }
        return;
    }

    Console.WriteLine("No TODOs have been added yet");   
}

List<string> RemoveToDo(List<string> toDos)
{
    if (toDos.Count == 0)
    {
        return toDos;
    }
    int index = tryReadIndex(toDos);
    Console.WriteLine("TODO removed: " + toDos[index]);
    toDos.RemoveAt(index);


    return toDos;
}

int tryReadIndex(List<string> toDos)
{
    int index;
    while (true)
    {
        Console.WriteLine("Select the index of the TODO you want to remove: ");
        string indexStr = Console.ReadLine();
        if (int.TryParse(indexStr, out index))
        {
            index -= 1;
            if (index >= toDos.Count)
            {
                Console.WriteLine("The given index is not valid");
            }
            else
            {
                return index;
            }
        }
        else
        {
            Console.WriteLine("Conversion to integer failed");
            if (indexStr == "")
            {
                Console.WriteLine("Selected index cannot be empty");
            }
        }
    }
}


string ValidatingToDo(List<string> toDos)
{
    while (true)
    {
        Console.WriteLine("Write a TODO to add:");
        string toDo = ReceiveAToDo();

        if (toDo == "")
        {
            Console.WriteLine("TODO cannot be empty");
        }
        else if(toDos.Contains(toDo))
        {
            Console.WriteLine("This TODO already exists");
        }
        else
        {
            return toDo;
        }
    }
}







string userChoice = "";
List<string> toDos = new List<string>();
Console.WriteLine("Hello!");
bool shallExit = false;

while (!shallExit)
{
    userChoice = PrintOptionAndRead();


    switch (userChoice)
    {
        case "s":
        case "S":
            PrintSelectedOption("See all TODOs");
            PrintTodos(toDos);
            break;
        case "a":
        case "A":
            PrintSelectedOption("Add a TODO");
            string toDo = ValidatingToDo(toDos);
            Console.WriteLine("TODO successfully added:" + toDo);
            toDos.Add(toDo);
            break;
        case "r":
        case "R":
            PrintSelectedOption("Remove a TODO");
            PrintTodos(toDos);
            toDos = RemoveToDo(toDos);
            break;
        case "e":
        case "E":
            PrintSelectedOption("Exit");
            shallExit = true;
            break;
        default:
            Console.WriteLine("Invalid choice");
            Console.WriteLine("Try again");
            break;
    }

}

