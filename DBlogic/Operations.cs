using LocalDB.Displays;

namespace LocalDB.Operationes;

internal class Operations
{
    public static void AddElement(List<string> dataBase,string filePath, string element)
    {
        dataBase.Add(element);
        File.WriteAllLines(filePath, dataBase);
    }

    public static void ListElement(List<string> dataBase)
    {
        if (dataBase.Count <= 0)
        {
            Console.WriteLine("==== LOCAL DATA BAS IS EMPTY ====");
            return;
        }

        for (int i =0 ; i < dataBase.Count; i++)
        {
            Console.WriteLine($"{i + 1}.  {dataBase[i]}");
        }
    }
} 
