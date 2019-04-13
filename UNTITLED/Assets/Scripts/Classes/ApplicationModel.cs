using System.Collections.Generic;

public class ApplicationModel
{
    private static string FileSysHead = "";

    public static bool Path1Complete = false;
    public static bool Path2Complete = false;
    public static bool Path3Complete = false;
    public static bool callDone = false;
    public static bool emailUnlocked = false;
    public static bool draftsUnlocked = false;

    private static HashSet<string> UnlockedFiles = new HashSet<string>();

    public static bool HasBeenUnlocked(string path)
    {
        return UnlockedFiles.Contains(path);
    }

    public static void RegisterUnlockedFile(string path)
    {
        UnlockedFiles.Add(path);
    }

    public static void SetFileSysHead(string NewHead)
    {
        FileSysHead = NewHead;
    }

    public static string GetFileSysHead()
    {
        return FileSysHead;
    }
}
