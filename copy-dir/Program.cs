class CopyDir
{
    public static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Green;

        string path = @"C:\Users\Anwender\source\repos\CodingCampus_2023.09.VZ.Dornbirn\Fabian";
        string newPath = @"C:\Users\Anwender\Documents\test";

        CopyProject(path, newPath);

    }

    public static void CopyProject(string path, string newPath)
    {
        string[] files = Directory.GetFiles(path);
        string[] dirs = Directory.GetDirectories(path);

        foreach (var file in files)
        {
            if (File.Exists(file))
            {
                string destFile = Path.Combine(newPath, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }
        }
        foreach (var dir in dirs)
        {
            string destDir = Path.Combine(newPath, Path.GetFileName(dir));
            Directory.CreateDirectory(destDir);
            CopyProject(dir, destDir);
        }
    }

}