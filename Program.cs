using LocalDB.DataBases;
using LocalDB.Displays;

namespace LocalDB.Programs;

internal class Program
{
    static void Main()
    {
        Display display = new Display();

        while (true)
        {
            if (!File.Exists(DataBase.filePath)) File.Create(DataBase.filePath).Close();

            DataBase.dataBase = File.ReadAllLines(DataBase.filePath).ToList();

            display.MainMenuDisplay();
        }
    }
}