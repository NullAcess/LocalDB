using LocalDB.DataBases;
using LocalDB.Operationes;
using Spectre.Console;
using System.Reflection.Metadata.Ecma335;

namespace LocalDB.Displays;

internal static class Display
{
    public static void MainMenuDisplay()
    {
        AnsiConsole.Clear(); // очищаем консоль от прошлого окна, чтоб не было 2 меню на 1 экране.

        bool isContinue = true; // делаем для цикла while

        const string listElement = "List of elements";
        const string addElement = "Add Element";
        const string removeElement = "Remove Element";
        const string changeElement = "Change Element";
        const string exit = "Exit";

        while (isContinue)
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

    private static void AddElementDisplay()
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

    private static void RemoveElementDisplay()
    {
        int userIndex = 0;
        string userEnter;

        while (true)
        {
            Console.Clear();
            Operations.ListElement(dataBase: DataBase.dataBase);
            Console.Write("Enter an index to remove:  ");
            userEnter = Console.ReadLine() ?? String.Empty;

            if (!Operations.ReadString(userEnter)) return;
            if (!Operations.ReadIndex(userEnter, out userIndex)) continue;

            Operations.RemoveElement(dataBase: DataBase.dataBase, filePath: DataBase.filePath, index: userIndex);
        }
    }

    private static void ChangeElementDisplay()
    {
        int userIndex = 0;
        string userEnter;

        while (true)
        {
            Console.Clear();
            Operations.ListElement(dataBase: DataBase.dataBase);
            Console.Write("Enter an index to change them:  ");
            userEnter = Console.ReadLine() ?? String.Empty;

            if (!Operations.ReadString(userEnter)) return;
            if (!Operations.ReadIndex(userEnter, out userIndex)) continue;

            Console.Write("Enter a new element:  ");
            userEnter = Console.ReadLine() ?? String.Empty;

            if (!Operations.ReadString(userEnter)) return;

            Operations.ChangeElement(DataBase.dataBase, DataBase.filePath, userIndex, userEnter);
        }
    }

    private static void ListElementDisplay()
    {
        string userEnter;

        while (true)
        {
            Console.Clear();

            if(DataBase.dataBase.Count <= 0) Console.WriteLine("==== EMPTY LIST ====");
            else Operations.ListElement(dataBase: DataBase.dataBase);

            Console.Write("Enter: ");
            userEnter = Console.ReadLine() ?? String.Empty;

            if (!Operations.ReadString(userEnter)) return;
        }
    }

    public static bool Error()
    {
        Console.Clear();
        Console.WriteLine("Error");
        Thread.Sleep(1000);
        return true;
    }
}