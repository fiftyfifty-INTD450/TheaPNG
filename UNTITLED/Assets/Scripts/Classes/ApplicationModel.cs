public class ApplicationModel
{
    private static string FileSysHead = "";

    public static void SetFileSysHead(string NewHead)
    {
        FileSysHead = NewHead;
    }

    public static string GetFileSysHead()
    {
        return FileSysHead;
    }
}
