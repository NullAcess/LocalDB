using LocalDB.DataBases;

namespace LocalDB.Operationes;

internal class Operations
{
    public static bool ListElement(List<string> dataBase)
    {
        if (dataBase.Count <= 0) return false;
        return true;
    }

    public static void AddElement(List<string> dataBase, string filePath, string element)
    {
        dataBase.Add(element);
        File.WriteAllLines(filePath, dataBase);
    }

    public static void RemoveElement(List<string> dataBase, string filePath, int userIndex)
    {
        dataBase.RemoveAt(userIndex);
        File.WriteAllLines(filePath, dataBase);
    }

    public static void ChangeElement(List<string> dataBase, string filePath, int userIndex, string userEnter)
    {
        dataBase[userIndex] = userEnter;
        File.WriteAllLines(filePath, dataBase);
    }

    public static bool ReadString(string userEnter)
    {
        if (ExitCheck(userEnter)) return false;
        else return true;
    }

    public static bool ReadIndex(string userEnter, out int userIndex)
    {
        if (!NumberCheck(userEnter, out userIndex)) return false;
        else if (userIndex < 0 || userIndex > DataBase.dataBase.Count - 1) return false;

        return true;
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
