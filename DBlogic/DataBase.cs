namespace LocalDB.DataBases;

internal static class DataBase
{
    public static List<string> dataBase = new List<string>();
    public readonly static string docsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public readonly static string filePath = Path.Combine(docsFolder, "LocalDB.txt");
}