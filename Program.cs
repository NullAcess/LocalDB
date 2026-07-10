using LocalDB.Displays;
using LocalDB.DataBases;

namespace LocalDB.Programs;

internal class Program
{
    static void Main()
    {
        bool isContinue = true;

        // ========== READING / WRITING THE LOCAL DB ==========

        while (isContinue)
        {
            if (!File.Exists(DataBase.filePath)) File.Create(DataBase.filePath).Close();

            DataBase.dataBase = File.ReadAllLines(DataBase.filePath).ToList();

            for (int i = 0; i < DataBase.dataBase.Count; i++) Console.Write($"{DataBase.dataBase[i]} ");

            Display.MainMenuDisplay();
            isContinue = false;
        }

        Console.ReadKey();
    }
}