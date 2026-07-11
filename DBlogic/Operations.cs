using LocalDB.DataBases;
using LocalDB.Displays;

namespace LocalDB.Operationes;

internal class Operations
{
    public static bool ListElement(List<string> dataBase)
    {
        if (dataBase.Count <= 0) return true;

        for (int i = 0; i < dataBase.Count; i++)
        {
            Console.WriteLine($"{i}.  {dataBase[i]}");
        }
        return false;
    }

    public static void AddElement(List<string> dataBase, string filePath, string element)
    {
        dataBase.Add(element);
        File.WriteAllLines(filePath, dataBase);
    }

    public static void RemoveElement(List<string> dataBase, string filePath, int index)
    {
        dataBase.RemoveAt(index);
        File.WriteAllLines(filePath, dataBase);
    }

    public static void ChangeElement(List<string> dataBase, string filePath, int index, string userEnter)
    {
        dataBase[index] = userEnter;
        File.WriteAllLines(filePath, dataBase);
    }

    public static bool ReadString(string userEnter)
    {
        if (ExitCheck(userEnter)) return false;
        else return true;
    }

    public static bool ReadIndex(string userEnter, out int userIndex)
    {
        if (!NumberCheck(userEnter, out userIndex))
        {
            Display.Error();
            return false;
        }

        else if(NumberCheck(userEnter, out userIndex))
        {
            if(userIndex < 0 || userIndex > DataBase.dataBase.Count - 1)
            {
                Display.Error();
                return false;
            }
            return true;
        }
        return false;
    }

    private static bool NumberCheck(string str, out int number)
    {
        if (!int.TryParse(str, out number)) return false;
        return true;
    }

    private static bool ExitCheck(string userEnter)
    {
        if (userEnter == "/exit") return true;
        return false;
    }
}
