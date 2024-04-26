using EpoCSReader.Core;
using EpoCSReader.Utils;
using Microsoft.Win32.SafeHandles;

namespace EpoCSReader
{
    public static class MainEstar
    {
        
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                ConsoleAPI.MessageBox(IntPtr.Zero, "Pass the path of the file like argument", "Error", 0);
                return;
            }
            //Reader reader = new Reader(args[0]);
            //reader.Run();
            
        }
    }
}
