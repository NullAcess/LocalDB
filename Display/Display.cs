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
        const string exit = "Exit";

        while (isContinue)
        {
            Console.Clear();
            Console.WriteLine("==== CHOOSE OPTION ====");
;
            var choice = AnsiConsole
                .Prompt(new SelectionPrompt<string>() // собираем список
                .HighlightStyle(new Style(foreground: Color.Red)) // цвет выбранного пункта списка
                .AddChoices($"{listElement}", $"{addElement}", $"{removeElement}", $"{exit}")); // варианты списака

            switch (choice)
            {
                case $"{listElement}": ListElementDisplay(); break;
                case $"{addElement}": AddElementDisplay(); ;break;
                case $"{removeElement}": RemoveElementDisplay(); ;break;
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
            Console.Write("('/exit') Enter an element: ");
            userEnter = Console.ReadLine() ?? String.Empty;

            if (Operations.ExitCheck(userEnter)) return;

            Operations.AddElement(dataBase: DataBase.dataBase, filePath: DataBase.filePath, element: Console.ReadLine() ?? String.Empty);
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
            Console.Write("('/exit') Enter an index to remove:  ");
            userEnter = Console.ReadLine() ?? String.Empty;

            if(!Operations.ExitCheck(userEnter))
            {
                if (!Operations.NumberCheck(userEnter, out userIndex))
                {
                    if (Error()) continue;
                }
            }

            Operations.RemoveElement(dataBase: DataBase.dataBase, filePath: DataBase.filePath, index: userIndex);
        }
    }

    private static void ListElementDisplay()
    {
        string userEnter;

        while (true)
        {
            Console.Clear();
            Operations.ListElement(dataBase: DataBase.dataBase);
            userEnter = Console.ReadLine() ?? String.Empty;

            if (Operations.ExitCheck(userEnter)) return;
        }
    }

    private static bool Error()
    {
        Console.Clear();
        Console.WriteLine("Error");
        Thread.Sleep(1000);
        return true;
    }
}