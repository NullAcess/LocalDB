using LocalDB.Displays;

namespace LocalDB.Operationes;

internal class Operations
{
    public static bool NumberCheck(string str, out int number)
    {
        if (!int.TryParse(str, out number)) return false;
        return true;
    }

    public static void ListElement(List<string> dataBase)
    {
        if (dataBase.Count <= 0)
        {
            Console.WriteLine("==== LOCAL DATA BASE IS EMPTY ===="); // ! ПРОВЕРИТЬ РАБОТУ ПРИ ПУСТОМ СПИСКЕ ДАННЫХ В БД
            return;
        }

        for (int i = 0; i < dataBase.Count; i++)
        {
            Console.WriteLine($"{i}.  {dataBase[i]}");
        }
    }

    public static void AddElement(List<string> dataBase,string filePath, string element)
    {
        dataBase.Add(element);
        File.WriteAllLines(filePath, dataBase);
    }

    public static void RemoveElement(List<string> dataBase, string filePath, int index)
    {
        dataBase.RemoveAt(index);
        File.WriteAllLines(filePath, dataBase);
    }

    public static bool ExitCheck(string userEnter)
    {
        if (userEnter == "/exit") return true;
        return false;
    }
} 
