using LocalDB.DataBases;
using LocalDB.Operationes;
using LocalDB.Programs;
using Spectre.Console;

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
                case $"{removeElement}": Console.WriteLine("REMOVE"); ;break;
                case $"{exit}": Environment.Exit(0); break;
            }
        }
    }

    private static void AddElementDisplay()
    {
        Console.Clear();
        Console.Write("Enter an element: ");
        Operations.AddElement(dataBase: DataBase.dataBase, filePath: DataBase.filePath, element: Console.ReadLine() ?? String.Empty);
        Console.ReadLine();
    }

    private static void ListElementDisplay()
    {
        Console.Clear();
        Operations.ListElement(dataBase: DataBase.dataBase);
        Console.ReadLine();
    }
}