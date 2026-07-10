using LocalDB.DBlogic.Operationes;
using LocalDB.Displays;

namespace LocalDB.Programs;

internal class Program
{
    static void Main()
    {
        bool isContinue = true;
        List<string> dataBase = new List<string>();

        // ========== READING / WRITING THE LOCAL DB ==========
        string filePath = @"C:\Program Files\localDB.txt";

        while (isContinue)
        {
            Display.MainMenu();
            if (!File.Exists(filePath)) File.Create(filePath).Close();

            dataBase = File.ReadAllLines(filePath).ToList();
            Operations.AddAnElement(dataBase, filePath);

            for (int i = 0; i < dataBase.Count; i++) Console.Write($"{dataBase[i]} ");

            isContinue = false;
        }

        Console.ReadKey();
    }
}