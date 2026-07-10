using LocalDB.Displays;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalDB.DBlogic.Operationes;

internal class Operations
{
    public static void AddAnElement(List<string> dataBase, string filePath)
    {
        dataBase.Add(Display.AddToDataBase());
        File.WriteAllLines(filePath, dataBase);
    }
}
