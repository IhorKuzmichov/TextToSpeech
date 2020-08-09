using System.Runtime.InteropServices;

public static class HelpClass
{
    [DllImport("wininet.dll")]
    private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

    public static bool IsConnectedToInternet()
    {
        return InternetGetConnectedState(out int description, 0);
    }
}