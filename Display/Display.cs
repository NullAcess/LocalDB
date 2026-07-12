using LocalDB.DataBases;
using LocalDB.Operationes;
using Spectre.Console;

namespace LocalDB.Displays;

internal class Display
{
    public void MainMenuDisplay()
    {
        Console.Clear(); // очищаем консоль от прошлого окна, чтоб не было 2 меню на 1 экране.

        const string listElement = "List of elements";
        const string addElement = "Add Element";
        const string removeElement = "Remove Element";
        const string changeElement = "Change Element";
        const string exit = "Exit";

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== CHOOSE OPTION ====");
            Console.WriteLine("'/exit' to exit from category\n");

            var choice = AnsiConsole
                .Prompt(new SelectionPrompt<string>() // собираем список
                .HighlightStyle(new Style(foreground: Color.Red)) // цвет выбранного пункта списка
                .AddChoices($"{listElement}", $"{addElement}", $"{removeElement}", $"{changeElement}", $"{exit}")); // варианты списака

            switch (choice)
            {
                case $"{listElement}": ListElementDisplay(); break;
                case $"{addElement}": AddElementDisplay(); ; break;
                case $"{removeElement}": RemoveElementDisplay(); ; break;
                case $"{changeElement}": ChangeElementDisplay(); break;
                case $"{exit}": Environment.Exit(0); break;
            }
        }
    }

    private void AddElementDisplay()
    {
        string userEnter;

        while (true)
        {
            Console.Clear();
            Console.Write("Enter an element: ");
            userEnter = Console.ReadLine() ?? String.Empty;

            if (!Operations.ReadString(userEnter)) return;

            Operations.AddElement(dataBase: DataBase.dataBase, filePath: DataBase.filePath, element: userEnter);
        }
    }

    private void RemoveElementDisplay()
    {
        int userIndex = 0;
        string userEnter;

        while (true)
        {
            Console.Clear();
            ViewList();
            Console.Write("Enter an index to remove:  ");
            userEnter = Console.ReadLine() ?? String.Empty;

            if (!Operations.ReadString(userEnter: userEnter)) return;
            if (!Operations.ReadIndex(userEnter: userEnter, userIndex: out userIndex)) { Error(); continue; }

            Operations.RemoveElement(dataBase: DataBase.dataBase, filePath: DataBase.filePath, userIndex: userIndex);
        }
    }

    private void ChangeElementDisplay()
    {
        int userIndex = 0;
        string userEnter;

        while (true)
        {
            Console.Clear();
            ViewList();
            Console.Write("Enter an index to change them:  ");
            userEnter = Console.ReadLine() ?? String.Empty;

            if (!Operations.ReadString(userEnter)) return;
            if (!Operations.ReadIndex(userEnter: userEnter, userIndex: out userIndex)) { Error(); continue; }

            Console.Write("Enter a new element:  ");
            userEnter = Console.ReadLine() ?? String.Empty;

            if (!Operations.ReadString(userEnter: userEnter)) return;

            Operations.ChangeElement(dataBase: DataBase.dataBase, filePath: DataBase.filePath, userIndex: userIndex, userEnter: userEnter);
        }
    }

    private void ListElementDisplay()
    {
        string userEnter;

        while (true)
        {
            Console.Clear();

            ViewList();

            Console.Write("Enter: ");
            userEnter = Console.ReadLine() ?? String.Empty;

            if (!Operations.ReadString(userEnter: userEnter)) return;
        }
    }

    private bool Error()
    {
        Console.Clear();
        Console.WriteLine("Error");
        Thread.Sleep(1000);
        return true;
    }

    private void ViewList()
    {
        if (!Operations.ListElement(dataBase: DataBase.dataBase)) Console.WriteLine("==== EMPTY LIST ====");
        else
        {
            for (int i = 0; i < DataBase.dataBase.Count; i++)
            {
                Console.WriteLine($"{i}.  {DataBase.dataBase[i]}");
            }
        }
    }
}