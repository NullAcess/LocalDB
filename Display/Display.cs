using Spectre.Console;

namespace LocalDB.Displays;

internal static class Display
{
    public static void MainMenu()
    {
        AnsiConsole.Clear(); // очищаем консоль от прошлого окна, чтоб не было 2 меню на 1 экране.

        bool isContinue = true; // делаем для цикла while

        const string addElement = "Add Element";
        const string removeElement = "Remove Element";
        const string exit = "Exit";
        const string leftSpace = "\t\t\t\t\t\t\t"; // создаем константное поле string, которое будет отсутпать от левого края на определнное расстояние ( для отобраежения списка выбора по центру ).

        while (isContinue) // из за функционала перевыбора персонажа, можно вернуться обратно и нам нужно чтобы цикл выбора персонажа начинался заново, поэтому тут цикл.
        {
            AnsiConsole.Write(new FigletText("Choose option:").Color(Color.Red) // создаем огромное по центру лого
                .Centered() // выравниваем по центру
                .Color(Color.Red));

            TopSpace(topSpaceValue: 15);
            var choice = AnsiConsole
                .Prompt(new SelectionPrompt<string>() // собираем список
                .HighlightStyle(new Style(foreground: Color.Red)) // цвет выбранного пункта списка
                .AddChoices($"{leftSpace}{addElement}", $"{leftSpace}{removeElement}", $"{leftSpace}{exit}")); // варианты списака

            switch (choice)
            {
                case $"{leftSpace}{addElement}": Console.WriteLine("ADD"); ;break;
                case $"{leftSpace}{removeElement}": Console.WriteLine("REMOVE"); ;break;
                case $"{leftSpace}{exit}": Environment.Exit(0); break;
            }
        }
    }

    public static string AddToDataBase()
    {
        Console.Write("Enter an element: ");
        return Console.ReadLine() ?? String.Empty;
    }

    private static void TopSpace(int topSpaceValue = 0)
    {
        Console.SetCursorPosition(0, topSpaceValue);
    }
}