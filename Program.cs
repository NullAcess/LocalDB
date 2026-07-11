using LocalDB.DataBases;
using LocalDB.Displays;

namespace LocalDB.Programs;

internal class Program
{
    static void Main()
    {
        bool isContinue = true;

        // ========== READING THE LOCAL DB ==========

        while (isContinue)
        {
            if (!File.Exists(DataBase.filePath)) File.Create(DataBase.filePath).Close();

            DataBase.dataBase = File.ReadAllLines(DataBase.filePath).ToList();

            Display.MainMenuDisplay();
            isContinue = false;
        }

        Console.ReadKey();
    }
}