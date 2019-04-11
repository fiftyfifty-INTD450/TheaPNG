public class ApplicationModel
{
    private static string FileSysHead = "";

    public static bool Path1Complete = false;
    public static bool Path2Complete = false;
    public static bool Path3Complete = false;
    public static bool callDone = false;

    public static void SetFileSysHead(string NewHead)
    {
        FileSysHead = NewHead;
    }

    public static string GetFileSysHead()
    {
        return FileSysHead;
    }
}
